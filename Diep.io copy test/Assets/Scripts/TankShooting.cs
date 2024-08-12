using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab.
    public Transform firePoint;     // The point from where the bullet will be fired.
    public float bulletSpeed = 20f; // Speed at which the bullet will travel.

    void Update()
    {
        // Check for player input to fire (e.g., left mouse button).
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Instantiate the bullet at the fire point's position and rotation.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D component of the bullet.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the velocity of the bullet to make it fly in the direction the cannon is facing.
        rb.velocity = firePoint.up * bulletSpeed;
    }
}
