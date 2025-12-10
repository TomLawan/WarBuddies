using UnityEngine;
using PurrNet;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private float moveInput;
    private bool isFacingRight = true;

    void Update()
    {
        // Kumuha ng input (A/D or Left/Right Arrow)
        // Gamit ang "Raw" para huminto agad pag binitawan ang key
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {

        // Pagalawin ang player gamit ang Rigidbody
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        // Check kung kailangan humarap sa kabila

        if (moveInput > 0 && !isFacingRight)

        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)

        {
            Flip();
        }

    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        // I-rotate ang player ng 180 degrees para humarap sa kabila

        transform.Rotate(0f, 180f, 0f);
    }

}