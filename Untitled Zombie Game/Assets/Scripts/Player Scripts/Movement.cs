using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Character Controller")]
    [Tooltip("The Object that holds the Character Controller."), SerializeField]
    private CharacterController Controller;

    [Header("Movement")]
    [Tooltip("Walking speed."), SerializeField]
    private float speed = 3f;
    [Tooltip("Sprinting speed."), SerializeField]
    private float sprintspeed = 6f;
    [Tooltip("Height of jumps."), SerializeField]
    private float Jumpheight = 1;
    [Tooltip("Speed of gravity."), SerializeField]
    private float gravity = -9.81f;
    [Tooltip("Distance the ground is defined from the player."), SerializeField]
    private float groundDistance = 0.1f;
    [Tooltip("Layer for what is considered the ground (I.E. Jumpable from)."), SerializeField]
    private LayerMask groundMask;
    [Tooltip("Transform that checks the player is touching the ground."), SerializeField]
    private Transform groundCheck;
    [Tooltip("True while player is touching ground."), SerializeField]
    private bool isGrounded;
    [Tooltip("True while player is not touching the ground."), SerializeField]
    private bool isJumping;
    [Tooltip("Velocity of the player."), SerializeField]
    private Vector3 velocity;
    
    [Header("Audio")]
    [Tooltip("Sound that plays while walking."), SerializeField]
    private AudioSource WalkSound;
    [Tooltip("Sound that plays while sprinting."), SerializeField]
    private AudioSource SprintSound;
    [Tooltip("Sound that plays while jumping."), SerializeField]
    private AudioSource JumpSound;
    [Tooltip("Soudn that plays while landing."), SerializeField]
    private AudioSource LandSound;
    [Tooltip("How slow the Walk speeds play."), SerializeField]
    private float WalkDistance = .58f;
    [Tooltip("How slow the Sprint speed plays."), SerializeField]
    private float SprintDistance = .27f;
    [Tooltip("Time between steps.")]
    private float TimeBetween;
    [Tooltip("How far the pitch may deviates each step sound."), SerializeField]
    private float PitchMinMax =1f;

    // Update is called once per frame
    void Update()
    {
        //Handles movement
        PlayerMovement();
        //Handles gravity
        Gravity();
        //Handles audio for jumping and landing
        LandingAudio();
    }
    //Update is called at a regular time every frame(s)
    void FixedUpdate()
    {
        //Handles audio for steps
        if (isGrounded)
        {
            MovementAudio();
            if (SprintSound.isPlaying)
            {
                //Sprintsounds are constantly pitchshifted to sound more realistic
                SprintSound.pitch = UnityEngine.Random.Range(1.0f - PitchMinMax, 1.0f + PitchMinMax);

            }
            else
            {
                //Walksounds are constantly pitchshifted to sound more realistic
                WalkSound.pitch = UnityEngine.Random.Range(1.0f - PitchMinMax, 1.0f + PitchMinMax);
            }
        }
    }
    //Handles player movement in each dimension
    void PlayerMovement()
    {
        //Variables for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Sets the move variable to the inputs
        Vector3 move = transform.right * x + transform.forward * z;
        //If the player is not holding down shift, walk
        if (!Input.GetButtonDown("Left Shift"))
        {
            if (move.sqrMagnitude > 1)
            {
                move.Normalize();
            }
            Controller.Move(move * speed * Time.deltaTime);
        }
        //If the player is holding down shift, sprint
        if (Input.GetButton("Left Shift"))
        {
            if (move.sqrMagnitude > 1)
            {
                move.Normalize();
            }
            Controller.Move(move * sprintspeed * Time.deltaTime);
        }

        //While the player is grounded, jump and play sound
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(Jumpheight * -2f * gravity);
            JumpSound.Play();
            isJumping = true;
        }
        
    }
    //Recreates gravity for the player
    void Gravity()
    {
        //Moves player at the speed of gravity exponentially downwards
        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);

        //While the player is grounded, reset gravity so their velocity doesnt infinitely build up when it shouldn't
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }
    //Handles FX related to the movement system sans landing
    void MovementAudio()
    {
        //while the player is moving
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            //if they are sprinting, use the sprint sound and turn off the walk sound if it is playing
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
            //otherwise, play the walk sound
            else
            {
                TimeBetween += Time.deltaTime;
                if (TimeBetween > WalkDistance)
                {
                    WalkSound.Play();
                    TimeBetween = 0f;
                }
            }
        }
        //if the player is not in movement, halt both sounds from playing
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            if (WalkSound.isPlaying || SprintSound.isPlaying)
            {
                SprintSound.Stop();
                WalkSound.Stop();
            }
        }

    }
    //handles landing audio fx
    void LandingAudio()
    {
        if (isJumping && !JumpSound.isPlaying)
        {
            if (isGrounded)
            {
                LandSound.Play();
                isJumping = false;
            }
        }
    }
}
