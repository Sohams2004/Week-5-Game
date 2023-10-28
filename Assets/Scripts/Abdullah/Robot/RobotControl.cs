using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RobotControl : Subject2, RobotObserver
{
    [SerializeField] Subject2 subject2;

    [SerializeField] NavMeshAgent agent;
     GameObject player;
    [SerializeField]private RobotState robotState;
    bool isFollowingCommand=false;
    float distanaceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        print(player.name);
    }

    // Update is called once per frame
    void Update()
    {
        distanaceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (isFollowingCommand == false && distanaceToPlayer < 2)
        {
            Waiting();
        }
        else if (isFollowingCommand == false && distanaceToPlayer > 2)
        {
            FollowPlayer();
        }



    }
    void Command()
    {
        switch (robotState)
        {
            case RobotState.followPlayer:
                FollowPlayer();
                break;
            case RobotState.followCommand:
                FollowCommands();
                break;

        }
    }

    public void OnNotify(RobotState action)
    {
        robotState = action;
        Command();

    }

    void Waiting()
    {
        Debug.Log("Waiting Next to Player");
        robotState= RobotState.wait;
        agent.isStopped = true;
        agent.SetDestination(transform.position);

    }
    void FollowPlayer()
    {
        agent.isStopped = false;
        Debug.Log("FollowPlayer");
        isFollowingCommand = false;
        robotState = RobotState.followCommand;
        agent.SetDestination(player.transform.position);
    }
    void FollowCommands()
    {
        Debug.Log("FollowCommands");
        agent.isStopped = false;
        isFollowingCommand = true;
        Ray CameraPosition= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit moveDistnation;
        if (Physics.Raycast(CameraPosition, out moveDistnation))
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
