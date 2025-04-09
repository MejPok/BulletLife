using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Bersekr")]
public class BersekrLogic : ScriptableEnemy
{
    
    Vector2 direction;
    bool charging = false;

    float timer;
    float warmUpTimer;

    float dashCooldown;
    

    public AudioClip[] audioClips;
    public override void MovementLogic(){
        
        if(charging){
            warmUpTimer += Time.deltaTime;
            if(warmUpTimer > 0.6f){
                MoveEnemy();
            }

        } else {
            CheckForPlayerCharge();
        }
    }

    void MoveEnemy(){

            if(!playedSound){
                PlaySoundOnChargeFirst(); 
                var PlayerPos = GlobalManager.Instance.Player.transform;
                direction = ((Vector2)PlayerPos.transform.position - (Vector2)em.transform.position).normalized;
            } 

            timer += Time.deltaTime;

            if(timer > 3f){
                timer = 0;
                em.canMove = true;
                charging = false;
                return;
            }

            em.gameObject.GetComponent<Rigidbody2D>().MovePosition((Vector2)em.transform.position + (direction * Time.deltaTime * 8f));
    }

    bool playedSound;
    void PlaySoundOnChargeFirst(){
        SoundManager.Instance.PlaySoundFX(audioClips[1], em.gameObject.transform, 0.3f);
        playedSound = true;
    }

    public void CheckForPlayerCharge(){
        if(dashCooldown <= 2f){
            dashCooldown += Time.deltaTime;
            return;
        }
        Collider2D[] list = Physics2D.OverlapCircleAll((Vector2)em.gameObject.transform.position, 5f);
        for(int i = 0; i < list.Length; i++){
            if(list[i].gameObject.tag == "Player"){
                ChargePlayer();
                break;
            }
        } 
    }

    void ChargePlayer(){
        dashCooldown = 0f;
        playedSound = false;
        warmUpTimer = 0;
        timer = 0;
        em.canMove = false;
        charging = true;
        SoundManager.Instance.PlaySoundFX(audioClips[0], em.gameObject.transform, 1);
    }
}
