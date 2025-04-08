using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationSender : MonoBehaviour
{
    public void CreateDamageNotificaton(int damage){
        NotifyManager.Instance.CreateDamageNotification(this.gameObject, damage);
    }
}
