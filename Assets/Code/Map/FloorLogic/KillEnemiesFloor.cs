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
        spawner.SpawningSpeedSeconds = Math.Max(1, 4 - (float)(Floor * 0.2f) );
        enemiesToKill = 10 + (int)(Floor % 3 * 2);

        spawner.allowNaturalSpawn = false;
        spawner.enemiesMaxSpawned = enemiesToKill * 2;
        UImanager.uImanager.NewAnnoucment("Kill " + enemiesToKill);
    }

    public override bool ConditionReached()
    {
        enemiesKilled = (spawner.enemiesEver - spawner.enemiesAlive);
        UImanager.uImanager.DifferentObjective("Kill " + (enemiesToKill - enemiesKilled) + " enemies");
        return enemiesKilled >= enemiesToKill;
    }
}
