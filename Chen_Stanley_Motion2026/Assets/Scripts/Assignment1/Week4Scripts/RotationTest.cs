using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float redAngle;
    public float blueAngle; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 facingDirection = transform.up;
        float facingAngle = AngleTest.VectorToAngle(facingDirection);

        //Debug.Log(facingAngle);
       // Debug.Log(transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 redVector = new Vector3(Mathf.Cos(redAngle * Mathf.Deg2Rad), Mathf.Sin(redAngle * Mathf.Deg2Rad));
        Vector3 blueVector = new Vector3(Mathf.Cos(blueAngle * Mathf.Deg2Rad), Mathf.Sin(blueAngle * Mathf.Deg2Rad));

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        Debug.Log(VectorDot(redVector, blueVector));
    }

    public static float VectorDot(Vector3 a, Vector3 b)
    {
        float dotProduct = a.x * b.x + a.y * b.y;

        return dotProduct;
    }
}
