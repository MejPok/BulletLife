using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyManager : MonoBehaviour
{
    public static NotifyManager Instance { get; private set; }
    public List<GameObject> DamageNotifiers;
    public GameObject DamageNotificationPrefab;

    void Start()
    {
        DamageNotifiers = new List<GameObject>();
        Instance = this;
    }

    public void CreateDamageNotification(GameObject sender, int damage){
        var notification = Instantiate(DamageNotificationPrefab, new Vector2(sender.transform.position.x, sender.transform.position.y + 1) , Quaternion.identity);
        notification.GetComponent<NotificationBehaviour>().detail = "" + (-1*damage);
    }


}
