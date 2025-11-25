using UnityEngine;

public class RangedAI : EnemyAI
{
    private float attackCooldown = 1f;
    private float lastAttackTime = 0f;
    private Rigidbody2D rb;
    private EnemyStats stats;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
    }
    public override void MovementBehaviour(GameObject player)
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * stats.Speed;
    }
    public override void AttackBehaviour()
    {
        // Implement ranged attack logic here, e.g., shoot projectiles towards the player
        if (player != null && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GameObject projectile = EnemyComponentHolder.instance.projectile;
            if (projectile != null)
            {
                // Calculate rotation to face the shooting direction
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                
                GameObject spawnedProjectile = Instantiate(projectile, transform.position, rotation);
                Rigidbody2D rb = spawnedProjectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    float projectileSpeed = 20f; // You can adjust this value or get it from stats
                    rb.linearVelocity = direction * projectileSpeed;
                }
                
                spawnedProjectile.GetComponent<EnemyProjectile>().Instantiate(GetComponent<EnemyStats>().Damage);
            }
        }
    }
}
