using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRobot : Subject2
{


    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            FollowPlayer();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
            {
            FollowCommand(); 
        
        }
        

    }

    void FollowPlayer()
    {
        Debug.Log("Send Follow ME");

        NotifyObservers(RobotState.followPlayer);
    }

    void FollowCommand()
    {
        Debug.Log("Send Command");

        NotifyObservers(RobotState.followCommand);
    }

}
