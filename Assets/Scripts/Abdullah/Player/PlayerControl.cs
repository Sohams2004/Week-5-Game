using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// React to Player Inputs
/// </summary>
public class PlayerControl : Subject
{

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
                NotifyObservers(StartEvent.Walking);

                //send notifcation.
                break;
        }
    }

    private void PlayerInput()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            playerState = playerState.walking;

        }
        else if (rb.velocity == new Vector3(0, 0, 0))
        {
            playerState = playerState.idling;
        }

    }



}
