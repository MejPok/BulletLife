using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedDamage : MonoBehaviour
{
    public float range = 3f;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Wall"){
            if(other.gameObject.GetComponent<EnemyHP>() == null){
                Destroy(gameObject);
            }
            
                
            Debug.Log(gameObject.name);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, 1 << 6);

            Debug.Log(colliders.Length);

            foreach(var col in colliders){
                if(col.gameObject.GetComponent<EnemyHP>() != null){
                    col.gameObject.GetComponent<EnemyHP>().ReduceHP(20);
                }
            }
                
            Destroy(gameObject);

                
            
        }
    }

    void OnDrawGizmos()
    {
        // Draw the detection circle in the Scene view for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
