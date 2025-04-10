using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSliderUI : MonoBehaviour
{
    public Slider bulletSlider;
    BulletCounter counter;
    public int maxBullets;
    public int currentBullets;

    void Start()
    {
        bulletSlider = GetComponent<Slider>();
    }

    public void UpdateBulletCount()
    {
        counter = GlobalManager.Instance.Gun.GetComponent<BulletCounter>();
        bulletSlider.maxValue = counter.MaxBulletsMagazine;
        bulletSlider.value = counter.bulletsMagazine;
    }
    void Update()
    {
        UpdateBulletCount();
    }
}
