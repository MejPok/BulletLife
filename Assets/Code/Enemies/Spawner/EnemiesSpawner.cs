using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public int enemiesAlive;

    public GameObject[] enemiesPrefabs;

    List<GameObject> enemies;

    public GameObject[] bounds;

    public float SpawningSpeedSeconds;
    float timeNextSpawn;
    void Start()
    {
        enemies = new List<GameObject>();
    }
    void Update(){
        timeNextSpawn += Time.deltaTime;
        if(timeNextSpawn >= 3f){
            timeNextSpawn = 0;
            SpawnEnemy();
        }

    }
    void SpawnEnemy(){

        int randomPrefab = Random.Range(0, enemiesPrefabs.Length);
        var enemy = Instantiate(enemiesPrefabs[randomPrefab], newRandomPosition(), Quaternion.identity);

        enemies.Add(enemy);

        enemiesAlive += 1;
    }

    Vector2 newRandomPosition(){
        Vector2 v1 = (Vector2)bounds[0].transform.position;
        Vector2 v2 = (Vector2)bounds[1].transform.position;
        
        Vector2 result = new Vector2(Random.Range(v1.x, v2.x), Random.Range(v1.y, v2.y));
        return result;
    }
}
