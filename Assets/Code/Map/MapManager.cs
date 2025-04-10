using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MapManager : MonoBehaviour, IGetResponseUI
{
    public static MapManager instance { get; private set; }
    public GameObject TowerEnterUI;

    public List<string> uiRequest;
    public void EnterMapUI(string where)
    {
        uiRequest.Add(where);

        if(where == "Tower"){
            TowerEnterUI.SetActive(true);
            TowerEnterUI.GetComponent<UImessageBox>().respondTo = this;
        }
    }

    public void ExitMapUI(string where){

        if(uiRequest.Contains(where)){
            uiRequest.Remove(where);
        }

        if(where == "Tower"){
            TowerEnterUI.SetActive(false);
        }

    }

    void Awake()
    {
        instance = this;
    }

    public void GotAccepted(bool accepted)
    {
        if(uiRequest[0] == "Tower" && accepted){

            transform.GetChild(0).GetComponent<TowerManager>().EnterTower();

        }

        ExitMapUI(uiRequest[0]);
    }

}
