using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Controller : MonoBehaviour, IDashController
{
    public float Dash_Speed;
    //Used to referance current movement
    public Third_Person_Controller _directionBrain;

    public KeyValuePair<Vector3, float> Dash_Movement_DIrection(string _currentDirection)
    {
        Debug.Log("I am working!");
        throw new System.NotImplementedException();
    }

    public float Speed()
    {
        throw new System.NotImplementedException();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
