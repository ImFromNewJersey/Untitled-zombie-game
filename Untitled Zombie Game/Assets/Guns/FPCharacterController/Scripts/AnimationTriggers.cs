using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    public Animator animator;
    public CharacterController Player;

    void Update()
    {
        if ((Input.GetButton("Vertical") || Input.GetButton("Horizontal")))
        {
            if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
            {
                animator.SetBool("IsWalking", true);
            }
            if (!Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
            {
                animator.SetBool("IsWalking", false);
            }
            if (Input.GetButton("Left Shift"))
            {
                animator.SetBool("IsSprinting", true);
            }
            if (!Input.GetButton("Left Shift"))
            {
                animator.SetBool("IsSprinting", false);
            }
        }
        else
        {
            animator.SetBool("IsSprinting", false);
            animator.SetBool("IsWalking", false);
        }
    }
}
