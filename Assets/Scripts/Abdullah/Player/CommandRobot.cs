using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandRobot : Subject2
{
    [SerializeField] NavMeshAgent agent;
    GameObject robot;
    public static bool isFollowingCommand = false;
    float distanaceToPlayer;


    void Start()
    {
        //invert the mask

        robot = GameObject.Find("Robot");
    }
    public void PingObservers(RobotState action)
    {
        NotifyObservers(action);

    }

    void Update()
    {

        float pressingTrigger = Input.GetAxisRaw("XRI_Right_Trigger");
        float pressingGrip = Input.GetAxisRaw("XRI_Right_Grip");



        if (Input.GetKeyDown(KeyCode.Mouse1)|| pressingTrigger >=0.8 && pressingGrip>=0.8)
        {
            Debug.Log("Send Follow ME");
            isFollowingCommand = false;
            NotifyObservers(RobotState.followPlayer);

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0)|| pressingGrip >= 0.8 && Input.GetButton("XRI_Right_SecondaryButton"))
        {
            Debug.Log("Send Command");
            isFollowingCommand = true;
            NotifyObservers(RobotState.followCommand);

        }
        else
        {
            distanaceToPlayer = Vector3.Distance(transform.position, robot.transform.position);
            if (isFollowingCommand == false && distanaceToPlayer < 2)
            {
                NotifyObservers(RobotState.wait);
            }
            else if (isFollowingCommand == false && distanaceToPlayer > 2)
            {
                NotifyObservers(RobotState.followPlayer);
            }

        }
    }


}
