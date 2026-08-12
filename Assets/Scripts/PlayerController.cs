using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 12f;
    public float fireRate = 0.25f; // segundos entre tiros
    float fireCooldown = 0f;

    [Header("Health")]
    public int maxHealth = 3;
    int currentHealth;

    public GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Apontar para o mouse
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouseWorld - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f; // ajustar sprite apontando para cima
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        fireCooldown -= Time.deltaTime;
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;
        GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D br = b.GetComponent<Rigidbody2D>();
        if (br != null)
        {
            br.velocity = firePoint.up * bulletSpeed;
        }

        Bullet bullet = b.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.owner = gameObject;
        }
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
        if (gameManager != null) gameManager.GameOver();
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pig"))
        {
            TakeDamage(1);
        }
    }
}
