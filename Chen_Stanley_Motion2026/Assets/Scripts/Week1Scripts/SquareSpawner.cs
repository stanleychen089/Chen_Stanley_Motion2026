using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public float squareLength;
    public Color transparentColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //create a vector for each corner of the square with the mouse as the origin
        //the vector for each corner needs to follow the mouse constantly
        //connect the corners using another vector line
        Vector2 topRight = new Vector2(mousePos.x-squareLength, mousePos.y+squareLength);
        //Debug.DrawLine(mousePos, topRight); //Debug.DrawLine to check for correct position
        Vector2 topLeft = new Vector2(mousePos.x + squareLength, mousePos.y + squareLength);
        //Debug.DrawLine(mousePos, topLeft); //Debug.DrawLine to check for correct position
        Vector2 bottomRight = new Vector2(mousePos.x - squareLength, mousePos.y - squareLength);
       // Debug.DrawLine(mousePos, bottomRight);
        Vector2 bottomLeft = new Vector2(mousePos.x + squareLength, mousePos.y - squareLength);
       // Debug.DrawLine(mousePos, bottomLeft);

        //Now I can connect all the corners to create sides of the square
        //If player clicks right click, draw all the sides to create a square at current position
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Left side
            Debug.DrawLine(topLeft, bottomLeft, Color.white, 10);
            //Top side
            Debug.DrawLine(topRight, topLeft, Color.white, 10);
            //Right side
            Debug.DrawLine(topRight, bottomRight, Color.white, 10);
            //Bottom side
            Debug.DrawLine(bottomRight, bottomLeft, Color.white, 10);

        }

        //Transparent square that follows mouse
        Debug.DrawLine(topLeft, bottomLeft, transparentColor);
        //Top side
        Debug.DrawLine(topRight, topLeft, transparentColor);
        //Right side
        Debug.DrawLine(topRight, bottomRight, transparentColor);
        //Bottom side
        Debug.DrawLine(bottomRight, bottomLeft, transparentColor);

        
    }
}
