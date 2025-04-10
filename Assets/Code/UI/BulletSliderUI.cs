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
        counter = GlobalManager.Instance.Gun.GetComponent<BulletCounter>();

        bulletSlider.maxValue = counter.MaxBullets;
        bulletSlider.value = counter.BulletsLeft;
    }

    public void UpdateBulletCount()
    {
        bulletSlider.maxValue = counter.MaxBullets;
        bulletSlider.value = counter.BulletsLeft;
    }
    void Update()
    {
        counter = GlobalManager.Instance.Gun.GetComponent<BulletCounter>();
        UpdateBulletCount();
    }
}
