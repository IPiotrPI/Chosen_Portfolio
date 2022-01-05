using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDashController 
{
    //take current direction, return how and where to perform the dash
    public KeyValuePair<Vector3, float> Dash_Movement_DIrection(string _currentDirection);

    public float Speed();
}
