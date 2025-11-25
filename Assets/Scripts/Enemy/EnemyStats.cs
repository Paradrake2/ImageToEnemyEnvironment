using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Health;
    public float Damage;
    public float Defense;
    public float Speed;
    public float AttackRange = 0f;
    public float currentHealth;
    public void InitializeStats(EnemyDefinition definition)
    {
        Health = definition.hp;
        Damage = definition.attack;
        Defense = definition.defense;
        Speed = definition.speed;
        AttackRange = definition.attackRange;
        currentHealth = Health;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
