using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float detectionDistance;
    public float extendedDistance;
    public float unseenDistance;
    public float dashSpeed;
    public float chargeSpeed = 1;

    public float attackTimer;
    public float attackRate;

    public float dashDuration;
    public float dashTimer;
    public bool currentlyDashing;
    public Vector3 directionVector;


    private void Update()
    {
        EnemyDetection(playerTransform);
    }

    public void EnemyDetection(Transform targetTransform)
    {
        Vector3 targetPos = targetTransform.position;
        float distance = Vector3.Distance(transform.position, targetPos);
        if (distance < detectionDistance)
        {
            detectionDistance = extendedDistance;
            EnemyCharge(targetPos);
        }
        if (distance > detectionDistance)
        {
            detectionDistance = unseenDistance ;
        }
    }

    public void EnemyCharge(Vector3 targetPosition)
    {
        //if t < attackRate, attack is not happening yet, but enemy will look towards player
        //Once t > attackRate, commence attack
        if (attackTimer < attackRate)
        {
            attackTimer += Time.deltaTime;
            directionVector = targetPosition - transform.position;
            transform.up = directionVector;
            transform.position -= directionVector.normalized * chargeSpeed * Time.deltaTime;


            if (attackTimer > attackRate)
            {
                currentlyDashing = true;
            }

        }
        //If attack has commenced, start a timer
        //Attack will last until timer is over the set attack duration
        if (currentlyDashing)
        {
            dashTimer += Time.deltaTime;
            transform.position += directionVector.normalized * dashSpeed * Time.deltaTime;
            if(dashTimer > dashDuration)
            {
                dashTimer = 0;
                attackTimer = 0;
                currentlyDashing = false;
            }
        }




    }

}
