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

    //deceleration variables
    private float deceleration;
    public float decelerationTime; 


    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime; 
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

    }

    private void MovementUpdate(Vector2 playerInput)
    {
        //Stores the velocity stored inside the player's rigidbody into a new vector3 
        //Player's rigidbody's velocity detects collisions, which is why the vector should--
        //--track the velocity from rigidboy as opposed to the a velocity vector that stores acceleration
        Vector2 newVelocity = playerRB.linearVelocity;

        if(playerInput.x != 0)
        {
            //accelerate
            //newVelocity += playerInput.x * Vector2.right * acceleration * Time.deltaTime;
            newVelocity.x += playerInput.x * acceleration * Time.deltaTime;

        }
        else
        {
            //Decelerate/stop moving 
            //Deceleration for when going left, where deceleration needs to add to velocity.x to return to 0
            if (newVelocity.x < 0)
            {
                newVelocity.x += deceleration * Time.deltaTime;
            }
            //deceleration for when going right, where deceleration needs to subtract to velocity.x to return to 0
            else if (newVelocity.x > 0)
            {
                newVelocity.x -= deceleration * Time.deltaTime;
            }
        }

        //Maximum speed. Restricts movement to max speed. -maxSpeed is for moving left 
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);

        playerRB.linearVelocity = newVelocity;

    }

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
}
