using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        // Check if the player pressed the fire button (left mouse button)
        if (Input.GetButtonDown("Fire1"))
        {
            // Call the Shoot method
            Shoot();
        }
    }

    void Shoot()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the firePoint to the mouse position
        Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

        // Calculate the rotation angle in degrees based on the shoot direction
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        // Create a rotation quaternion based on the calculated angle
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Instantiate the bullet with the calculated rotation
        Instantiate(bulletPrefab, firePoint.position, bulletRotation);
    }
}
