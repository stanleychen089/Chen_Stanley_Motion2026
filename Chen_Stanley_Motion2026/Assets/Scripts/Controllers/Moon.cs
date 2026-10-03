using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitSpeed; // degree per second 
    public float orbitDistance;
    public Transform orbitTargetTransform;
    public float currentAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitDistance, orbitSpeed, orbitTargetTransform);
    }
    void OrbitalMotion(float radius, float speed, Transform target)
    {
        //Speed in which degrees increase per second
        currentAngle += speed * Time.deltaTime;


        float radiansPerSecond = currentAngle * Mathf.Deg2Rad;

        float orbitPointX = Mathf.Cos(radiansPerSecond);
        float orbitPointY = Mathf.Sin(radiansPerSecond);
        Vector3 orbitPoint = new Vector3(orbitPointX, orbitPointY) * radius + target.position; 
        transform.position = orbitPoint;

        Debug.Log(currentAngle);
    }
}
