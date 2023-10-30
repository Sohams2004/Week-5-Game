using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate;

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Robot"))
        {
            Debug.Log("Pressure plate activated");
        }
    }
}
