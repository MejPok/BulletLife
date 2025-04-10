using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Bullets/FireCharge Bullet")]
public class FireCharge : ScriptableBulletBase
{
    public float AoeRange;
    public override void CreateBullet(Vector2 shotPosition)
    {
        if (!GotEnoughBulletsForMe()) return;

        if(TryDependableCharge(shotPosition)){
            return;
        }

        if(Mathf.Abs(shotPosition.x) +  Mathf.Abs(shotPosition.y) <= 0.3f){
            return;
        }


        gun.trajectory.EndLine();

        SoundManager.Instance.PlaySoundFX(gun.GetComponent<FXchoser>().audioClips[0], gun.transform, 1);

        gun.bulletShots.Invoke(Cost);
        

        Debug.Log("shoot charged");

        
        var bullet = gun.InstantiateFromHere(bulletPrefab, gun.shootPoint.position);

        bullet.GetComponent<Rigidbody2D>().velocity = gun.shotPosition * 10;
        var damager = bullet.GetComponent<ChargedDamage>();

        damager.range = AoeRange;
        damager.damage = Damage;

        float angle = Mathf.Atan2(shotPosition.y, shotPosition.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
    }

    public override void OnJoyStickAim(InputAction.CallbackContext callback)
    {
        throw new System.NotImplementedException();
    }

    public override void OnJoyStickShot(InputAction.CallbackContext callback)
    {
        throw new System.NotImplementedException();
    }
    
}
