using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyFindPlayer finder;
    Rigidbody2D rb;
    Transform PlayerPos;
    float speed;

    public bool canMove;
    [SerializeReference]public ScriptableEnemy EnemyLogic;

    void Start()
    {
        speed = GetComponent<EnemyStats>().baseSpeed;
        finder = GetComponent<EnemyFindPlayer>();
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        if(EnemyLogic != null){
            EnemyLogic = Instantiate(EnemyLogic);
        }
        
    }
    void FixedUpdate()
    {
        if(finder.playerIsSeen && canMove){
            PlayerPos = GlobalManager.Instance.Player.transform;
            Vector2 direction = ((Vector2)PlayerPos.transform.position - (Vector2)transform.position).normalized;
            rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime * speed));
        }

        if(EnemyLogic != null && finder.playerIsSeen){
            EnemyLogic.em = this;
            EnemyLogic.MovementLogic();
        }
        
    }

    
}
