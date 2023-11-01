using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate2 : MonoBehaviour
{
    [SerializeField] private Material pressurePlate2Material;

    [SerializeField] public bool pressurePlate2;


    private void Start()
    {
        pressurePlate2Material.color = Color.white;
    }
    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Robot"))
        {
            pressurePlate2 = true;
            pressurePlate2Material.color = Color.red;
        }

        if(other.gameObject.CompareTag("Player"))
        {
            pressurePlate2 = true;
            pressurePlate2Material.color = Color.red;
        }

        if(other.gameObject.CompareTag("Box"))
        {
            pressurePlate2 = true;
            pressurePlate2Material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            pressurePlate2 = false;
            pressurePlate2Material.color = Color.white;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            pressurePlate2 = false;
            pressurePlate2Material.color = Color.white;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            pressurePlate2 = false;
            pressurePlate2Material.color = Color.white;
        }
    }
}
