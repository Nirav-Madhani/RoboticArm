using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public MyAgent agent;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            agent.Collided();
        }

    }
}
