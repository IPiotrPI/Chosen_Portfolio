using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Person_Controller : MonoBehaviour
{
    #region Variables
    public CharacterController _controller;
    public Transform _mainCamera;
    public IDirectionDictionary _directions;

    public float speed = 6f;

    public float turnSmoothTime = 0.01f;
    float turnSmoothVelocity;

    Vector2 _mouseAxis;
    #endregion

    public void Start()
    {
        _directions = gameObject.AddComponent<Directions_Dictionary>();
    }

    #region  GetKeyDirection
    /*
     * METHOD: Calculate movement of character based on:
     * DIRECTION CHARACTER IS FACING
     * DIRECTION WHERE CHARACTER IS MOVING
     * ANGLE WHICH CHARACTER IS ROTATED
     */
    public string GetKeyDirection(string _directionName, Vector3 moveDir, float angle)
    {
        string _keyToReturn = _directions.CURRENT_DIRECTION().Key;
        if (_keyToReturn == _directionName)
        {
            _controller.Move(moveDir.normalized * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        else
        {
            _controller.Move(Vector3.zero);
            Debug.Log("I will not move");
        }
        return _keyToReturn;
    }
    #endregion

    #region CameraControll
    public void MovementUsingDirections()
    {
        #region variables
        _mouseAxis.y = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        #endregion
       
        if (Input.GetKey("w"))
        {
            _directions.FORWARD();
            GetKeyDirection("FORWARD", moveDir, angle);
        }
        else if (Input.GetKey("s"))
        {
            _directions.BACKWARD();
            GetKeyDirection("BACKWARD", moveDir, targetAngle - 180);

        }
        else if (Input.GetKey("d"))
        {
            _directions.RIGHT();
            GetKeyDirection("RIGHT", moveDir, targetAngle);
        }
        else if (Input.GetKey("a"))
        {
            _directions.LEFT();
            GetKeyDirection("LEFT", moveDir, targetAngle);
        }
        //No direction
        else if (direction.magnitude == 0)
        {
            transform.rotation = Quaternion.Euler(0f, angle + _mouseAxis.y, 0f);
        }
      
    }
    #endregion

    void Update()
    {
        MovementUsingDirections();
    }
}
