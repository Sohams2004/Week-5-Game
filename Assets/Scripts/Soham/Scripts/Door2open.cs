using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2open : MonoBehaviour
{
    [SerializeField] private PressurePlate2 pressurePlate2;
    [SerializeField] private PressurePlate3 pressurePlate3;
    [SerializeField] private PressurePlate4 pressurePlate4;

    [SerializeField] private GameObject door_2;

    void Door2Open()
    {
        if(pressurePlate2.pressurePlate2 == true)
        {
            if(pressurePlate3.pressurePlate3  == true) 
            {
                if(pressurePlate4.pressurePlate4 == true)
                    door_2.SetActive(false);
            }
        }
    }

    private void Update()
    {
        Door2Open();
    }
}
