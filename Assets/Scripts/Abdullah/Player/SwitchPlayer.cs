using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class SwitchPlayer : MonoBehaviour
{


    [SerializeField] GameObject player;
    [SerializeField] GameObject robot;
    [SerializeField] GameObject hand;
    RaycastHit hit;

    [SerializeField] Transform startTransform;

    Transform handHere;
    bool isClose;
    // Start is called before the first frame update
    void Start()
    {
        handHere = startTransform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hand" && Input.GetButton("XRI_Left_GripButton") || other.gameObject.tag == "Hand" && Input.GetButton("XRI_Right_GripButton"))
        {
            isClose = true;
            transform.position = hand.transform.position;
            transform.rotation = hand.transform.rotation;


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            Debug.Log("EXIT");
            isClose = false;
            transform.position = handHere.transform.position;
            transform.rotation = handHere.transform.rotation;

            robot.GetComponent<movement>().enabled = false;
            robot.GetComponent<PlayerInput>().enabled = false;
            robot.GetComponent<Jumping>().enabled = false;
            robot.GetComponent<NavMeshAgent>().enabled = true;
            robot.GetComponent<NavMeshAgent>().isStopped = true;



            player.GetComponent<movement>().enabled = true;
            player.GetComponent<PlayerInput>().enabled = true;

        }

    }


    // Update is called once per framef
    void Update()
    {
        if (isClose == true && Input.GetButton("XRI_Left_GripButton"))
        {
            Debug.Log("holding Hand_L");

            player.GetComponent<movement>().enabled = false;
            player.GetComponent<PlayerInput>().enabled = false;

            robot.GetComponent<NavMeshAgent>().enabled = false;
            robot.GetComponent<movement>().enabled = true;
            robot.GetComponent<PlayerInput>().enabled = true;
            robot.GetComponent<Jumping>().enabled = true;
        }
        if (isClose == true && Input.GetButton("XRI_Right_GripButton"))
        {
            Debug.Log("holding Hand_R");

            player.GetComponent<movement>().enabled = false;
            player.GetComponent<PlayerInput>().enabled = false;

            robot.GetComponent<NavMeshAgent>().enabled = false;
            robot.GetComponent<movement>().enabled = true;
            robot.GetComponent<PlayerInput>().enabled = true;
            robot.GetComponent<Jumping>().enabled = true;
        }


        if (isClose == true && Input.GetButtonUp("XRI_Right_GripButton"))
        {
            Debug.Log("LeftShiftHandler Controlls");
            robot.GetComponent<movement>().enabled = false;
            robot.GetComponent<PlayerInput>().enabled = false;
            robot.GetComponent<Jumping>().enabled = false;
            robot.GetComponent<NavMeshAgent>().enabled = true;
            robot.GetComponent<NavMeshAgent>().isStopped = true;

            player.GetComponent<movement>().enabled = true;
            player.GetComponent<PlayerInput>().enabled = true;
        }
        if (isClose == true && Input.GetButtonUp("XRI_Left_GripButton"))
        {
            Debug.Log("LeftShiftHandler Controlls");
            robot.GetComponent<movement>().enabled = false;
            robot.GetComponent<PlayerInput>().enabled = false;
            robot.GetComponent<Jumping>().enabled = false;
            robot.GetComponent<NavMeshAgent>().enabled = true;
            robot.GetComponent<NavMeshAgent>().isStopped = true;

            player.GetComponent<movement>().enabled = true;
            player.GetComponent<PlayerInput>().enabled = true;

        }

    }






}


