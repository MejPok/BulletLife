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

    public UnityEvent<BulletCounter> BulletsReachedZero;

    void Start()
    {
        BulletsLeft = MaxBullets;
        OnBulletsChange();
    }
    
    public void DecreaseBullets(int amount){
        BulletsLeft -= amount;
        SoundManager.Instance.PlaySoundFX(GetComponent<FXchoser>().audioClips[1], transform, 1);
        Debug.Log("player hit");
        if(BulletsLeft <= 0){
            InvokeCounterEmpty();
        }

        
    }

    public bool EnoughBullets(int amount = 0){
        return BulletsLeft - amount >= 0;
    }

    void InvokeCounterEmpty(){
        BulletsReachedZero.Invoke(this);
    }
    void OnBulletsChange(){
        UImanager.uImanager.UpdateCounterText(BulletsLeft);
    }
    
    public void Add(int amount = 1){
        if(BulletsLeft + amount > MaxBullets){ return;}
        BulletsLeft += amount;
    }



}
