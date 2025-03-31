using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    public Transform shootPoint;
    public InputActionReference shootToUse;
    public Vector2 shotPosition;
    public GameObject bulletPrefab;
    LineTrajectory trajectory;
    BulletCounter counter;

    public UnityEvent<int> bulletShots;

    bool chargeIsReady;
    ChargeUI chargeUI;
    void Start()
    {
        shootToUse.action.canceled += Shoot;
        shootToUse.action.performed += Aim;
        

        counter = GetComponent<BulletCounter>();


    }
    void Update()
    {
        shotPosition = shootToUse.action.ReadValue<Vector2>();

    }

    void Shoot(UnityEngine.InputSystem.InputAction.CallbackContext callback){
        if(!counter.EnoughBullets()){
            trajectory.EndLine();
            return;
        }

        trajectory.EndLine();

        if(Mathf.Abs(shotPosition.x) +  Mathf.Abs(shotPosition.y) <= 0.3f){
            
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shotPosition * 20;

        float angle = Mathf.Atan2(shotPosition.y, shotPosition.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        bulletShots.Invoke(1);
        
    }

    void Aim(UnityEngine.InputSystem.InputAction.CallbackContext context){
        if(!counter.EnoughBullets()){
            trajectory.EndLine();
            return;
        }

        trajectory = transform.GetComponent<LineTrajectory>();
        trajectory.playerGun = this;
        
        trajectory.StartLine();
    }

}
