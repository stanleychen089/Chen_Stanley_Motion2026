using UnityEngine;

public class Turrent : MonoBehaviour
{
    public Transform targetTransform;
    public float angularSpeed;

    public bool turnRight = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, targetTransform.position, Color.red);

        Vector3 directionToTarget = targetTransform.position - transform.position;

        //Determine if turrent should turn left or right when turning towards the target
        //If dotProduct > 0, the target is on the right, otherwise its on the left of the turrent
        float dotProductOfRight = RotationTest.VectorDot(directionToTarget, transform.right);
        turnRight = dotProductOfRight > 0;

        if (turnRight)
        {
            transform.eulerAngles -= transform.forward * angularSpeed * Time.deltaTime;
        }
        else
        {
            transform.eulerAngles += transform.forward * angularSpeed * Time.deltaTime;
        }
    }
}
