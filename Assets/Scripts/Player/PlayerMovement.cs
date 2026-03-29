using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Direction sprite
        if (movement.x > 0)
            sr.sprite = rightSprite;
        else if (movement.x < 0)
            sr.sprite = leftSprite;
        else if (movement.y > 0)
            sr.sprite = backSprite;
        else if (movement.y < 0)
            sr.sprite = frontSprite;

        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void FixedUpdate()
    {
        // Movement using physics (better)
        rb.linearVelocity = movement * speed;
    }
}