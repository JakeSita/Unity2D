using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{

    public Slider slider;

    public HealthSystem health;
    

    public void Awake()
    {
        SetMaxHealth(health._healthMax);
    }

    public void Update()
    {
        SetHealth(health._healthCur);
    }


    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


   public void SetHealth(float health) {
        slider.value = health;

   }

}
