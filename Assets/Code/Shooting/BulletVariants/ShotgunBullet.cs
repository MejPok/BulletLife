using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Bullets/Shotgun Bullet")]
public class ShotgunBullet : ScriptableBulletBase
{
    public float force;
    public int BulletAmount;
    public float maxAngle;
    float AngleDifference;
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

        Vector2 direction = shotPosition.normalized;
        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        var bullets = new List<GameObject>();

        for(int i = 0; i < BulletAmount; i++){
            bullets.Add(gun.InstantiateFromHere(bulletPrefab, gun.shootPoint.position));
        }  


        float curAngle = maxAngle;
        float AngleDifference = (maxAngle * 2) / (BulletAmount - 1);

        foreach(GameObject bullet in bullets){
            ForeachBullet(bullet, shotPosition, baseAngle - curAngle);
            curAngle -= AngleDifference;
        }
        



        

        GlobalManager.Instance.Player.GetComponent<PlayerMovement>().AddForceToPlayer(shotPosition, force);

        gun.bulletShots.Invoke(Cost);

        SoundManager.Instance.PlaySoundFX(gun.GetComponent<FXchoser>().audioClips[0], gun.transform, 1);
    }

    void ForeachBullet(GameObject bullet, Vector2 shotPosition, float angle){
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float rad = angle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

        bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * 20;
        bullet.GetComponent<BulletDamage>().damage = Damage;
    }
    
}
