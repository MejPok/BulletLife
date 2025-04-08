using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingBehaviour
{
    public virtual void CreateBullet(){

    }
    public virtual void OnJoyStickAim(UnityEngine.InputSystem.InputAction.CallbackContext callback){

    }
    public virtual void OnJoyStickShot(UnityEngine.InputSystem.InputAction.CallbackContext callback){
        
    }

    
    
}
