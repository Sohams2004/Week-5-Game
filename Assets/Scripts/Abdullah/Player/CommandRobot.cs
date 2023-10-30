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

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Send Follow ME");
            isFollowingCommand = false;
            NotifyObservers(RobotState.followPlayer);

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
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
