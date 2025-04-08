using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{ 
    bool canDamage = false;
    public float warningTime = 1f;
    float warnElapsed;

    void Start()
    {
        canDamage = false;
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if(canDamage == false){
            warnElapsed += Time.deltaTime;
            if(warnElapsed >= warningTime){
                canDamage = true;
                warnElapsed = 0;
            }
        }
    
        if(other.gameObject.CompareTag("Player") && canDamage){
            GlobalManager.Instance.Gun.GetComponent<BulletCounter>().DecreaseBullets(1);
            canDamage = false;
        }
    
    }

}
