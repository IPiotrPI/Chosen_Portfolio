using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionDictionary
{
    /*
     * Set of methods used to manipulate directions
     */
    public KeyValuePair<float, bool> FORWARD();

    public KeyValuePair<float, bool> BACKWARD();

    public KeyValuePair<float, bool> RIGHT();

    public KeyValuePair<float, bool> LEFT();

    public KeyValuePair<float, bool> FOR_RIGHT();

    public KeyValuePair<float, bool> FOR_LEFT();

    public KeyValuePair<float, bool> BACK_RIGHT();

    public KeyValuePair<float, bool> BACK_LEFT();

    public KeyValuePair<float, bool> NO_MOVEMENT();

    public KeyValuePair<string, float> CURRENT_DIRECTION();



}
