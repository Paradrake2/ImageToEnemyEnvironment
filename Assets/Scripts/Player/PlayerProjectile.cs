using UnityEngine;

public class PlayerProjectile : MonoBehaviour
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
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
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
