using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float attackRange = 1f;
    public float detectionRange = 5f;  // The range within which the zombie can see the player
    public LayerMask obstacleLayer;    // Layer to consider as obstacles (e.g., walls)

    private Transform player;
    private bool isAttacking = false;
    private Rigidbody2D rb;

    private float attackCooldown = 1f;
    private float lastAttackTime = 0f;
    public int attackDamage = 10;

    void Start()
    {
        // Ensure player reference is set
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player GameObject is tagged 'Player'.");
            return;  // Exit if player is not found
        }

        // Ensure Rigidbody2D reference is set
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on zombie!");
            return;
        }
    }

    void Update()
    {
        if (player == null) return;  // Exit if player reference is not set

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && CanSeePlayer())
        {
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        isAttacking = false;
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        if (!isAttacking && Time.time > lastAttackTime + attackCooldown)
        {
            isAttacking = true;
            // Add attack animation or other attack logic here
            if (player.GetComponent<PlayerHealth>() != null)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on the player.");
            }
            lastAttackTime = Time.time;
            isAttacking = false;
        }
    }

    bool CanSeePlayer()
    {
        if (player == null) return false;  // Exit if player reference is not set

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);
        Debug.DrawRay(transform.position, directionToPlayer * distanceToPlayer, Color.red); // Add this line for debugging
        if (hit.collider == null)
        {
            return true;  // No obstacle in the way
        }
        return false;    // Obstacle in the way
    }
}
