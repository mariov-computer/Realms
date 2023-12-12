using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private PlayerScript playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerScript>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        // Get the mouse position in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Calculate the direction from the player to the mouse position
        Vector3 shootingDirection = (mousePosition - transform.position).normalized;

        // Set the direction for the fireball
        int fireballIndex = FindFireball();
        GameObject fireball = fireballs[fireballIndex];
        fireball.transform.position = new Vector3(firePoint.position.x, firePoint.position.y, fireball.transform.position.z);


        // Activate the fireball and set its direction
        Projectile projectileScript = fireball.GetComponent<Projectile>();
        projectileScript.SetDirection(shootingDirection.x);

        // PLAYER PROJECTILE ATTACK - pool fire
    }


    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
