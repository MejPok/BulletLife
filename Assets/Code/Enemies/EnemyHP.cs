using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    int MaxHP;
    int HP;
    NotificationSender sender;

    public EnemiesSpawner DeathCaller { get; set; }

    void Start()
    {
        MaxHP = (int)GetComponent<EnemyStats>().baseHP;
        HP = MaxHP;
        sender = GetComponent<NotificationSender>();
    }

    public void ReduceHP(int amount){
        Debug.Log("Enemy got hit for " + amount);

        AfterHitLogic(amount);

        HP -= amount;
        if(HP <= 0){
            Dead();
        }
    }

    public void Dead(){
        Debug.Log("Enemy died");

        SoundManager.Instance.PlaySoundFX(GetComponent<FXchoser>().audioClips[1], transform, 1);

        int bulletDrop = (int)GetComponent<EnemyStats>().bulletDrop;
        if(Random.Range(0, 100) >= 70) bulletDrop++;
        
        GlobalManager.Instance.Gun.GetComponent<BulletCounter>().Add(bulletDrop);
        DeathCaller.EnemyDown();
        Destroy(gameObject);
    }

    void AfterHitLogic(int damage){

        SoundManager.Instance.PlaySoundFX(GetComponent<FXchoser>().audioClips[0], transform, 1);
        
        sender.CreateDamageNotificaton(damage);
    }
}
