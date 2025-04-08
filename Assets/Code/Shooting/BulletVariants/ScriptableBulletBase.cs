using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptableBulletBase : ScriptableObject
{
    protected PlayerGun gun;
    public GameObject bulletPrefab;

    public void getRef(PlayerGun gun){
        this.gun = gun;
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
