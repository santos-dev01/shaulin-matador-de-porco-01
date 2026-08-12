using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    public int damage = 1;
    public GameObject owner; // para evitar acertar o próprio atirador

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (owner != null && other.gameObject == owner) return;

        Pig pig = other.GetComponent<Pig>();
        if (pig != null)
        {
            pig.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        // destruir em colisão com obstáculos (se tiverem a tag "Obstacle")
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
