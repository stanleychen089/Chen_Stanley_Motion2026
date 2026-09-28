using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<float> angles;
    public int amountOfAngles;
    public float angleIncrements;
    public float radius;
    public Vector2 circleOffset;
    public int currentAngleIndex = 0;

    public float shiftDuration;
    public float shiftProgress = 0f;

    void Start()
    {
        for (int i = 0; i < amountOfAngles; i++)
        {
            angles.Add(angleIncrements * i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = angles[currentAngleIndex];
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad;

        Vector2 startPoint = Vector2.zero + circleOffset;
        float endPointX = Mathf.Cos(currentAngleInRadians);
        float endPointY = Mathf.Sin(currentAngleInRadians);
        Vector2 endPoint = new Vector2(endPointX, endPointY) * radius + circleOffset;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            changeCurrentAngle();
        }

        shiftProgress += Time.deltaTime;
        if (shiftProgress > shiftDuration)
        {
            changeCurrentAngle();
            shiftProgress = 0f;
        }
        Vector3 pointOnCircle = new Vector3(Mathf.Cos(angles[currentAngleIndex]), Mathf.Sin(angles[currentAngleIndex])) * radius;

        Debug.DrawLine(startPoint, endPoint, Color.white);
    }

    public void changeCurrentAngle()
    {
        currentAngleIndex++;
        if(currentAngleIndex >= amountOfAngles)
        {
            currentAngleIndex = 0;
        }       

    }
}
