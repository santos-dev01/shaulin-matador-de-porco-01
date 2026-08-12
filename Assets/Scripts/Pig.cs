using UnityEngine;

public class Pig : MonoBehaviour
{
    public int maxHealth = 1;
    int currentHealth;
    public float moveSpeed = 2f;

    Transform player;
    Rigidbody2D rb;
    GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p) player = p.transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (player == null) return;
        Vector2 dir = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameManager != null) gameManager.AddScore(1);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            if (pc != null) pc.TakeDamage(1);
        }
    }
}
