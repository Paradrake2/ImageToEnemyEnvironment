using UnityEngine;

public class EnemyComponentHolder : MonoBehaviour
{
    public static EnemyComponentHolder instance;
    public GameObject projectile;
    void Start()
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
}
