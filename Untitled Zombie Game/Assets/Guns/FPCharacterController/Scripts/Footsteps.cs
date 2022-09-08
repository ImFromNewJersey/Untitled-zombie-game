using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public CharacterController Controller;
    public AudioSource WalkSound;
    public AudioSource SprintSound;
    public AudioSource JumpSound;
    public AudioSource LandSound;
    public float WalkDistance = .65f;
    public float SprintDistance = .80f;
    private float TimeBetween;
    public float PitchMinMax;
    public Movement MovementScript;
    bool isJumping;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (MovementScript.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                JumpSound.Play();
                isJumping = true;
            }
        }
        if (isJumping && !JumpSound.isPlaying)
        {
            if (MovementScript.isGrounded)
            {
                LandSound.Play();
                isJumping = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (MovementScript.isGrounded)
        {
            Step();
        }

            if (WalkSound.isPlaying)
        {
            WalkSound.pitch = UnityEngine.Random.Range(1.0f - PitchMinMax, 1.0f + PitchMinMax);
        }
        if (SprintSound.isPlaying)
        {
            SprintSound.pitch = UnityEngine.Random.Range(1.0f - PitchMinMax, 1.0f + PitchMinMax);

        }
    }
    void Step()
    {

        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            if (WalkSound.isPlaying || SprintSound.isPlaying)      
            {
                SprintSound.Stop();
                WalkSound.Stop();
            }
        }
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (Input.GetButton("Left Shift"))
            {
                TimeBetween += Time.deltaTime;
                if (TimeBetween > SprintDistance)
                {
                    if (WalkSound.isPlaying)
                    {
                        WalkSound.Stop();
                    }
                    SprintSound.Play();
                    TimeBetween = 0f;
                }
            }
            if (!Input.GetButton("Left Shift"))
            {
                TimeBetween += Time.deltaTime;
                if (TimeBetween > WalkDistance)
                {
                    WalkSound.Play();
                    TimeBetween = 0f;
                }
            }
        }

    }

}


