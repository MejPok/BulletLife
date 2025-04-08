using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyRotate : MonoBehaviour
{
    public float rotationSpeed = 3f;
    void Update()
    {
        Transform PlayerPos = GlobalManager.Instance.Player.transform;
        Vector2 direction = PlayerPos.position - transform.position;
        
        // Calculate the angle to rotate towards
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Smoothly rotate towards the angle
        float step = rotationSpeed * Time.deltaTime;
        float currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, angle, step);
        
        // Apply the rotation
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
}
