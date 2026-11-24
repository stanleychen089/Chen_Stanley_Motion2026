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

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
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
            newVelocity += playerInput.x * Vector2.right * acceleration * Time.deltaTime;
        }
        else
        {
            //Decelerate/stop moving 
        }

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
