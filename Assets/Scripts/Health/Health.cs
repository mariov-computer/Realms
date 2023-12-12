using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private bool isDead;
    private bool isInvincible = false;
    public GameManager gameManager;

    [SerializeField] private float invincibilityDuration = 2.0f; // Adjust the invincibility duration as needed

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        if (!isInvincible)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0 && !isDead)
            {
               
                StartCoroutine(SetInvincibility());
            }
            else
            {
                // Player dead
                if (!dead)
                {
                    anim.SetTrigger("die");

                    //Player
                 

                    //Enemy
                    if (GetComponent<EnemyPatrol>() != null)
                        GetComponent<EnemyPatrol>().enabled = false;

                    if (GetComponent<MeleeEnemy>() != null)
                        GetComponent<MeleeEnemy>().enabled = false;
                    
                    //
                    StartCoroutine(DieWithDelay());
                    dead = true;
                    isDead = true;
                    gameObject.SetActive(false);
                    gameManager.gameOver();
                }
            }


        }
    }

    private IEnumerator SetInvincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private IEnumerator DieWithDelay()
    {
        // Wait for a short delay before performing the actual death actions
        yield return new WaitForSeconds(1.0f); // Adjust the delay time as needed

        // Disable the PlayerScript or perform other actions
        GetComponent<PlayerScript>().enabled = false;

        // Additional actions related to the player's death can be placed here
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

        // Reset invincibility when adding health
        if (currentHealth > 0)
        {
            isInvincible = false;
        }
    }
}
