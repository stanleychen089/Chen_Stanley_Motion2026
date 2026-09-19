using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //transform of player to calculate player's current position in offset
    //public float of offset distance 
    public Transform playerTransform;
    public Vector3 bombOffsetDistance;
    public float moveDistance;

    //public float for task 2 -> Spawns bombs in a random corner around the player in a specified distance
    public float inDistance;

    //public float for task 3 -> ratio of distance that warps player to target
    public float ratioDistance;

    //public float and list for task 4 
    public float inMaxRange = 0;

    //Public variables by default
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            Vector3 testPos = new Vector3(0, 1);
            //using vector3(0,1) to test
            //would use playerTransform.position for actual player position
            SpawnBombAtOffset(testPos);
            SpawnBombAtOffset(playerTransform.position);

        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
   
            playerTransform.position = MoveTowardsEnemy(playerTransform.position, enemyTransform.position);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {

            SpawnBombOnRandomCorner(inDistance);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            WarpPlayer(enemyTransform, ratioDistance);
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            DetectAsteroids(inMaxRange, asteroidTransforms);
        }
    }

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 bombInstantiateLoco = new Vector3(inOffset.x + bombOffsetDistance.x, inOffset.y + bombOffsetDistance.y);
        Instantiate(bombPrefab, bombInstantiateLoco, Quaternion.identity);
    }

    public static Vector2 MoveTowardsEnemy(Vector3 playerPos, Vector3 targetPos)
    {
        //To find the direction vector between the enemy and player, subtract the end point from start point
        Vector3 directionVector = new Vector3(targetPos.x - playerPos.x, targetPos.y - playerPos.y);
        //Normalize the direction vector by using normalization forumla
        Vector2 normalizedDirectionVector = directionVector.normalized;
        //adjust the player position towards normalized direction
        Vector2 newPlayerPos = new Vector2(playerPos.x + normalizedDirectionVector.x, playerPos.y + normalizedDirectionVector.y);
        return newPlayerPos;

    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        //Using random range to get 4 different integers 
        //Use an if condition that leads to different outcomes depending on the generated integer 
        //Different outcomes spawn a bomb in each of the different corners around the player
        //Distance of corners is multiplied by inDistance
        int randomCorner = Random.Range(1, 5);
        Debug.Log(randomCorner);

        //top left
        Vector2 topLeft = new Vector2(transform.position.x - inDistance, transform.position.y + inDistance);
        //top right
        Vector2 topRight = new Vector2(transform.position.x + inDistance, transform.position.y + inDistance);

        //bottom left
        Vector2 bottomLeft = new Vector2(transform.position.x - inDistance, transform.position.y - inDistance);

        //bottom right
        Vector2 bottomRight = new Vector2(transform.position.x + inDistance, transform.position.y - inDistance);


        if (randomCorner == 1)
        {
            Instantiate(bombPrefab, topLeft, Quaternion.identity);
        }
        else if (randomCorner == 2)
        {
            Instantiate(bombPrefab, topRight, Quaternion.identity);

        }
        else if (randomCorner == 3)
        {
            Instantiate(bombPrefab, bottomLeft, Quaternion.identity);

        }
        else if (randomCorner == 4)
        {
            Instantiate(bombPrefab, bottomRight, Quaternion.identity);

        }
        else
        {
            Debug.Log("Error");
        }

    }
    public void WarpPlayer(Transform target, float ratio)
    {
        //adjust the player position towards target by a ratio
        //transform.position = Vector2.Lerp(transform.position,target.position,ratio);

        //An attempt to warp the player without using lerp
        Vector3 directionVector = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y);
        Vector3 newPlayerPos = new Vector3(transform.position.x + directionVector.x * ratio, transform.position.y + directionVector.y * ratio);
        transform.position = newPlayerPos;
        
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        for (int i = 0; i < inAsteroids.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, inAsteroids[i].position);
         
            if (distance < inMaxRange)
            {
                Vector3 directionVector = new Vector3(inAsteroids[i].position.x - transform.position.x, inAsteroids[i].position.y - transform.position.y);
                Vector3 normalizedVector = Vector3.Normalize(directionVector);
               
                Debug.DrawLine(transform.position, transform.position+normalizedVector, Color.green, 10);
            }
        }
    }

}
