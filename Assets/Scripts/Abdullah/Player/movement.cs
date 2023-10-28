using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Control player Movement and speed
/// </summary>

public class movement : MonoBehaviour, IObserver
{
    Camera cam;

    [SerializeField] Subject subject;
    float xMovement, zMovement;
    Rigidbody rb;

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

        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    void Update()
    {
        initialVelocity = rb.velocity;
        //Math haha
        deceleration = (finalVelocity - initialVelocity / slowDowntime * Time.deltaTime);
        rb.velocity += deceleration;
    }
    void Moving()
    {
        zMovement = Input.GetAxisRaw("Horizontal");
        xMovement = Input.GetAxisRaw("Vertical");
        moving = transform.forward * xMovement + transform.right * zMovement;
        rb.velocity += moving * 10 * (speed * Time.deltaTime);

        LimitSpeed(speedLimit);


    }

    public void OnNotify(StartEvent action)
    {
        if (action == StartEvent.walking)
        {
            Moving();
        }
        else if (action == StartEvent.lookingAround)
        {
            LookingAround();
        }

    }

    void LookingAround()
    {
        float y = Input.GetAxisRaw("Mouse Y") ;
        float x = Input.GetAxisRaw("Mouse X") ;
        xMouse -= y;
        yMouse += x;
        xMouse =Mathf.Clamp(xMouse,-90f,90f);

        cam.transform.rotation= Quaternion.Euler(xMouse, yMouse, 0f);
        transform.rotation= Quaternion.Euler(transform.rotation.x, yMouse, transform.rotation.z);
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

