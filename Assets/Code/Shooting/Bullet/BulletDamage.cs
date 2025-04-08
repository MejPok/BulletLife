using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;

    void Start()
    {
        damage = Math.Max((int)GetComponent<Rigidbody2D>().velocity.magnitude - 15, 1);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Wall"){
            
            if(other.gameObject.GetComponent<EnemyHP>() != null){
                var enemy = other.gameObject.GetComponent<EnemyHP>();
                enemy.ReduceHP(damage);
            }

            Destroy(gameObject);
        }

            
    }
}


    
