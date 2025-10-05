using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats stats;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        if (movement.magnitude > 0)
        {
            transform.Translate(movement * stats.speed * Time.deltaTime);
        }
    }
}
