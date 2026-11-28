using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
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
    //Facing Direction variable
    private FacingDirection currentFacingDirection;
    //Raycasting to check for isGrounded
    private float raycastLengthForGroundCheck;//raycast length = playerlength / 2 + small number
    public float playerLength;
    public float raycastSmallNumber;
    public RaycastHit2D groundHit;
    public LayerMask groundLayerMask;

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

        //debuging
        //Debug.Log("Player's linear velocity" + playerRB.linearVelocity);
        raycastLengthForGroundCheck = playerLength / 2 + raycastSmallNumber;
        Debug.DrawRay(transform.position, Vector2.down * raycastLengthForGroundCheck, Color.red);
        Debug.Log(IsGrounded());

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
            ////Deceleration for when going left, where deceleration needs to add to velocity.x to return to 0
            //if (newVelocity.x < 0)
            //{
            //    newVelocity.x += deceleration * Time.deltaTime;
            //}
            ////deceleration for when going right, where deceleration needs to subtract to velocity.x to return to 0
            //else if (newVelocity.x > 0)
            //{
            //    newVelocity.x -= deceleration * Time.deltaTime;

            //New Deceleration logic
            newVelocity.x = Mathf.MoveTowards(newVelocity.x, 0, deceleration * Time.deltaTime);
            
            
        }

        //Maximum speed. Restricts movement to max speed. -maxSpeed is for moving left 
        newVelocity.x = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);

        playerRB.linearVelocity = newVelocity;

    }

    public bool IsWalking()
    {
        if (playerRB.linearVelocity.x == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsGrounded()
    {
        //Raycast to check ifGrounded
        groundHit = Physics2D.Raycast(transform.position, Vector2.down, raycastLengthForGroundCheck, groundLayerMask);

        return groundHit.collider != null;
    }

    public FacingDirection GetFacingDirection()
    {
        if(playerRB.linearVelocity.x < 0)
        {
            currentFacingDirection = FacingDirection.left;
        } 
        else if(playerRB.linearVelocity.x > 0)
        {
            currentFacingDirection = FacingDirection.right;
        }

        return currentFacingDirection;
       
        
    }
}
