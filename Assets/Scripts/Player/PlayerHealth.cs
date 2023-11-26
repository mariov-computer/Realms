using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health points
    private int currentHealth;    // Current health points
    public HealthBar healthbar;   // Reference to the HealthBar script

    //Manages the games quit, main menu and restart functions
    public GameManager gameManager;
    private bool isDead;

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
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            // Player is dead, trigger the Die method
            Die();
        }
    }

    // Method to handle player death
    void Die()
    {
        // Destroy the player GameObject
        Destroy(gameObject);

        // Call the gameOver method from GameManager
        FindObjectOfType<GameManager>().gameOver();
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
