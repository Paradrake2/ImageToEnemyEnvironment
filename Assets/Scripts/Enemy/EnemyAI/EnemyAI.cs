using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 15f;
    public virtual void MovementBehaviour(GameObject player) { }
    public virtual void AttackBehaviour() { }
    bool playerInRange = false;
    public GameObject player;
    void Start()
    {
        //player = FindFirstObjectByType<Player>().gameObject;
    }
    public void DetectPlayer()
    {
        //GameObject findPlayer = FindFirstObjectByType<Player>().gameObject;
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= detectionRange)
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }
        }
    }
    void Update()
    {
        DetectPlayer();
        if (playerInRange)
        {
            MovementBehaviour(player);
            AttackBehaviour();
        }
    }
}
