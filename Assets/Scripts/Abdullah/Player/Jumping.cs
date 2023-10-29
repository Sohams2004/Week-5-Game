using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour, IObserver
{
    [SerializeField] Subject subject;
    // Start is called before the first frame update
    [SerializeField] int numberOfJumps= 2;
    Rigidbody rb;
    [SerializeField] float jumpHight;
    [SerializeField] float jumpDuration;
    [SerializeField] float multiplyGravity=2;
    int jumpReset;

    float gravity,initalVelocity;


    /// H     I want the hight
    /// Vx (footSpeed) velocity forward  
    /// Th(TimeToPeak)
    /// 
    /// g, 
    /// V0 velocity direction
    /// Xh(DistanceToPeak)
  
    void Start()
    {
        jumpReset = numberOfJumps;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControlJumpParamaters();
        CheckIfGrounded();

        if (rb.velocity.y <= 0.1)
        {
            Physics.gravity = new Vector3(0, gravity* multiplyGravity, 0);

        }
        else Physics.gravity = new Vector3(0, -9.81f, 0);
    }

     void ControlJumpParamaters()
    {
        // controll high + distance + speed of the jump
        initalVelocity = 2 * jumpHight/ jumpDuration;
        gravity = -2 * jumpHight / (jumpDuration * jumpDuration);
    }
    private void CheckIfGrounded()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.GetComponent<CapsuleCollider>().bounds.center, Vector3.down, Color.red);
        if (Physics.Raycast(transform.GetComponent<CapsuleCollider>().bounds.center, Vector3.down, out hit, 1.2f))
        {
            if (hit.transform.tag == "Ground" && rb.velocity.y <= 0)
            {
                Debug.Log(hit.transform.tag);
                numberOfJumps = jumpReset;

            }

        }
    }
    private void Jump()
    {
        if (numberOfJumps > 0) { 
        rb.velocity = new Vector3(rb.velocity.x,initalVelocity, rb.velocity.z);
        }
    }

    public void OnNotify(StartEvent action)
    {

        if(action== StartEvent.jumping)
        {
            Debug.Log("Jump()");
            Jump();
            numberOfJumps--;
           

        }


    }


    private void OnEnable()
    {
        subject.AddObserver(this);
    }
    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }

}
