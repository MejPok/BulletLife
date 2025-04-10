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
            if(value < 0){
                 bulletsLeft = 0; 
                InvokeCounterEmpty();
                 return;
            }

            bulletsLeft = value;
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
        bulletsMagazine -= amount;
        SoundManager.Instance.PlaySoundFX(GetComponent<FXchoser>().audioClips[1], transform, 1);
        Debug.Log("player hit");

        if(!EnoughBulletsSum()) InvokeCounterEmpty();
        
    }

    public bool EnoughBulletsInMagazine(int amount = 0){
        return bulletsMagazine - amount >= 0;
    }
    public bool EnoughBulletsSum(int amount = 0){
        return bulletsMagazine + BulletsLeft - amount >= 0;
    }

    void InvokeCounterEmpty(){
        BulletsReachedZero.Invoke(this);
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
    }

    public void ReloadToMagazine(int amount){
        Debug.Log("trying to reload " + amount);
        if(amount > BulletsLeft){
            amount = BulletsLeft;
        }

        if(bulletsMagazine + amount <= MaxBulletsMagazine && BulletsLeft - amount >= 0){
            bulletsMagazine += amount;
            BulletsLeft -= amount;
        }

        int difference = MaxBulletsMagazine - bulletsMagazine;

        if(difference <= amount && difference <= BulletsLeft){
            BulletsLeft -= difference;
            bulletsMagazine += difference;

        }

        
        


        
    }



}
