using UnityEngine;
using System;
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

    [Header("Behavior")]
    public EnemyAI behaviorType;

}
