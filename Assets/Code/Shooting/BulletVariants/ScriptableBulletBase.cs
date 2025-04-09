using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptableBulletBase : ScriptableObject
{
    public int Damage;
    public int Cost;
    protected PlayerGun gun;
    public GameObject bulletPrefab;
    public ScriptableBulletBase dependableCharged;
    ScriptableBulletBase TempDependableCharged;

    public void getRef(PlayerGun gun){
        this.gun = gun;
    }

    public virtual bool TryDependableCharge(Vector2 shotPosition){
        if(dependableCharged != null){
            if(gun.chargeIsReady && gun.counter.EnoughBullets(dependableCharged.Cost - 1)){
                gun.chargeIsReady = false;
                TempDependableCharged = Instantiate(dependableCharged);
                TempDependableCharged.Cost -= 1;
                TempDependableCharged.getRef(gun);
                TempDependableCharged.CreateBullet(shotPosition);
                return true;
            }
        }
        return false;
    }
    public virtual void CreateBullet(Vector2 shotPosition)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnJoyStickAim(InputAction.CallbackContext callback)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnJoyStickShot(InputAction.CallbackContext callback)
    {
        throw new System.NotImplementedException();
    }


}
