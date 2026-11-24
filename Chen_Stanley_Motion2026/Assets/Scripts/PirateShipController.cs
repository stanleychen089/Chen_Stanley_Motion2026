using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PirateShipController : MonoBehaviour
{
    public ScoreboardController scoreboard; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Creating a Trigger Collision on the other ships 

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //When the OnTrigger is activated by a collider entering the current game object, check to see if it is a cannonball
        //We know if the colliding object is a cannonball by whether or not it has the cannonball controller script 
        CannonballController cannonball = otherCollider.GetComponent<CannonballController>();

        if (cannonball != null)
        {
            scoreboard.Score++;
            Destroy(otherCollider.gameObject);
        }

    }
}
