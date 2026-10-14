using UnityEngine;

public class PlanetVelocityOrbit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float orbitRadius = 4;

    public float orbitStrength = 8;
    public Transform playerTransform;
    private FinalPlayer player; 
    void Start()
    {
        player = playerTransform.GetComponent<FinalPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance < orbitRadius)
        {
            Vector3 directionVector = transform.position - playerTransform.position;

            player.currentVelocity += directionVector * orbitStrength * Time.deltaTime;
        }
    }
}
