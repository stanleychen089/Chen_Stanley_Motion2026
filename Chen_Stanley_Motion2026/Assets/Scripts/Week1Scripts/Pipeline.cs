using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public Vector2 startingPos;
    public float t;
    public float pipelineLength = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        

        //An if condition that records the starting position of when the mouse is pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            startingPos = new Vector2(mousePos.x, mousePos.y);
            //Debug.Log(startingPos);
        }
        //An if condition that draws the initial position to the mouse's current position
        //Then draws a new line from the new position to the mouse's current position
        //a timer of 0.1 to draw a line every 0.1s
        if (Mouse.current.leftButton.isPressed)
        {
            t += Time.deltaTime;
            if (t > 0.1)
            {
                t = 0;
            }
            Debug.DrawLine(startingPos, mousePos);


        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Debug.Log("Length of pipe " + pipelineLength);
        }
    }
}
