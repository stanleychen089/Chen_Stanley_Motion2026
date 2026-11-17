using UnityEngine;
using UnityEngine.InputSystem;

public class FinalPlayer : MonoBehaviour
{
    //Deceleration Variables
    public float decelerationTime;
    public float decelerationRate;
    public float maxSpeed;
    public Vector3 currentVelocity;
    //Spacebar booster
    public float abilityAcceleration;
    public float boosterChargeRate;
    public float maxBoosterTime; 
    public float boosterTime;
    public bool isBoosting; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DecelerationRate calculation
        decelerationRate = maxSpeed / decelerationTime;
    }

    // Update is called once per frame
    void Update()
    {

        //Spacebar to activate ability 
        if (Keyboard.current.spaceKey.isPressed)
        {
            PlayerBoosterCharge();
        }
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            PlayerBoosterActivate();
        }

        PlayerMovement();
        PlayerRotation();
    }
    public void PlayerBoosterCharge()
    {
        abilityAcceleration += Time.deltaTime * boosterChargeRate;
        boosterTime += Time.deltaTime;
        if(boosterTime > maxBoosterTime)
        {
            boosterTime = maxBoosterTime;
        }
        
    }

    public void PlayerBoosterActivate()
    {
        Vector3 forwardDirection = transform.up;
        
        if(boosterTime > 0)
        {
            isBoosting = true; 
            currentVelocity += forwardDirection * abilityAcceleration;

            abilityAcceleration = 0;
        }
        
    }

    public void PlayerMovement()
    {
        //Line for moving the player position based on velocity 
        transform.position += currentVelocity * Time.deltaTime;


        //If boosting is happening, then boost time will gradually decrease until it hits zero
        if (isBoosting)
        {
            boosterTime -= Time.deltaTime;
            if(boosterTime <= 0)
            {
                boosterTime = 0;
                isBoosting = false;
            }
        }

        //if boosting is not happening, start decelerating
        //if (!isBoosting)
        //{
        //    currentVelocity -= currentVelocity.normalized * decelerationRate * Time.deltaTime;
        //    if (currentVelocity.magnitude <= 0)
        //    {
        //        currentVelocity = currentVelocity.normalized * 0;
        //    }
        //}
    }
    public void PlayerRotation()
    {
        float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg;

        Vector3 facingDirection = transform.eulerAngles;

        facingDirection.z = angle - 90;

        transform.eulerAngles = facingDirection;
    }

}
