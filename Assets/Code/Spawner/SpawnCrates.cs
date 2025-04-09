using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrates : MonoBehaviour
{
    float timer;
    public float timerMax;

    public GameObject[] bounds;
    public GameObject cratePrefab;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerMax){
            timer = 0;
            SpawnCrate();
        }
    }

    private void SpawnCrate()
    {
        Instantiate(cratePrefab, newRandomPosition(), Quaternion.identity);
    }

    Vector2 newRandomPosition(){
        Vector2 v1 = (Vector2)bounds[0].transform.position;
        Vector2 v2 = (Vector2)bounds[1].transform.position;
        
        Vector2 result = new Vector2(Random.Range(v1.x, v2.x), Random.Range(v1.y, v2.y));
        return result;
    }
}
