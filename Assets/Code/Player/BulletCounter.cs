using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BulletCounter : MonoBehaviour
{
    public UnityEvent BulletZero;
    public UnityEvent<int> BulletShot;
    public int BulletCount;
    void Start()
    {
        BulletCount = 20;
        BulletShot.Invoke(BulletCount);
    }

    public bool DecreaseBullet(int bulletCount = 1){
        BulletCount -= bulletCount;
        
        if(BulletCount == 0){
            return true;
        }
        BulletShot.Invoke(BulletCount);
        return !isCounterEmpty();
    }
    public bool isCounterEmpty(){
        BulletShot.Invoke(BulletCount);
        if(BulletCount <= 0){
            BulletZero?.Invoke();
            return true;
        } else {
            return false;
        }
        
    }
    public void LogBulletsEmpty(){
        BulletCount = 0;
        BulletShot.Invoke(BulletCount);
        Debug.Log("Empty");

    }



}
