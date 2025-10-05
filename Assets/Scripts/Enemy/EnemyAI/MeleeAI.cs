using UnityEngine;

public class MeleeAI : EnemyAI
{
    public Rigidbody2D rb;
    public EnemyStats stats;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
    }
    public override void MovementBehaviour(GameObject player)
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * stats.Speed; // Move towards the player
    }
    public override void AttackBehaviour()
    {
        base.AttackBehaviour();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Implement attack logic here, e.g., reduce player health
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(stats.Damage);
            }
        }
    }
}
