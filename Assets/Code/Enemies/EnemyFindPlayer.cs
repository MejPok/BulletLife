using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindPlayer : MonoBehaviour
{
    Transform PlayerPos;

    public bool playerIsSeen;

    void Start()
    {
        
    }

   void FixedUpdate()
   {
        PlayerPos = GlobalManager.globalManager.Player.transform;
        Vector2 direction = (new Vector2(PlayerPos.position.x, PlayerPos.position.y) - (Vector2)transform.position).normalized;
        Vector2 origin = (Vector2)transform.position;
        int layerMask = (1 << 3) | (1 << 0);
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 100f, layerMask);
        Debug.DrawRay(origin, direction * 10, Color.red);
        if(hit){
            if(hit.collider.gameObject.CompareTag("Wall")){
                Debug.Log("" + hit.collider.gameObject.name);
                return;
            }

            if(hit.collider.gameObject.CompareTag("Player")){
                PlayerFound();
            }
            
            
            Debug.Log("" + hit.collider.gameObject.name);

        }

   }

   void PlayerFound(){
        playerIsSeen = true;
   }
}
