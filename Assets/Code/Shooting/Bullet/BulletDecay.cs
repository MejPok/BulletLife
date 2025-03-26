using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDecay : MonoBehaviour
{
    public float DecayTime = 10;
    float CurDecay = 0;
    void Update()
    {
        if (CurDecay < DecayTime){
            CurDecay += Time.deltaTime;

        } else {
            Destroy(gameObject);
        }
        
    }
}
