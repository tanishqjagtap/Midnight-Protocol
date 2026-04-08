using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // 🔥 INPUT (no sliding)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize so diagonal isn't faster
        movement = movement.normalized;

        // 🎬 ANIMATION CONTROL
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // 🚀 MOVEMENT
        rb.linearVelocity = movement * speed;
    }
}