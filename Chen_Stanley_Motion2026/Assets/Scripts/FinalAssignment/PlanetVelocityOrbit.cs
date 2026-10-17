using UnityEngine;
using UnityEngine.InputSystem;

public class PlanetVelocityOrbit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float orbitRadius;
    public float orbitStrength;
    public Transform playerTransform;
    private FinalPlayer player;

    //Starting planet variables
    public float orbitSpeed;
    public bool isEarth;
    private float angleOfOrbit; 

    void Start()
    {
        player = playerTransform.GetComponent<FinalPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //If this planet is the starting planet, the player will rotate around the starting planet
        if (isEarth)
        {
            EarthOrbit();
            if (Keyboard.current.spaceKey.wasReleasedThisFrame)
            {
                isEarth = false;
            }
        }

        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance < orbitRadius)
        {
            //Normalized direction vector so the planet's pull stength is consistent no matter the distance
            Vector3 directionVector = (transform.position - playerTransform.position).normalized;

            player.currentVelocity += directionVector * orbitStrength * Time.deltaTime;
        }

        
    }

    void EarthOrbit()
    {
        //Angle that the player is currently at whilst rotating, updated by speed over time 
        angleOfOrbit += orbitSpeed * Time.deltaTime;

        //Calculating position of orbit at the angle of orbit, converted into Rads for calcs
        float radOfOrbit = angleOfOrbit * Mathf.Deg2Rad;

        //X and Y coordinates
        float pointOfOrbitX = Mathf.Cos(radOfOrbit);
        float pointOfOrbitY = Mathf.Sin(radOfOrbit);

        //Vector using X and Y coords + planet offset and the planet's radius 
        Vector3 pointOfOrbit = new Vector3(pointOfOrbitX, pointOfOrbitY) * orbitRadius + transform.position;

        playerTransform.position = pointOfOrbit;
        
        
    }
}
