using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Bersekr")]
public class BersekrLogic : ScriptableEnemy
{
    Vector2 direction;
    bool charging = false;

    float timer;
    public override void MovementLogic(){
        
        if(charging){

            timer += Time.deltaTime;

            if(timer > 4f){
                timer = 0;
                em.canMove = true;
                charging = false;
                return;
            }

            em.gameObject.GetComponent<Rigidbody2D>().MovePosition((Vector2)em.transform.position + (direction * Time.deltaTime * 8f));

        } else {
            CheckForPlayerCharge();
        }
    }

    public void CheckForPlayerCharge(){
        Collider2D[] list = Physics2D.OverlapCircleAll((Vector2)em.gameObject.transform.position, 5f);
        for(int i = 0; i < list.Length; i++){
            if(list[i].gameObject.tag == "Player"){
                ChargePlayer();
                break;
            }
        } 
    }

    void ChargePlayer(){
        em.canMove = false;
        charging = true;
        var PlayerPos = GlobalManager.Instance.Player.transform;
        direction = ((Vector2)PlayerPos.transform.position - (Vector2)em.transform.position).normalized;
    }
}
