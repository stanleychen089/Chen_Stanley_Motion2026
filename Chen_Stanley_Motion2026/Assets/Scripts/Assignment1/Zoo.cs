using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public List<string> animals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animals.Add("Penguin");
        animals.Add("Dinosaur");
        animals.Add("Shark");

        animals.Remove("Dinosaur");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
