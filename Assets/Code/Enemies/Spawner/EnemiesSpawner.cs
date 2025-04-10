using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public int enemiesMaxAlive;
    public int enemiesMaxSpawned;
    public int enemiesAlive;
    public int enemiesEver;

    public GameObject[] enemiesPrefabs;

    List<GameObject> enemies;

    public GameObject[] bounds;

    public float SpawningSpeedSeconds;
    public bool allowNaturalSpawn;
    float timeNextSpawn;
    

    void Start()
    {
        enemies = new List<GameObject>();
    }
    void Update(){

        timeNextSpawn += Time.deltaTime;
        if(timeNextSpawn >= SpawningSpeedSeconds && enemiesAlive < enemiesMaxAlive && allowNaturalSpawn){
            timeNextSpawn = 0;
            SpawnEnemy();
        }
        
        if(!allowNaturalSpawn && enemiesEver < enemiesMaxSpawned && timeNextSpawn >= SpawningSpeedSeconds ){
            timeNextSpawn = 0;
            SpawnEnemy();
        }

    }
    void SpawnEnemy(){

        int randomPrefab = Random.Range(0, enemiesPrefabs.Length);
        var enemy = Instantiate(enemiesPrefabs[randomPrefab], newRandomPosition(), Quaternion.identity);
        enemy.GetComponent<EnemyHP>().DeathCaller = this;

        enemies.Add(enemy);

        enemiesAlive += 1;
        enemiesEver++;
    }

    Vector2 newRandomPosition(){
        Vector2 v1 = (Vector2)bounds[0].transform.position;
        Vector2 v2 = (Vector2)bounds[1].transform.position;
        
        Vector2 result = new Vector2(Random.Range(v1.x, v2.x), Random.Range(v1.y, v2.y));
        
        if(((Vector2)GlobalManager.Instance.Player.transform.position - result).magnitude <= 10f){
            return newRandomPosition();
        }

        return result;
    }

    internal void EnemyDown()
    {
        enemiesAlive--;
    }

    void OnDestroy()
    {
        foreach(GameObject enemy in enemies){
            Destroy(enemy);
        }
    }
}
