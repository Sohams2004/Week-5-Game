using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate4 : MonoBehaviour
{
    [SerializeField] private Material pressurePlate4Material;

    [SerializeField] public bool pressurePlate4;


    private void Start()
    {
        pressurePlate4Material.color = Color.white;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Robot"))
        {
            pressurePlate4 = true;
            pressurePlate4Material.color = Color.red;
        }

        if(other.gameObject.CompareTag("Player"))
        {
            pressurePlate4 = true;
            pressurePlate4Material.color = Color.red;
        }

        if(other.gameObject.CompareTag("Box"))
        {
            pressurePlate4 = true;
            pressurePlate4Material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            pressurePlate4 = false;
            pressurePlate4Material.color = Color.white;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            pressurePlate4 = false;
            pressurePlate4Material.color = Color.white;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            pressurePlate4 = false;
            pressurePlate4Material.color = Color.white;
        }
    }
}
