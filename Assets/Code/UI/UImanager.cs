using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI TextCounter;

    public void UpdateCounterText(int bulletsLeft){
        TextCounter.text = "Bullets: " + bulletsLeft;
    }
}
