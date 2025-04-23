using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UImanager : MonoBehaviour
{
    public static UImanager uImanager {get; private set;}
    public TextMeshProUGUI announcment;

    void Start()
    {
        uImanager = this;
    }
    public TextMeshProUGUI TextCounter;

    public void UpdateCounterText(int bulletsLeft){
        TextCounter.text = "Bullets: " + bulletsLeft;
    }

    float AnnouncmentTimer;
    public List<string> announcmentQ;
    void Update()
    {
        AnnouncmentTimer += Time.deltaTime;
        if(AnnouncmentTimer > 1.5f){
            AnnouncmentTimer = 0;
            if(announcmentQ.Count > 0){
               announcment.text = announcmentQ[0];
                announcmentQ.Remove(announcment.text); 
            } else {
                announcment.text = "";
            }
        }

        
    }

    public void NewAnnoucment(string text){
        AnnouncmentTimer = 0;
        announcmentQ.Add(text);
        announcment.text = text;
    }

    public Animator panel;

    public void BlackScreen(){
        panel.SetTrigger("blacksreen");
    }
    public TextMeshProUGUI objective;
    public void DifferentObjective(string obj){
        objective.text = obj;
    }

}
