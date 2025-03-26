using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int MaxHP;
    public int HP;

    void Start()
    {
        HP = MaxHP;
    }

    public void ReduceHP(int amount){
        Debug.Log("Enemy got hit for " + amount);
        HP -= amount;
        if(HP <= 0){
            Dead();
        }
    }

    public void Dead(){
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}
