using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnter : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            MapManager.instance.EnterMapUI("Tower");
        }
    }
}
