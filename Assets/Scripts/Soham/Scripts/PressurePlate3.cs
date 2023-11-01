using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate3 : MonoBehaviour
{
    [SerializeField] private Material pressurePlate3Material;

    [SerializeField] public bool pressurePlate3;


    private void Start()
    {
        pressurePlate3Material.color = Color.white;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Robot"))
        {
            pressurePlate3 = true;
            pressurePlate3Material.color = Color.red;
        }

        if(other.gameObject.CompareTag("Player"))
        {
            pressurePlate3 = true;
            pressurePlate3Material.color = Color.red;
        }

        if(other.gameObject.CompareTag("Box"))
        {
            pressurePlate3 = true;
            pressurePlate3Material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            pressurePlate3 = false;
            pressurePlate3Material.color = Color.white;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            pressurePlate3 = false;
            pressurePlate3Material.color = Color.white;
        }

        if (other.gameObject.CompareTag("Box"))
        {
            pressurePlate3 = false;
            pressurePlate3Material.color = Color.white;
        }
    }
}
