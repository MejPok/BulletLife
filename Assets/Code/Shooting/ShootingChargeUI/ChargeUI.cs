using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ChargeUI : MonoBehaviour
{

    public bool isCharged;

    bool count;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void ImageFill(float fill){
        image.fillAmount = fill;
    }
    
    public void ResetChargeUI(){
        image.fillAmount = 0;
    }

}
