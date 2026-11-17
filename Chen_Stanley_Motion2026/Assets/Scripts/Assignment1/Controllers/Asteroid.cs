using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public bool NeedDestination = true;
    public Vector3 newDestination;

    public float t = 0;



    // Start is called before the first frame update
    void Start()
    {
        NeedDestination = true;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {

        float distance;

        //float variables to make newDestination less bloated with text in constroctor 
        //new destination is based on random distance between current position + maxFloatDistance
        float randomX = Random.Range(transform.position.x - maxFloatDistance, transform.position.x + maxFloatDistance);
        float randomY = Random.Range(transform.position.y - maxFloatDistance, transform.position.y + maxFloatDistance);
        //Creates a new vector3 of a new destination if needed
        if (NeedDestination) 
        {
            newDestination = new Vector3(randomX, randomY);

            //New destination will not longer be needed after creatng one 
            NeedDestination = false;

        }

        //Checks if current position has arrived to new location 
        distance = Vector3.Distance(transform.position, newDestination);
        if (distance < arrivalDistance)
        {
            NeedDestination = true;
        }

        //Lerp
        t += moveSpeed * Time.deltaTime*0.001f;
        if (t > 1)
        {
            //Reset t if its over a second
            t = 0;
        }

        transform.position = Vector3.Lerp(transform.position, newDestination, t);
    

    }

}
