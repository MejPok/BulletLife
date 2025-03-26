using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 movement;
    public float speed = 20;

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
    void MoveMyPlayer(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime * speed));
    }
}
