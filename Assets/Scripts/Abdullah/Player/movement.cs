using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Control player Movement and speed
/// </summary>

public class movement : MonoBehaviour, IObserver
{
    Camera cam;
    float rotateX, rotateXNeg;
    [SerializeField] Transform camPosition;
    [SerializeField] Transform camRotate;
    [SerializeField] Subject subject;
    float xMovement, zMovement;
    Rigidbody rb;
    Vector2 movements,lookAround;

    Vector3 deceleration;
    Vector3 initialVelocity;
    Vector3 finalVelocity = new Vector3(0, 0, 0);
    Vector3 moving;

    [SerializeField] float slowDowntime = 0.2f;
    [SerializeField] float speed = 10;
    [SerializeField] float speedLimit = 10;

    float xMouse,yMouse;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cam = Camera.main;

    }
    void Update()
    {
        initialVelocity = rb.velocity;

        //Math haha
        deceleration = (finalVelocity - initialVelocity / slowDowntime * Time.deltaTime);
        rb.velocity += deceleration;

    }

    private void OnLookAround(InputValue value)
    {
        lookAround = value.Get<Vector2>();
        rotateX += lookAround.x* 15 * Time.deltaTime;
        Debug.Log("LookAround");

        camRotate.rotation = Quaternion.Euler(camRotate.rotation.x, rotateX*10, camRotate.rotation.z);
    }
    private void OnMove(InputValue value)
    {
        movements = value.Get<Vector2>();
        Debug.Log("OnMove");
        Moving();
    }
    void Moving()
    {
        xMovement = movements.y  ;
        zMovement = movements.x  ;

        moving = camPosition.forward * xMovement + camPosition.right * zMovement;
        rb.velocity += moving * 10 * (speed * Time.deltaTime);
        LimitSpeed(speedLimit);


    }

    
    public void OnNotify(StartEvent action)
    {
        if (action == StartEvent.walking)
        {

        }
        else if (action == StartEvent.lookingAround)
        {
          //  LookingAround();
        }

    }

    void LimitSpeed(float speed)
    {
        if (rb.velocity.x > speed) rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        else if (rb.velocity.x < -speed) rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.z > speed) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        else if (rb.velocity.z < -speed) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
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

