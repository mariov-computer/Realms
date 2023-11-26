using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase: MonoBehaviour
{
    public Transform target;  // The target to chase (usually the player)
    public float speed = 5f;  // The speed at which the enemy moves
    public float detectionRadius = 10f;  // The radius within which the enemy detects and chases the target

    public string targetObjectName = "Player"; // The name of the target GameObject

    void Start()
    {
        // Find the target GameObject by name
        target = GameObject.Find(targetObjectName).transform;
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the distance between the enemy and the target
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Check if the target is within the detection radius
            if (distanceToTarget <= detectionRadius)
            {
                // Calculate the direction from the enemy to the target
                Vector3 direction = target.position - transform.position;

                // Normalize the direction to get a unit vector
                direction.Normalize();

                // Move the enemy towards the target
                transform.position += direction * speed * Time.deltaTime;

                // Optional: Rotate the enemy to face the target (uncomment the line below)
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
            // Add else block if you want to perform other actions when the target is outside the detection radius
        }
    }
}