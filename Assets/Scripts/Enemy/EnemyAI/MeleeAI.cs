using UnityEngine;

public class MeleeAI : EnemyAI
{
    public Rigidbody2D rb;
    public EnemyStats stats;
    public Collider2D attackCollider;
    private float attackCooldown = 0.5f;
    private float lastAttackTime = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
        attackCollider = GetComponent<Enemy>().attackCollider;
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
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (collision.CompareTag("Player"))
            {
                lastAttackTime = Time.time;
                // Implement attack logic here, e.g., reduce player health
                Player player = collision.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(stats.Damage);
                }
            }
        }
    }
}
