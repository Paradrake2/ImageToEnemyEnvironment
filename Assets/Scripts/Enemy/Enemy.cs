using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyDefinition EnemyDefinition;
    public EnemyStats stats;
    public EnemyAI ai;
    public GameObject player;
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
    }
    // Update is called once per frame
    void Update()
    {
        ai.MovementBehaviour(player);
    }
}
