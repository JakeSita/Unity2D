using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private HealthSystem ObjectHealth;

    public void Awake()
    {
        ObjectHealth = GetComponentInParent<HealthSystem>();
        slider = GetComponent<Slider>();
    }


    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar(ObjectHealth._healthCur, ObjectHealth._healthMax);
    }
}
