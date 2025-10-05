using UnityEngine;
using System;
public enum EnemyAIBehavior{ Melee, Ranged}
[CreateAssetMenu(fileName = "EnemyDefinition", menuName = "Scriptable Objects/EnemyDefinition")]

public class EnemyDefinition : ScriptableObject
{
    public string enemyName;
    public int level;
    [Header("Stats")]
    public int hp;
    public float attack;
    public float defense;
    public float speed;
    public float attackRange = 0f;

    [Header("Behavior")]
    public EnemyAIBehavior behaviors;
    public float detectionRange = 15f;

}
