using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //transform of player to calculate player's current position in offset
    //public float of offset distance 
    public Transform playerTransform;
    public Vector3 bombOffsetDistance;
    public float moveDistance;

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
}
