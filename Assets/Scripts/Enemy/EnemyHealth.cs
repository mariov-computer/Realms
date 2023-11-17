using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health points of the enemy
    private int currentHealth;   // Current health points of the enemy
    public HealthBar healthbar;

    void Start()
    {
        // Initialize current health to maxHealth when the enemy spawns
        currentHealth = maxHealth;
    }

    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        // Reduce current health by the damage amount
        currentHealth -= damage;

        // Update the health bar
        healthbar.setHealth(currentHealth);

        // Check if the enemy's health is less than or equal to 0
        if (currentHealth <= 0)
        {
            // Enemy is defeated, you can handle death logic here
            Die();
        }
    }

    // Method to handle enemy death
    void Die()
    {
        // For example, you can play death animations, drop items, or give the player points

        Destroy(gameObject); // Destroy the enemy GameObject when it is defeated

    }

    public RandEnemySpawner enemySpawner;


    // Method to deal damage to the player
    public void InflictDamageToPlayer(int damage)
    {
        // Assuming the player has a PlayerHealth script attached to it
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        // Check if the player's health script is found
        if (playerHealth != null)
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damage);
        }
    }
}
