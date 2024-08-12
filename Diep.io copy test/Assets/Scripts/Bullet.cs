using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;  // Speed of the bullet.
    public float lifetime = 2f;      // Lifetime of the bullet in seconds.
    public int damage = 10;          // Damage the projectile deals upon collision.

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the bullet.
        rb = GetComponent<Rigidbody2D>();

        // Set the velocity of the bullet so it flies in its current forward direction.
        rb.velocity = transform.up * bulletSpeed;

        // Destroy the bullet after the set lifetime has passed.
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the bullet hit an enemy or another object.
        // Add logic for what happens when it hits an enemy.
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);  // Assuming the Enemy script has a TakeDamage method.
        }

        // Destroy the bullet upon collision.
        Destroy(gameObject);
    }

    // Optional: A method to extend or reduce the bullet's lifetime dynamically.
    public void SetLifetime(float newLifetime)
    {
        lifetime = newLifetime;

        // If the bullet has already been instantiated, reset the destruction timer.
        CancelInvoke("DestroyBullet");
        Invoke("DestroyBullet", lifetime);
    }

    // Optional: A method to visually fade the bullet (this requires a SpriteRenderer component).
    private IEnumerator FadeOut()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color originalColor = sr.color;
        float fadeDuration = 1f; // Duration of the fade-out.

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            sr.color = Color.Lerp(originalColor, Color.clear, normalizedTime);
            yield return null;
        }

        sr.color = Color.clear; // Ensure the bullet is completely transparent.
        Destroy(gameObject);    // Finally, destroy the bullet.
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
