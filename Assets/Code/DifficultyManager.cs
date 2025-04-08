using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set;}
    public float TimeElapsedUntilNextDifficulty;

    public float Difficulty;
    void Start()
    {
        Instance = this;
        Difficulty = 1;
    }

    
    void Update()
    {   
        TimeElapsedUntilNextDifficulty += Time.deltaTime;

        if(TimeElapsedUntilNextDifficulty >= 15f){
            Difficulty += 0.1f;
            TimeElapsedUntilNextDifficulty = 0;
            GetComponent<EnemiesSpawner>().SpawningSpeedSeconds = 5 - Difficulty;

        }
    }

}
