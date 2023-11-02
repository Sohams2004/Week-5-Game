using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : DoorsOpen
{
    //[SerializeField] private GameObject pressurePlate;

    [SerializeField] private Material pressurePlate1Material;

    private void Start()
    {
        pressurePlate1Material.color = Color.white;  
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Pressure plate activated");
            PressurePlate1();
            Door1Open();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Robot"))
        {
            pressurePlate1Material.color = Color.white;
        }
    }

    void PressurePlate1()
    {
        pressurePlate1Material.color = Color.red;
    }

    void PressurePlate2()
    {

    }

    void PressurePlate3()
    {

    }

    void PressurePlate4()
    {

    }
}
