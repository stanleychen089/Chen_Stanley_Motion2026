using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public Rigidbody2D playerRB;
    public float accelerationTime;
    private float acceleration; //acceleration = maxSpeed / accelerationTime

    public enum FacingDirection
    {
        left, right
    }

    //Week 11 Jumping Variables
    public float apexHeight;
    public float apexTime;
    float gravity;
    float initialJumpVelocity;
    private bool wasJumpTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;

        gravity = -2 * apexHeight / (apexTime * apexTime);
        initialJumpVelocity = 2 * apexHeight / apexTime;
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }
        MovementUpdate(playerInput);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            wasJumpTriggered = true;
        }


    }

    private void MovementUpdate(Vector2 playerInput)
    {
        //Stores the velocity stored inside the player's rigidbody into a new vector3 
        //Player's rigidbody's velocity detects collisions, which is why the vector should--
        //--track the velocity from rigidboy as opposed to the a velocity vector that stores acceleration
        Vector2 newVelocity = playerRB.linearVelocity;

        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput.x * Vector2.right * acceleration * Time.deltaTime;
        }
        else
        {
            //Decelerate/stop moving 
        }


        //Jumping
        Vector2 currentVelocity = playerRB.linearVelocity;
        //appy the gravity that we calculate over time 
        currentVelocity.y += gravity * Time.deltaTime;

        //Once the player presses input for jump, they will obtain the velocity into the air
        //Only jump if player is grounded 

        if (wasJumpTriggered)
        {
            currentVelocity.y = initialJumpVelocity;
            wasJumpTriggered = false;
        }

        playerRB.linearVelocity = newVelocity;
    }

    //week 10 horizontal movement
    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }

    //week 11 jumping
}
