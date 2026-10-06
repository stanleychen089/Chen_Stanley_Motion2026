using System;
using UnityEditor.Rendering;
using UnityEngine;

public class PlanetMechanic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float orbitRadius;
    public float orbitSpeed;
    public float pullDistance;
    public Transform playerTransform;

    public bool enteredOrbit;
    public float pullSpeed;

    void Start()
    {
        pullDistance = orbitRadius;
    }

    // Update is called once per frame
    void Update()
    {
        WithinOrbitRadius();
    }

    public void WithinOrbitRadius()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance < orbitRadius)
        {
            PlanetaryOrbit();
            enteredOrbit = true;
            pullDistance -= pullSpeed * Time.deltaTime;
        }
        else
        {
            pullDistance = orbitRadius;
            enteredOrbit = false;
        }

        
    }

    public void PlanetaryOrbit()
    {
        
        Vector3 directionVector = playerTransform.position - transform.position;
        float angleOfOrbit = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
        //angleOfOrbit = Deg -> Manipulate speed by degrees 

        angleOfOrbit += orbitSpeed * Time.deltaTime;

        float radOfOrbit = angleOfOrbit * Mathf.Deg2Rad;

        float pointOfOrbitX = Mathf.Cos(radOfOrbit);
        float pointOfOrbitY = Mathf.Sin(radOfOrbit);
        Vector3 pointOfOrbit = new Vector3(pointOfOrbitX, pointOfOrbitY) * pullDistance + transform.position;

        playerTransform.position = pointOfOrbit;

        Debug.Log(angleOfOrbit);
    }
}
