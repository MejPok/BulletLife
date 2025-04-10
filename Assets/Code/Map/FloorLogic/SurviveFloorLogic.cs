using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "FloorLogic/Survive FloorLogic")]
public class SurviveFloorLogic : ScriptableFloorLogic
{
    public float timeAlive;
    public float timeToSurvive;
    public override void ChangeBehaviour()
    {
        timeToSurvive = 10 + (Floor * 5);
        spawner.allowNaturalSpawn = true;
        spawner.SpawningSpeedSeconds = Math.Max(0.8F, 5 - (float)(Floor * 0.8f) );

        UImanager.uImanager.NewAnnoucment($"Survive for {timeToSurvive} seconds");
    }

    public override bool ConditionReached()
    {
        timeAlive += Time.deltaTime;
        return timeAlive >= timeToSurvive;
    }
    
}
