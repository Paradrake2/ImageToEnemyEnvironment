using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D col;
    public float damage;

    public void Instantiate(float damage)
    {
        this.damage = damage;
        Destroy(this.gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
