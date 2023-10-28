using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RobotObserver
{
    public void OnNotify(RobotState action);

}
