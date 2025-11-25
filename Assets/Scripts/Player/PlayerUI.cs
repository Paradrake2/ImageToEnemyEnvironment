using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI defenseText;
    public PlayerStats stats;
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
        if (stats != null)
        {
            UpdateHealth();
            damageText.text = "Damage: " + stats.damage.ToString();
            defenseText.text = "Defense: " + stats.defense.ToString();
        }
    }
    public void UpdateHealth()
    {
        if (stats != null)
        {
            healthText.text = "Health: " + stats.currentHealth.ToString() + "/" + stats.maxHealth.ToString();
        }
    }
}
