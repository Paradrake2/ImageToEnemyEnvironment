using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats stats;
    private Vector2 movement;
    private Rigidbody2D rb;
    public float deceleration = 10f;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector2 targetVelocity = movement.normalized * stats.speed;
        if (movement == Vector2.zero)
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }
        else
        {
            rb.linearVelocity = targetVelocity;
        }
    }
}
