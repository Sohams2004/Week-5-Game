using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiting : MonoBehaviour,RobotObserver
{
    // Start is called before the first frame update


    [SerializeField] Subject2 subject2;
    [SerializeField] NavMeshAgent agent;

    public void OnNotify(RobotState action)
    {
        if (action == RobotState.wait)
        {
            Wait();
        }

    }

    void Wait()
    {
        Debug.Log("Waiting Next to Player");
        agent.isStopped = true;
        agent.SetDestination(transform.position);

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
