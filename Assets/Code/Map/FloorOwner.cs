using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOwner : MonoBehaviour
{
    [SerializeReference]public ScriptableFloorLogic floorLogic;
    bool EverythingDone;
    void Start()
    {
        floorLogic.Floor = TowerManager.instance.Floor;
        floorLogic.crateSpawner = GetComponent<SpawnCrates>();
        floorLogic.map = gameObject;
        floorLogic.spawner = GetComponent<EnemiesSpawner>();

        UImanager.uImanager.NewAnnoucment("Floor " + floorLogic.Floor);

        floorLogic.StartFloor();
    }

    void Update()
    {

        if(floorLogic.ConditionReached() && !EverythingDone){
            Debug.Log("Floor Done");
            UImanager.uImanager.NewAnnoucment("Floor " + floorLogic.Floor + " completed");

            TowerManager.instance.NextFloor();
            EverythingDone = true;
        }
        
    }
}
