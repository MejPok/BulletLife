using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public static FloorManager instance;
    void Start()
    {
        instance = this;
    }
    public CinemachineConfiner2D cameraConfiner;
    TowerManager manager;
    GameObject Player;

    [Header("Maps")]
    public List<GameObject> mapPool;

    public GameObject currentMap;

    public List<ScriptableFloorLogic> possibleLogic;
    public void SetUpPlayer()
    {
        manager = GetComponent<TowerManager>();

        Player = GlobalManager.Instance.Player;
        if(currentMap != null){
            Destroy(currentMap);
        }
        currentMap = ChooseRandomMap();

        cameraConfiner.m_BoundingShape2D = currentMap.GetComponent<MAPINFO>().cage;
        

     }

    GameObject ChooseRandomMap(){
        var map = Instantiate(mapPool[0], manager.LevelLocation, Quaternion.identity);
        map.GetComponent<FloorOwner>().floorLogic = Instantiate(possibleLogic[UnityEngine.Random.Range(0, possibleLogic.Count)]);
        
        return map;
    }
}
