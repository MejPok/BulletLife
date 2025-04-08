using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationBehaviour : MonoBehaviour
{
    public string detail;

    TextMeshPro textMeshPro;
    float decayLimit = 2f;
    float decay;
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text = detail;
    }
    void Update()
    {
        decay += Time.deltaTime;
        if(decay >= decayLimit){
            Destroy(this.gameObject);
        }
        textMeshPro.color = new Color(0, 0, 0, decayLimit - decay);
        transform.transform.Translate(0, 0.01f, 0, Space.Self);
        
    }
}
