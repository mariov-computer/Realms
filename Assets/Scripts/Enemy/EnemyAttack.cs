using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;             // Amount of damage the enemy's attack does
    public float attackRange = 1.5f;    // Range within which the enemy can attack
    public float attackCooldown = 2f;   // Cooldown between attacks
    private bool canAttack = true;       // Flag to check if the enemy can attack

    void Update()
    {
        // Assuming the player is the target
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && canAttack)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Check if the player is within attack range
            if (distanceToPlayer <= attackRange)
            {
                // Call the method to handle the attack
                AttackPlayer(player);
            }
        }
    }

    void AttackPlayer(GameObject player)
    {
        // Deal damage to the player
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        // Check if the player has a health script
        if (playerHealth != null)
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damage);
        }

        // Set attack cooldown
        canAttack = false;
        Invoke("ResetAttack", attackCooldown);

        // You can also play attack animations or sound effects here.
    }

    void ResetAttack()
    {
        canAttack = true;
    }
}
