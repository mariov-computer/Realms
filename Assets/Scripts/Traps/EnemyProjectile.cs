using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    private bool hit;

    private Transform player; // Reference to the player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the tag "Player"
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;

        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Move towards the player
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(directionToPlayer * movementSpeed);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            Deactivate();
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision); // Execute logic from the parent script first
        coll.enabled = false;

        if (anim != null)
            anim.SetTrigger("explode"); // When the object is a fireball, explode it
        else
            gameObject.SetActive(false); // When this hits any object, deactivate the arrow
    }


    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
