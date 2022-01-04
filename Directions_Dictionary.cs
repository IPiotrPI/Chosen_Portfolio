using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Directions dictionary class serves as container for the directions
 * and point of referance for all other classes on where character is facing
 */

public class Directions_Dictionary : MonoBehaviour, IDirectionDictionary
{
    #region variables
    public IDictionary Directions = new Dictionary<string, float>();
    public KeyValuePair<string, float> Direction;
    #endregion

    #region Add directions
    public Directions_Dictionary()
    {
        Directions.Add("FORWARD", 1f);
        Directions.Add("BACKWARD", -1f);
        Directions.Add("RIGHT", 1f);
        Directions.Add("LEFT", -1f);
        Directions.Add("FORWARD-RIGHT", 2f);
        Directions.Add("FORWARD-LEFT", 1f);
        Directions.Add("BACKWARD-RIGHT", 1f);
        Directions.Add("BACKWARD-LEFT", -2f);
        Directions.Add("NO-MOVEMENT", 0f);

    }
    #endregion

    #region METHODS TO ACCESS DICTIONARY
    public KeyValuePair<float, bool> FORWARD()
    {
        //Change the current direction to the one searched for
        Direction = new KeyValuePair<string, float>("FORWARD", 1f);
        float velocity = (float)Directions["FORWARD"];
        //if Key was changed to the one this methods controlls
        if (velocity >= 0f)
        {
            //turn the flag on, we are going forward to controll the animator
            bool _amIgoingForward = true;
            KeyValuePair<float, bool> directionToGo = new KeyValuePair<float, bool>(velocity, _amIgoingForward);
            return directionToGo;
        }
        else
        {
            Debug.Log("I AM NOT CONNECTING FORWARD");
            throw new System.NotImplementedException();
        }
    }

    public KeyValuePair<float, bool> BACKWARD()
    {
        Direction = new KeyValuePair<string, float>("BACKWARD", -1f);
        float velocity = (float)Directions["BACKWARD"];
        //Only differance in code between those methods is Velocity check below and Direction game is searching for above
        if (velocity <= 0f)
        {
            bool _amIgoingBackward = true;
            KeyValuePair<float, bool> directionToGo = new KeyValuePair<float, bool>(velocity, _amIgoingBackward);
            return directionToGo;
        }
        else
        {
            Debug.Log("I AM NOT CONNECTING BACKWARD");
            throw new System.NotImplementedException();
        }
    }

    public KeyValuePair<float, bool> RIGHT()
    {
        Direction = new KeyValuePair<string, float>("RIGHT", 1f);
        float velocity = (float)Directions["RIGHT"];
        if (velocity >= 0f)
        {
            bool _amIgoingRight = true;
            KeyValuePair<float, bool> directionToGo = new KeyValuePair<float, bool>(velocity, _amIgoingRight);
            return directionToGo;
        }
        else
        {
            Debug.Log("I AM NOT CONNECTING RIGHT");
            throw new System.NotImplementedException();
        }
    }

    public KeyValuePair<float, bool> LEFT()
    {
        Direction = new KeyValuePair<string, float>("LEFT", -1f);
        float velocity = (float)Directions["LEFT"];
        if (velocity <= 0f)
        {
            bool _amIgoingLeft = true;
            KeyValuePair<float, bool> directionToGo = new KeyValuePair<float, bool>(velocity, _amIgoingLeft);
            return directionToGo;
        }
        else
        {
            Debug.Log("I AM NOT CONNECTING FORWARD");
            throw new System.NotImplementedException();
        }
    }
    public KeyValuePair<float, bool> FOR_RIGHT()
    {
        float velocity = (float)Directions["FORWARD-RIGHT"];
        if (velocity > 1f)
        {
            bool _amIgoingForRight = true;
            KeyValuePair<float, bool> directionToGo = new KeyValuePair<float, bool>(velocity, _amIgoingForRight);
            return directionToGo;
        }
        else
        {
            Debug.Log("I AM NOT CONNECTING FORWARD");
            throw new System.NotImplementedException();
        }
    }
    public KeyValuePair<string, float> CURRENT_DIRECTION() { return Direction; }

    #region directions not assigned, left open for extension
    public KeyValuePair<float, bool> FOR_LEFT()
    {
        throw new System.NotImplementedException();
    }

    public KeyValuePair<float, bool> BACK_RIGHT()
    {
        throw new System.NotImplementedException();
    }

    public KeyValuePair<float, bool> BACK_LEFT()
    {
        throw new System.NotImplementedException();
    }

    public KeyValuePair<float, bool> NO_MOVEMENT()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #endregion
}
