using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;  // The health of the enemy.

    // Method to take damage, called when hit by a bullet.
    public void TakeDamage(int damage)
    {
        // Reduce the enemy's health by the damage amount.
        health -= damage;

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

