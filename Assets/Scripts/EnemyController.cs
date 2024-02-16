using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController playerController;

    public float health;
    public Transform[] waypoints;
    public float moveSpeed;
    public float chaseRange;
    public float stopRange;
    public Transform player;
    public float attackCooldown = 2f;  // Cooldown time between attacks
    private bool canAttack = true;      // Flag to check if the enemy can attack

    private int currentWaypointIndex;

    void Start()
    {
        currentWaypointIndex = 0;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= chaseRange && distanceToPlayer > stopRange)
            {
                MoveToTarget(player.position);
            }
            else if (distanceToPlayer <= stopRange)
            {
                if (canAttack)
                {
                    StartCoroutine(Attack());
                }
            }
            else
            {
                MoveToWaypoint();
            }
        }
        else
        {
            Debug.LogError("Player reference is not set. Assign the player GameObject in the Unity Editor.");
        }
    }

    void MoveToWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to the EnemyController.");
            return;
        }

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        MoveToTarget(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void MoveToTarget(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    IEnumerator Attack()
    {
        canAttack = false; // Set the flag to prevent repeated attacks

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= stopRange)
        {
            playerController.health--;
        }

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true; // Set the flag to allow the next attack
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
