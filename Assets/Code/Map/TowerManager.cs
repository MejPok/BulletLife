using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    void Awake()
    {
        instance = this;
    }
    public bool isPlayerInside;
    public Vector2 LevelLocation;
    public int Floor;
    public GameObject[] allPossibleEnemiesBasedOnDifficulty;

    

    public void EnterTower(){
        TpPlayer();
        isPlayerInside = true;
        GetComponent<FloorManager>().SetUpPlayer();
    }
    void TpPlayer(){
        GlobalManager.Instance.Player.transform.position = LevelLocation;
    }

    public void NextFloor(){
        Floor++;
        TpPlayer();
        isPlayerInside = true;
        GetComponent<FloorManager>().SetUpPlayer();
    }
}
