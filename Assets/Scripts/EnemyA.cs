using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, IDamageable
{
    [SerializeField] float health = 3f;
    [SerializeField] float patrolSpeed = 2f;
    [SerializeField] float chargeSpeed = 5f;
    [SerializeField] float patrolDistance = 3f;
    [SerializeField] float rayLength = 5f;
    [SerializeField] float attackDamage = 10f;

    private Vector2 startPos;
    private bool movingRight = true;
    private Transform player;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Constantly check for player
        DetectPlayer();

        if (player != null)
        {
            ChargePlayer();
        }
        else
        {
            Patrol();
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

    void Patrol()
    {
        float move = patrolSpeed * Time.deltaTime * (movingRight ? 1 : -1);
        transform.Translate(Vector2.right * move);

        // Flip direction if beyond patrol distance
        if (movingRight && transform.position.x > startPos.x + patrolDistance)
            movingRight = false;
        else if (!movingRight && transform.position.x < startPos.x - patrolDistance)
            movingRight = true;
    }

    [SerializeField] LayerMask playerLayer; // assign in Inspector
    [SerializeField] float attackCooldown = 1f; // seconds between attacks
    private float lastAttackTime = -Mathf.Infinity; // track last attack
    void DetectPlayer()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;

        // Draw ray for debugging
        Debug.DrawRay(transform.position, direction * rayLength, Color.red);

        // Raycast only against Player layer
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength, playerLayer);

        if (hit.collider != null)
        {
            Debug.Log("Raycast hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("We detected the player");
                player = hit.collider.transform;
            }
        }
        else
        {
            player = null;
        }
    }

    void ChargePlayer()
    {
        // Move quickly toward player
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            chargeSpeed * Time.deltaTime
        );

        // If close enough, attack
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < 1f)
        {
            Debug.Log("We are on attack distance with player");

            // Check cooldown
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                IDamageable damageable = player.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    Debug.Log("there is an IDamageable detected ");
                    damageable.GetDamage(attackDamage);
                    Debug.Log("Enemy attacked player for " + attackDamage + " damage");

                    // Reset cooldown
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                Debug.Log("Attack on cooldown...");
            }
        }
    }
}
