using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Subject2 : MonoBehaviour
{

    private List<RobotObserver> _observers = new List<RobotObserver>();


    public void AddObserver(RobotObserver observer)
    {

        _observers.Add(observer);
    }
    public void RemoveObserver(RobotObserver observer)
    {
        _observers.Remove(observer);
    }
    protected void NotifyObservers(RobotState action)
    {
        _observers.ForEach((_observer) =>
        {
           _observer.OnNotify(action);

       });

    }
    


}
