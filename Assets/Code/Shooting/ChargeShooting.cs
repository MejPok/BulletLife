using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShooting : MonoBehaviour
{
    public int Cost;
    public float ChargeDamageRange = 2f;
    public ChargeUI chargeUI;
    PlayerGun PG;
    void Start()
    {
        PG = GetComponent<PlayerGun>();
        PG.shootToUse.action.performed += StartCounting;
        PG.shootToUse.action.canceled += StopCounting;

    }
    void Update()
    {
        if(count) UpdateProgress();
    }

    public float chargeTime = 3;
    public float loadUpTime = 0.5f;
    public float currentChargeTime = 0f;

    public GameObject chargedBulletPrefab;
    bool count;
    public void UpdateProgress(){
        currentChargeTime += Time.deltaTime;

        if(currentChargeTime >= chargeTime){
            PG.chargeIsReady = true;
            return;
        }

        if(currentChargeTime >= loadUpTime){
            float fill = (currentChargeTime - loadUpTime) / (chargeTime - loadUpTime);
            chargeUI.ImageFill(fill);
        }
    }
    

    public void StartCounting(UnityEngine.InputSystem.InputAction.CallbackContext context){
        count = true;
        chargeUI.ResetChargeUI();
    }
    public void StopCounting(UnityEngine.InputSystem.InputAction.CallbackContext context){
        count = false;
        currentChargeTime = 0f;
        chargeUI.ResetChargeUI();
    }
    



}
