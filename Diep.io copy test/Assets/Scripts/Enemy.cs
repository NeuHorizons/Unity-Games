using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;  // The health of the enemy.
    public HealthBar healthBar;  // Reference to the HealthBar script.

    void Start()
    {
        // Initialize the health bar with the maximum health.
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(health);
        }
    }

    // Method to take damage, called when hit by a bullet.
    public void TakeDamage(int damage)
    {
        // Reduce the enemy's health by the damage amount.
        health -= damage;

        // Update the health bar.
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        // Check if the enemy's health is zero or less.
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle the enemy's death.
    void Die()
    {
        // Destroy the enemy game object when it dies.
        Destroy(gameObject);
    }
}
