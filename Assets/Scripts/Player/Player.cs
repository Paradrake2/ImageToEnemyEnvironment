using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;
    public PlayerMovement movement;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        movement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float damage)
    {
        if (stats != null)
        {
            stats.currentHealth -= damage;
            if (stats.currentHealth <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        Debug.Log("Player has died.");
        // Implement respawn or game over logic here
    }
    void Update()
    {
        
    }
}
