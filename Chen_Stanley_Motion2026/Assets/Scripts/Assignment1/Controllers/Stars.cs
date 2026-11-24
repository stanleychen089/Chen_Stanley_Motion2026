using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public float currentTime;

    public Color randomColor;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation(starTransforms);
        randomColor = Random.ColorHSV();
    }

    void DrawConstellation(List<Transform> stars)
    {
        currentTime += Time.deltaTime;
        if (currentTime > drawingTime)
        {
            currentTime = 0;
        }
        for(int i = 0; i < stars.Count -1; i++)
        {

            Vector3 startPos = stars[i].position;
            Vector3 endPos = stars[i + 1].position;
            Vector3 currentPosition = Vector3.Lerp(startPos, endPos, currentTime/drawingTime);
            Debug.DrawLine(stars[i].position, currentPosition, Color.yellow, 0);
        }

        
    }
}
