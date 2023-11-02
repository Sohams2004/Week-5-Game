using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Pointing : MonoBehaviour, RobotObserver
{
    [SerializeField] Subject2 subject2;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform hitPosition;
    [SerializeField] Transform origin;
    [SerializeField] Transform target;

    [SerializeField] Animator leftHand;
    [SerializeField] Animator rightHand;
    [SerializeField] NavMeshAgent agent;
    RaycastHit hit;

    int glassMask = 1 << 6;

    // Start is called before the first frame update
    void Start()
    {
        glassMask = ~glassMask;
        lineRenderer.positionCount= 2;
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();

        if (Physics.Raycast(origin.position, hitPosition.position - origin.position, out hit, Mathf.Infinity, glassMask))
        {
            lineRenderer.SetPosition(0, origin.position);
            lineRenderer.SetPosition(1, hit.point);

        }
    }


        private void MoveHere()
        {
        Debug.Log("FollowCommands");
        agent.isStopped = false;
        target.position = hit.point;
            agent.SetDestination(hit.point);
        }


        void Aiming()
    {
        //no idea did not work
        float pressingTrigger = Input.GetAxisRaw("XRI_Right_Trigger");
        float pressingGrip = Input.GetAxisRaw("XRI_Right_Grip");


        //back button pressing not a trigger
        if (pressingTrigger > 0)
        {
            rightHand.SetFloat("Blend", pressingTrigger);
            lineRenderer.enabled = false;
        }
        if (pressingGrip > 0)
        {
            rightHand.SetFloat("Point", pressingGrip);
             if (pressingTrigger<0.2f) lineRenderer.enabled = true;


        }
        else lineRenderer.enabled = false;


    }
    public void OnNotify(RobotState action)
    {
        if (action == RobotState.followCommand)
        {
            MoveHere();
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
