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
        bulletsLeft = MaxBullets;
    }
    
    public void DecreaseBullets(int amount){
        if(BulletsLeft - amount <= 0){
            InvokeCounterEmpty();
            return;
        }
        BulletsLeft -= amount;

        
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
    



}
