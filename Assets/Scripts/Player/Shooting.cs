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
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Set rotation to point upwards (Vector3.up)
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 90f);
        Instantiate(bulletPrefab, firePoint.position, bulletRotation);
    }
}
