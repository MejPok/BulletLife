using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOwner : MonoBehaviour
{
    [SerializeReference]public ScriptableFloorLogic floorLogic;

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

        if(floorLogic.ConditionReached()){
            Debug.Log("Floor Done");
            TowerManager.instance.NextFloor();
        }
        
    }
}
