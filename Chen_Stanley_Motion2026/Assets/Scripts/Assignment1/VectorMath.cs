using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        DrawSquare(mousePos, 5, Color.red, 0.5f);

        Vector3 upDirection = Vector3.up;

        float magnitudeOfUpDirection = upDirection.magnitude;
        Vector2 normalizedUpDirection = upDirection.normalized;

        //Distance from origin to upDirection
        float distanceToUpDirection = Vector2.Distance(upDirection, Vector2.zero);
    }

    public static Vector2 GetNormalizedVector(Vector2 vector)
    {
        float sizeOfVector = GetMagnitude(vector);
        Vector2 normalizedVector = new Vector2(vector.x / sizeOfVector, vector.y / sizeOfVector);

        return normalizedVector;
    }

    public static float GetMagnitude(Vector2 vector)
    {
        return Mathf.Sqrt(vector.x*vector.x + vector.y*vector.y);
    }

    public static void DrawSquare(Vector2 centerPoint, float size, Color color, float duration)
    {
        //Four corners of the square
        //Top left corner
        Vector2 topLeft = centerPoint + new Vector2(-size, size);

        //Top right corner
        Vector2 topRight = centerPoint + new Vector2(size, size);

        //Bottom left corner
        Vector2 bottomLeft = centerPoint + new Vector2(-size, -size);

        //Bottom right corner
        Vector2 bottomRight = centerPoint + new Vector2(size, -size);
        
        //Center of square
        //Color
        //Duration of square's existence

        //Top side
        Debug.DrawLine(topLeft, topRight, color, duration);
        //Right side
        Debug.DrawLine(topRight, bottomRight, color, duration);
        //Bottom side
        Debug.DrawLine(bottomRight, bottomLeft, color, duration);
        //Left side
        Debug.DrawLine(bottomLeft, topLeft, color, duration);


    }
}
