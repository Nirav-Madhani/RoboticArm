using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
public class MyAgent : Agent
{
    public GameObject myTarget;

    /// <summary>
    /// To record position of all joints. 1-2-3-4
    /// </summary>
    public GameObject joint1;
    public GameObject joint2;
    public GameObject joint3;
    public GameObject joint4;
    /// <summary>
    /// To Apply rotation to joints.  0-1-2-3
    /// </summary>
    public GameObject root;
    GameObject r1;
    GameObject r2;
    GameObject r3;
    // Start is called before the first frame update
    void Start()
    {
        r1 = joint1;
        r2 = joint2;
        r3 = joint3;
    }
    public override void CollectObservations()
    {
        AddVectorObs(joint1.transform.position-transform.position);
        AddVectorObs(joint2.transform.position - transform.position);
        AddVectorObs(joint3.transform.position - transform.position);
        AddVectorObs(joint4.transform.position - transform.position);
        AddVectorObs(myTarget.transform.position - transform.position);
        AddVectorObs(Vector3.Distance(joint4.transform.position, myTarget.transform.position));
    }
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(-0.1f);

        root.transform.Rotate( new Vector3(vectorAction[0], vectorAction[1], vectorAction[2])*5);
    //    Debug.Log(vectorAction[0]);
        r1.transform.Rotate(new Vector3(vectorAction[3], vectorAction[4], vectorAction[5]) * 5);
        r2.transform.Rotate(new Vector3(vectorAction[6], vectorAction[7], vectorAction[8]) * 5);
        r3.transform.Rotate(new Vector3(vectorAction[9], vectorAction[10], vectorAction[11]) * 5);
        AddReward((Vector3.Distance(root.transform.position, myTarget.transform.position) - Vector3.Distance(joint4.transform.position, myTarget.transform.position))/ (Vector3.Distance(root.transform.position, myTarget.transform.position)));
        
        
        /// 0.1f -> 0.1f meter tolerance.


        if (Vector3.Distance(joint4.transform.position, myTarget.transform.position)<=0.1f) {
            /*
             * 
             lim->1 reward is already added above in " AddReward((Vector3.Dist......" 
             This is bonus +1 reward and calls Done()
             
             */
           // Debug.Log("Finish!");
            AddReward(1);
            Done();
        }

    }
    public float Nearest=0;
    public float Farthest=5;
    public void Collided() {
        AddReward(-1f);
        Done();
    }
    public override void AgentReset()
    {
       
        root.transform.rotation = Random.rotation;
        r1.transform.rotation = Random.rotation;
        r2.transform.rotation = Random.rotation;
        r3.transform.rotation = Random.rotation;
        
        // Nearest :2 
        //Farthest:10
        myTarget.transform.position = root.transform.position + Random.onUnitSphere * Random.Range(Nearest, Farthest);
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("Finish!");
            Done();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
