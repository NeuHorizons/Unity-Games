using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Controls how fast the tank moves.
    public float rotationSpeed = 200f; // Controls the rotation speed for the tank's cannon/body.

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component.
    }

    void Update()
    {
        // Handle movement input from the keyboard (WASD).
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrow keys for strafing.
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrow keys for forward/backward.

        // Create a movement vector based on input.
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Move the tank by setting its velocity.
        rb.velocity = movement * moveSpeed;

        // Rotate the tank's body/cannon to face the mouse cursor.
        RotateTowardsMouse();
    }

    void RotateTowardsMouse()
    {
        // Get the position of the mouse in world coordinates.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-coordinate is zero since this is 2D.

        // Calculate the direction from the tank to the mouse cursor.
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle between the tank's up direction and the mouse direction.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the tank's Rigidbody2D component.
        rb.rotation = angle;
    }
}
