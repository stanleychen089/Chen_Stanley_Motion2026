using UnityEngine;

public class VectorOperations : MonoBehaviour
{
    public Vector2 redVector; // (1,3)
    public Vector2 blueVector; //(2,2) 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 redPlusBlue = redVector + blueVector;
        Vector2 redMinusBlue = redVector - blueVector;
        Vector2 origin = new Vector2(0, 0);

        Debug.DrawLine(origin, redVector, Color.red);
        Debug.DrawLine(origin, blueVector, Color.blue);
        Debug.DrawLine(origin, redPlusBlue, Color.purple);
        Debug.DrawLine(origin, redMinusBlue, Color.orange);

    }
}
