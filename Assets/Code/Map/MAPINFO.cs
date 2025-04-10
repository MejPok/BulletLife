using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAPINFO : MonoBehaviour
{
    public PolygonCollider2D cage;
    public Vector2 pointLow;
    public Vector2 pointHigh;
    void Start()
    {
        cage = transform.GetChild(0).GetComponent<PolygonCollider2D>();
        pointLow = (Vector2)transform.GetChild(0).transform.GetChild(0).transform.position;
        pointHigh = (Vector2)transform.GetChild(0).transform.GetChild(1).transform.position;
    }
}
