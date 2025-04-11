using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class BulletCounter : MonoBehaviour
{
    public int bulletsLeft;
    [SerializeField] public int BulletsLeft { 
        get
        { 
            
            return bulletsLeft; 
        } 
        set {
            OnBulletsChange();
            bulletsLeft = value;

            if(value <= 0 || bulletsLeft <= 0){
                 bulletsLeft = 0; 
                 if(!EnoughBulletsSum()){
                    InvokeCounterEmpty();
                 }
                 OnBulletsChange();
                 return;
            }
            OnBulletsChange();
        }

        }

    public int MaxBullets;
    public int bulletsMagazine;
    public int MaxBulletsMagazine;

    public UnityEvent<BulletCounter> BulletsReachedZero;

    void Start()
    {
        bulletsMagazine = MaxBulletsMagazine;
        BulletsLeft = MaxBullets;
        OnBulletsChange();
    }
    
    public void DecreaseBullets(int amount){
        if(bulletsMagazine <= 0){
            BulletsLeft -= amount;
        } else {
            bulletsMagazine -= amount;
        }
        
        SoundManager.Instance.PlaySoundFX(GetComponent<FXchoser>().audioClips[1], transform, 1);

        if(!EnoughBulletsSum()) InvokeCounterEmpty();
        
        OnBulletsChange();
    }

    public bool EnoughBulletsInMagazine(int amount = 0){
        return bulletsMagazine - amount >= 0;
    }
    public bool EnoughBulletsSum(int amount = 0){
        return bulletsMagazine + BulletsLeft - amount > 0;
    }

    void InvokeCounterEmpty(){
        BulletsReachedZero.Invoke(this);
        if(newlifeChance == false){
            newlifeChance = true;
        }
        
    }
    bool newlifeChance;
    float timer;

    void Update()
    {
        if(newlifeChance == false){
            if(!EnoughBulletsSum()){
                InvokeCounterEmpty();
            }
        }
        if(newlifeChance){
            timer += Time.deltaTime;
            if(timer > 2f){
                newlifeChance = false;
                TowerManager.instance.LeaveTower();
                bulletsLeft = MaxBullets;
                bulletsMagazine = MaxBulletsMagazine;
            }
        }
        
    }
    void OnBulletsChange(){
        UImanager.uImanager.UpdateCounterText(BulletsLeft);
    }
    
    public void Add(int amount = 1){
        if(BulletsLeft + amount > MaxBullets){  
            BulletsLeft = MaxBullets; 
            return;
        }
        BulletsLeft += amount;
        newlifeChance = false;
    }

    public void ReloadToMagazine(int amount){
        Debug.Log("trying to reload " + amount);
        
        if(amount > BulletsLeft){
            amount = BulletsLeft;
            
        }

        if(bulletsMagazine + amount <= MaxBulletsMagazine && BulletsLeft - amount >= 0){
            bulletsMagazine += amount;
            BulletsLeft -= amount;
            return;
        }

        int difference = MaxBulletsMagazine - bulletsMagazine;

        if(difference <= amount && difference <= BulletsLeft){
            bulletsMagazine += difference;
            BulletsLeft -= difference;
            

        }
        OnBulletsChange();
        
        


        
    }



}
