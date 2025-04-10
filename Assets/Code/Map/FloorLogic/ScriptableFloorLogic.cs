using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableFloorLogic : ScriptableObject
{
    public GameObject map;
    public int Floor;

    public EnemiesSpawner spawner;
    public SpawnCrates crateSpawner;

    public List<GameObject> additionalEnemies;

    public virtual void ChangeBehaviour(){

    }

    public virtual void StartFloor(){
        
        DecidePotentialEnemies();
        spawner.enemiesPrefabs = additionalEnemies.ToArray();
        ChangeBehaviour();
    }

    public virtual void DecidePotentialEnemies(){
        spawner.enemiesMaxAlive = Floor * 15;
        spawner.enemiesMaxSpawned = Floor * 20;

        if(Floor < 2){
            for(int i = 0; i < TowerManager.instance.allPossibleEnemiesBasedOnDifficulty.Length && i < 2; i++){
                additionalEnemies.Add(TowerManager.instance.allPossibleEnemiesBasedOnDifficulty[i]);
            }
            return;
        }

        if( Floor < 5){
            for(int i = 1; i < TowerManager.instance.allPossibleEnemiesBasedOnDifficulty.Length && i < 4; i++){
                additionalEnemies.Add(TowerManager.instance.allPossibleEnemiesBasedOnDifficulty[i]);
            }
            return;
        }

        if( Floor < 7){
            for(int i = 2; i < TowerManager.instance.allPossibleEnemiesBasedOnDifficulty.Length && i < 6; i++){
                additionalEnemies.Add(TowerManager.instance.allPossibleEnemiesBasedOnDifficulty[i]);
            }
            return;
        }
        if( Floor < 10){
            for(int i = 4; i < TowerManager.instance.allPossibleEnemiesBasedOnDifficulty.Length && i < 8; i++){
                additionalEnemies.Add(TowerManager.instance.allPossibleEnemiesBasedOnDifficulty[i]);
            }
            return;
        }
    }

    public virtual bool ConditionReached(){
        return true;
    }
}
