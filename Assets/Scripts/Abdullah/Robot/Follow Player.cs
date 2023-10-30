using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow_Player : MonoBehaviour, RobotObserver
{
    [SerializeField] Subject2 subject2;
    [SerializeField] NavMeshAgent agent;
    GameObject player;



    void Start()
    {
        //invert the mask

        player = GameObject.FindWithTag("Player");
    }

    public void OnNotify(RobotState action)
    {
        if (action == RobotState.followPlayer) FollowPlayer();

    }

    void FollowPlayer()
    {
        agent.isStopped = false;
        Debug.Log("FollowPlayer");
        CommandRobot.isFollowingCommand = false;
        agent.SetDestination(player.transform.position);
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
