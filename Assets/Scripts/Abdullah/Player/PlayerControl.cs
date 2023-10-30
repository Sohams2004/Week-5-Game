using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// React to Player Inputs
/// </summary>
public class PlayerControl : Subject
{

    StartEvent startEvent;
    [SerializeField] private playerState playerState;
    Rigidbody rb;



    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerInput();
        switch (playerState)
        {
            case playerState.idling:
                //play aniamtion or something.
                break;
            case playerState.walking:
                NotifyObservers(StartEvent.walking);
                
                //send notifcation.
                break;
            case playerState.jumping:
                NotifyObservers(StartEvent.jumping);
                Debug.Log("Send Jump");
                playerState = playerState.idling;
                break;
        }
    }

    private void PlayerInput()
    {

        if(Input.mousePosition.y!=0 || Input.mousePosition.x != 0)
        {
            NotifyObservers(StartEvent.lookingAround);

        }
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            playerState = playerState.walking;

        }
        else if (rb.velocity == new Vector3(0, 0, 0))
        {
            playerState = playerState.idling;
        }
        if (Input.GetButtonDown("Jump"))
        {
            playerState = playerState.jumping;

        }

    }



}
