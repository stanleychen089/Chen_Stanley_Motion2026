using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> lookerLocations;
    public int currentLookerIndex = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //A Vector that tracks the positions of the gameObjects within the public list, which consists the desired locations we want the looker to look at 
        Vector3 lookerPositions = lookerLocations[currentLookerIndex].transform.position;

        //A vector that calculates the direction vector from the looker's position to the target locations
        //Otherwise, the looker will look at the targets from the position of the origin
        Vector3 lookerToTargetDirection = lookerPositions - transform.position;

        LookerLocationPoints(lookerToTargetDirection);
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            NextLookerLocation();
        }
    }

    public void NextLookerLocation()
    {
        currentLookerIndex++;
        if (currentLookerIndex > lookerLocations.Count -1)
        {
            currentLookerIndex = 0;
        }

        Debug.Log(currentLookerIndex);
    }

    public void LookerLocationPoints(Vector3 lookerPoints)
    {
        //A float that obtains the angle in degrees of target locations from the origin  
        float angle = Mathf.Atan2(lookerPoints.y, lookerPoints.x) * Mathf.Rad2Deg;

        //A vector that stores the looker's rotation 
        //We cannot directly manipulate a tranform's component, so we have to store the component in variable so we can then manipulate the variable
        Vector3 facingDirection = transform.eulerAngles;

        //We set the vector's z component, representing the transform's eulerAngles.z 
        facingDirection.z = angle - 90;

        //The final line that sets the transform's rotation to our variable, which contains the desired rotation direction 
        transform.eulerAngles = facingDirection;

    }
}
