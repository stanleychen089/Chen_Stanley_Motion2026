using UnityEngine;

public class Week1Scripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 originPosition = new Vector2(0, 0);
        Vector2 currentPosition = new Vector2(3, -2);

        //Debug.DrawLine(originPosition, currentPosition, Color.gray, 15);

        //Exercise: Drawing Vector2s
        //dVector
        Vector2 dVector = new Vector2(0, 1);
        Vector2 eVector = new Vector2(3, -2);

        //Drawing the lines using Debug.DrawLine();
        Debug.DrawLine(originPosition, dVector, Color.yellow,16);
        Debug.DrawLine(originPosition, eVector, Color.gray,16);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
