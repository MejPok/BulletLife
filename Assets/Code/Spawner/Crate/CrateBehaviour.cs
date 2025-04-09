using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour
{
    public int bulletDrop;

    void Start()
    {
        bulletDrop = Random.Range(3, 8);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"){
            other.gameObject.transform.GetChild(1).GetComponent<BulletCounter>().Add(bulletDrop);
            Destroy(gameObject);
        }
    }

}
