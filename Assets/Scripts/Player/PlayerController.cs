using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Freeze rotation to prevent spinning
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

        // Handle movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized; // Normalize the vector to ensure consistent movement speed in all directions

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        Vector2 newPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;

        // Restrict the player within the screen boundaries
        float xClamped = Mathf.Clamp(newPosition.x, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x,
                                     Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);

        float yClamped = Mathf.Clamp(newPosition.y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y,
                                     Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);

        newPosition = new Vector2(xClamped, yClamped);

        // Move the player
        rb.MovePosition(newPosition);

        // Handle jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
    
}
