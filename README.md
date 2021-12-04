# RoboticArmProject

Aim : To train robot with joints, each having 2 DOF to reach target.



Method(s): Deep Reinforcement Learning + Curriculum Learning (Not Implemented)<br>
Reward(s): Extrinsic + Generative Adversarial Imitation Learning  <br>


Observation Vector: <br>
 * Position of Each Joint and Target <br>


Action:
*  Rotation Input Along each of two axis for 4 joints.

Intrinsic Reward Criteria:
  - <-1> for each time step
  - <-Big Value> for collision with itself (Robot) + End of Episode
  - <+Big Value> for getting within sphere of certain radius with target at its center.
  - <-Big Value> for getting out of sphere of certain radius with target at its center.
  - <+Very Big Value> for touching the target.
  
 
Training Demo:


![ezgif com-gif-maker](https://user-images.githubusercontent.com/77914957/144712097-5e83fa0e-1746-447f-a33c-cf2a143f3835.gif)

Left: Model Testing (Starts Learning in Very Few Steps)| Right: Recording Demonstration

![ezgif com-gif-maker(1)](https://user-images.githubusercontent.com/77914957/144712146-25e0b029-c3ba-4366-90d1-93daa8a848a9.gif)
