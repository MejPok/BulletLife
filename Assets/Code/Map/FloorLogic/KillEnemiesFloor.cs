using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FloorLogic/KillEnoughEnemies FloorLogic")]
public class KillEnemiesFloor : ScriptableFloorLogic
{
    public int enemiesToKill;
    public int enemiesKilled;
    public override void ChangeBehaviour()
    {
        spawner.SpawningSpeedSeconds = Math.Max(1, 5 - (float)(Floor * 0.8f) );
        enemiesToKill = 5 + (int)(Floor * 5);
        spawner.allowNaturalSpawn = false;
        spawner.enemiesMaxSpawned = enemiesToKill * 2;
        UImanager.uImanager.NewAnnoucment("Kill " + enemiesToKill);
    }

    public override bool ConditionReached()
    {
        enemiesKilled = (spawner.enemiesEver - spawner.enemiesAlive);
        return enemiesKilled >= enemiesToKill;
    }
}
