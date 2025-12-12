
using JetBrains.Annotations;
using UnityEngine;

public class Damageable : MonoBehaviour 
{
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject explosion;
    
     public void TakeDamage(int damage)
    {
        health = health - damage;// x = 3 - y

        print(gameObject.name + "levou" + damage + "dano");

        if(health<=0)
        {
           Die();
        }
    }

     public void Die()
    {
        Destroy(gameObject);

        if(explosion!=null)
        {
            GameObject explosionInstance = Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(explosionInstance, 1);
        }
    }
    
}