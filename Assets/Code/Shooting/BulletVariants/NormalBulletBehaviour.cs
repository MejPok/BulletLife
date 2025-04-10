using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Bullets/Normal Bullet")]
public class NormalBulletBehaviour : ScriptableBulletBase
{
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

        GameObject bullet = gun.InstantiateFromHere(bulletPrefab, gun.shootPoint.position);
        bullet.GetComponent<Rigidbody2D>().velocity = shotPosition * 20;

        float angle = Mathf.Atan2(shotPosition.y, shotPosition.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        gun.bulletShots.Invoke(Cost);

        SoundManager.Instance.PlaySoundFX(gun.GetComponent<FXchoser>().audioClips[0], gun.transform, 1);
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

