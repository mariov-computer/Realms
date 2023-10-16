using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health points
    private int currentHealth;    // Current health points
    public HealthBar healthbar;   // Reference to the HealthBar script

    void Start()
    {
        // Initialize current health to maxHealth when the game starts
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        // Reduce current health by the damage amount
        currentHealth -= damage;

        // Update the health bar
        healthbar.setHealth(currentHealth);

        // Check if the player's health is less than or equal to 0
        if (currentHealth <= 0)
        {
            // Player is dead, you can handle game over logic here
            Die();
        }
    }

    // Method to handle player death
    void Die()
    {
        // For example, you can reload the scene or show a game over screen
        // For now, let's just deactivate the player GameObject
        gameObject.SetActive(false);
    }

    // Method to restore player health (if needed)
    public void RestoreHealth(int amount)
    {
        // Increase current health by the specified amount
        currentHealth += amount;

        // Ensure current health doesn't exceed maxHealth
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        // Update the health bar
        healthbar.setHealth(currentHealth);
    }
}
