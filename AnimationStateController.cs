using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    #region Variables
    public Animator animator;
    IDirectionDictionary _directions;
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        _directions = gameObject.AddComponent<Directions_Dictionary>();
    }

    public void ResetAnimator()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingBackwards", false);
        animator.SetBool("isWalkingLeft", false);
        animator.SetBool("isWalkingRight", false);
        animator.SetFloat("VelocityZ", 0);
        animator.SetFloat("VelocityX", 0);
    }

    private void PlayerInputHandler()
    {
        //Sets the animator components in response to player input using Dictionary of Directions
        if (Input.GetKey("w"))
        {
            animator.SetFloat("VelocityX", _directions.FORWARD().Key);
            animator.SetBool("isWalking", _directions.FORWARD().Value);
        }
        else if (Input.GetKey("s"))
        {
            animator.SetBool("isWalkingBackwards", _directions.BACKWARD().Value);
            animator.SetFloat("VelocityX", _directions.BACKWARD().Key);
        }
        else if (Input.GetKey("d"))
        {
            animator.SetBool("isWalkingRight", _directions.RIGHT().Value);
            animator.SetFloat("VelocityZ", _directions.RIGHT().Key);
        }     
        else if (Input.GetKey("a"))
        {
            animator.SetBool("isWalkingLeft", _directions.LEFT().Value);
            animator.SetFloat("VelocityZ", _directions.LEFT().Key);
        }
        else
        {
            ResetAnimator();
        }
    }

    void Update()
    {
        PlayerInputHandler();
    }

   
}
