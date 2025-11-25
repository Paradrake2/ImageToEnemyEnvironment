using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyDefinition EnemyDefinition;
    public EnemyStats stats;
    public EnemyAI ai;
    public GameObject player;
    public Collider2D attackCollider;
    void Start()
    {
        Initialize(EnemyDefinition);
        player = FindFirstObjectByType<Player>().gameObject;
    }

    void Initialize(EnemyDefinition definition)
    {
        SetAI(definition);
        stats = GetComponent<EnemyStats>();
        if (stats != null)
        {
            stats.InitializeStats(definition);
        }
    }
    void SetAI(EnemyDefinition definition)
    {
        if (definition.behaviors == EnemyAIBehavior.Melee)
        {
            ai = gameObject.AddComponent<MeleeAI>();
        }
        else if (definition.behaviors == EnemyAIBehavior.Ranged)
        {
            ai = gameObject.AddComponent<RangedAI>();
        }
        ai.player = player;
        ai.detectionRange = definition.detectionRange;
    }
    public void TakeDamage(float damage)
    {
        if (stats != null)
        {
            float actualDamage = damage - stats.Defense;
            if (actualDamage < 0)
            {
                actualDamage = 0;
            }
            stats.currentHealth -= Mathf.Max(1, actualDamage);
            EnemyUI.instance.UpdateHealth();
            if (stats.currentHealth <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        ai.MovementBehaviour(player);
    }
}
