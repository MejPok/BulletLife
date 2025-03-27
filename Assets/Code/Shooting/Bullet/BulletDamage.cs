using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;
    

    void Start()
    {
        damage = (int)GetComponent<Rigidbody2D>().velocity.magnitude - 5;
        if(damage > 15) damage = 15;
        if(damage < 0) damage = 0;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            if(other.gameObject.GetComponent<EnemyHP>() != null){
                var enemy = other.gameObject.GetComponent<EnemyHP>();
                enemy.ReduceHP(damage);
                Destroy(gameObject);

                
            }
        }
    }

}
    
