using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private int collisionDamage = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = Vector2.down * speed;
    }

    

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
           player.TakeDamage(collisionDamage);
           TakeDamage(1);
        }
        else if(collision.gameObject.CompareTag("Bullet")==false)
        {
            Die();
        }
    }
}
