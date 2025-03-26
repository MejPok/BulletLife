using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ChargeUI : MonoBehaviour
{
    public PlayerGun PG;
    public float chargeUItime = 3;
    public float loadUpTime = 0.5f;
    public float currentChargeTime = 0f;
    public bool isCharged;

    bool count;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        PG.shootToUse.action.performed += StartCounting;
        PG.shootToUse.action.canceled += StopCounting;
    }
    public void UpdateProgress(){
        currentChargeTime += Time.deltaTime;
        if(currentChargeTime >= chargeUItime){
            isCharged = true;
            return;
        }
        if(currentChargeTime >= loadUpTime){
            image.fillAmount = (currentChargeTime - loadUpTime) / (chargeUItime - loadUpTime);
        }
    }
    void Update()
    {
        if(count) UpdateProgress();
    }

    public void ResetChargeUI(){
        image.fillAmount = 0;
        currentChargeTime = 0;
    }

    void StartCounting(UnityEngine.InputSystem.InputAction.CallbackContext context){
        count = true;
    }
    void StopCounting(UnityEngine.InputSystem.InputAction.CallbackContext context){
        count = false;
        currentChargeTime = 0f;
        image.fillAmount = 0f;
    }

}
