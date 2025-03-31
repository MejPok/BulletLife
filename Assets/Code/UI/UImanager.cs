using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public static UImanager uImanager {get; private set;}

    void Start()
    {
        uImanager = this;
    }
    public TextMeshProUGUI TextCounter;

    public void UpdateCounterText(int bulletsLeft){
        TextCounter.text = "Bullets: " + bulletsLeft;
    }
}
