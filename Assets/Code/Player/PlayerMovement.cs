using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    Rigidbody2D rb;
    BulletCounter counter;

    [Header("Movement Parameters")]
    public Vector2 movement;
    public float speed = 20;
    public bool canMove = true;

    public InputActionReference moveActionToUse;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement = moveActionToUse.action.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        MoveMyPlayer(movement);
    }

    void MoveMyPlayer(Vector2 direction)
    {
        if (counter != null && counter.EnoughBulletsSum())
            canMove = true;

        if (canMove)
            rb.velocity = FinalMovement();
        else
            rb.velocity = Vector2.zero;
    }

    [Header("Knockback Parameters")]
    public float knockbackDecay;
    public Vector2 knockback;
    Vector2 FinalMovement(){

        knockback = Vector2.Lerp(knockback, Vector2.zero, Time.fixedDeltaTime * knockbackDecay);
        return movement * speed + knockback;

    }

    public void StopMovementBullets(BulletCounter counter){
        this.counter = counter;
        canMove = false;
    }

    public void AddForceToPlayer(Vector2 direction, float force){
        knockback = -direction * force;
    }
}
