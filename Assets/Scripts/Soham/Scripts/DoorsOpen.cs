using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpen : MonoBehaviour
{
    [SerializeField] private GameObject door_1;

    public void Door1Open()
    {
        door_1.SetActive(false);
    }
}
