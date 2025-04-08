using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyFindPlayer finder;
    Rigidbody2D rb;
    Transform PlayerPos;
    float speed;
    void Start()
    {
        speed = GetComponent<EnemyStats>().baseSpeed;
        finder = GetComponent<EnemyFindPlayer>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        if(finder.playerIsSeen){
            PlayerPos = GlobalManager.Instance.Player.transform;
            Vector2 direction = ((Vector2)PlayerPos.transform.position - (Vector2)transform.position).normalized;
            rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime * speed));
        }
        
    }
}
