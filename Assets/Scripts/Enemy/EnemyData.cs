using System;
[Serializable]
public class EnemyData
{
    public string name;
    public int level;
    public Stats stats;
    public string[] behaviors;

    [Serializable]
    public class Stats
    {
        public int hp;
        public float attack;
        public float defense;
        public float speed;
    }
}
