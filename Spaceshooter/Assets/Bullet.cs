using JetBrains.Annotations;
using UnityEditor.Callbacks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private int damage = 1;
    void Start()
    {
        rb.linearVelocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable enemy = collision.gameObject.GetComponent<Damageable>();

        if(enemy != null)
        {
            enemy.TakeDamage(1);
        }
        
        
         Destroy(gameObject);


        
    }
        public void SetDamage(int newDamage)
        {
            damage = newDamage;
        }
}
