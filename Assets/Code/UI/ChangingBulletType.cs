using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingBulletType : MonoBehaviour
{
    public void ChangeBulletType(int index){
        var list = GlobalManager.Instance.Gun.GetComponent<PlayerGun>().shootingBehaviours;
        GlobalManager.Instance.Gun.GetComponent<PlayerGun>().currentBulletType = list[index];
    }

}
