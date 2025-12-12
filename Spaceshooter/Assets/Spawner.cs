using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnrate = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }


    IEnumerator SpawnEnemy()
    { 
        yield return new WaitForSeconds(spawnrate); //wait 1 sec

        Vector2 pivot = transform.position;

        Vector2 randomPos = new Vector2(pivot.x + Random.Range(-1.4f,1.4f) , pivot.y); // Spawn enemy

        Instantiate(enemy, randomPos, Quaternion.identity); // Spawn enemy

        StartCoroutine(SpawnEnemy()); // Repeat
       
          
    }

  
}
