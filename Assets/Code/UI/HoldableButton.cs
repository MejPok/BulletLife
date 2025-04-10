using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool holdingDown;
    public void OnPointerDown(PointerEventData eventData)
    {
        holdingDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(timer < 0.3f){
            GlobalManager.Instance.Gun.GetComponent<BulletCounter>().ReloadToMagazine(1);
        } else {
            GlobalManager.Instance.Gun.GetComponent<BulletCounter>().ReloadToMagazine((int)(timer * 10));
        }
        timer = 0;
        
        holdingDown = false;
    }

    float timer;

    void Update()
    {
        if(!holdingDown) return;
        timer += Time.deltaTime;
        if(timer < 0.2f){
            return;
        }

        
    }
}

