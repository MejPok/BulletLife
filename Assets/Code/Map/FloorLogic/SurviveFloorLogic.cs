using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FloorLogic/Survive FloorLogic")]
public class SurviveFloorLogic : ScriptableFloorLogic
{
    public float timeAlive;
    public float timeToSurvive;
    public override void ChangeBehaviour()
    {
        timeToSurvive = Floor * 25;
        spawner.allowNaturalSpawn = true;
        spawner.SpawningSpeedSeconds = 4 - (float)(Floor * 0.8f);
        UImanager.uImanager.NewAnnoucment($"Survive for {timeToSurvive} seconds");
    }

    public override bool ConditionReached()
    {
        timeAlive += Time.deltaTime;
        return timeAlive >= timeToSurvive;
    }
    
}
