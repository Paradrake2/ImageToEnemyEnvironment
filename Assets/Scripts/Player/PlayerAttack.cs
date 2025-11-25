using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    public PlayerStats stats;
    public float projectileSpeed = 20f;
    void Start()
    {
        if (stats == null)
        {
            stats = GetComponent<PlayerStats>();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        if (projectile == null) return;

        // Get mouse position in world coordinates
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // Ensure Z is 0 for 2D

        // Calculate direction from player to mouse position
        Vector3 direction = (mouseWorldPos - transform.position).normalized;

        // Calculate rotation to face the shooting direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        // Instantiate projectile at player position with proper rotation
        GameObject spawnedProjectile = Instantiate(projectile, transform.position, rotation);
        
        // Apply velocity to the projectile
        Rigidbody2D rb = spawnedProjectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }

        // If the projectile has damage component, set the damage
        var projectileScript = spawnedProjectile.GetComponent<PlayerProjectile>();
        if (projectileScript != null && stats != null)
        {
            projectileScript.damage = stats.damage; // Assuming PlayerStats has a damage field
        }
    }
}
