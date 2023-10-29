using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowCommand : MonoBehaviour,RobotObserver
{

    [SerializeField] Subject2 subject2;
    int glassMask = 1 << 6;
    [SerializeField] NavMeshAgent agent;

    void Start()
    {
        glassMask = ~glassMask;


}
public void OnNotify(RobotState action)
    {
        if (action == RobotState.followCommand)
        {
            FollowingCommands();
        }
    }

    void FollowingCommands()
    {
        CommandRobot.isFollowingCommand = true;


        Debug.Log("FollowCommands");
        agent.isStopped = false;
        Ray CameraPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit moveDistnation;
        if (Physics.Raycast(CameraPosition, out moveDistnation, Mathf.Infinity, glassMask))
        {
            agent.SetDestination(moveDistnation.point);


        }


    }

    private void OnEnable()
    {
        subject2.AddObserver(this);
    }
    private void OnDisable()
    {
        subject2.RemoveObserver(this);
    }

}
