using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] enemies;
    public Transform[] spawners;
    public int minEnemies;
    public int maxEnemies;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    

    int randomEnemyToSpawn;
    int randomEnemyCount;
    int randomSpawnPoint;

    void Start()
    {
        InvokeRepeating("SpawnEnemys", spawnTime, spawnDelay);
        //SpawnEnemie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemys()
    {
        randomEnemyCount = Random.Range(minEnemies, maxEnemies);
        //enemyToSpawn = Random.Range(0, enemies.Length);

        for (int i = 0; i < randomEnemyCount; i++)
        {
            randomEnemyToSpawn = Random.Range(0, enemies.Length);
            randomSpawnPoint = Random.Range(0, spawners.Length);
            GameObject enemy = Instantiate(enemies[randomEnemyToSpawn], spawners[randomSpawnPoint].position, spawners[randomSpawnPoint].rotation);
            print("EnemySpawned: " +enemy.name);
        }

        if (stopSpawning)
        {
            CancelInvoke("SpawnEnemys");
        }
        //Instantiate(enemies[enemyToSpawn], transform.position, transform.rotation);
    }
}
