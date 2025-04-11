using System;
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
        UImanager.uImanager.BlackScreen();

    }
    void TpPlayer(){
        GlobalManager.Instance.Player.transform.position = LevelLocation;
    }
    void TpPlayer(Vector2 pos){
        GlobalManager.Instance.Player.transform.position = pos;
    }

    public void NextFloor(){
        notifSend = false;
        waitingInBetweenRounds = true;
        waitTimer = 0f;
        GetComponent<FloorManager>().currentMap.GetComponent<EnemiesSpawner>().DestroyAllEnemies();
    }
    public float waitFor;
    bool waitingInBetweenRounds;
    float waitTimer;
    bool notifSend;
    void Update()
    {
        if(waitingInBetweenRounds){
            waitTimer += Time.deltaTime;

            if(waitTimer > 3.2f && !notifSend){

                UImanager.uImanager.BlackScreen();
                notifSend = true;

            }
            if(waitTimer >= waitFor){
                ContinueInRound();
                waitTimer = 0;
                waitingInBetweenRounds = false;
            }
        }
        
        
    }

    private void ContinueInRound()
    {
        Floor++;
        TpPlayer();
        isPlayerInside = true;
        GetComponent<FloorManager>().SetUpPlayer();
    }

    public void LeaveTower(){
        if(isPlayerInside){
            isPlayerInside = false;
            Floor = 0;
            TpPlayer(new Vector2(0, 0));
            GetComponent<FloorManager>().DeleteFloor();
            waitingInBetweenRounds = false;
        }else {
            TpPlayer(new Vector2(0, 0));
        }
    }
}
