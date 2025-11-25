using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI behaviorText;
    public TextMeshProUGUI definitionText;
    public EnemyStats enemyStats;
    public GameObject focusEnemy;
    public static EnemyUI instance;
    private float cooldownBetweenUpdates = 0.5f;
    private float lastUpdateTime = 0f;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateStatText();
    }
    public void UpdateHealth()
    {
        if (focusEnemy != null)
        {
            if (enemyStats != null)
            {
                healthText.text = "Health: " + enemyStats.currentHealth.ToString() + "/" + enemyStats.Health.ToString();
            }
        }
    }
    void UpdateStatText()
    {
        if (focusEnemy != null)
        {
            enemyStats = focusEnemy.GetComponent<EnemyStats>();

            damageText.text = "Damage: " + enemyStats.Damage.ToString();
            defenseText.text = "Defense: " + enemyStats.Defense.ToString();
            speedText.text = "Speed: " + enemyStats.Speed.ToString();
            Enemy enemy = focusEnemy.GetComponent<Enemy>();
            if (enemy != null && enemy.EnemyDefinition != null)
            {
                definitionText.text = "Name: " + enemy.EnemyDefinition.enemyName;
                behaviorText.text = "Behavior: " + enemy.EnemyDefinition.behaviors.ToString();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastUpdateTime + cooldownBetweenUpdates)
        {
            UpdateHealth();
            UpdateStatText();
            lastUpdateTime = Time.time;
        }
    }
}
