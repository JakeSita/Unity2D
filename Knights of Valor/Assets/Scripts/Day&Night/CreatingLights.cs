using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CreatingLights : MonoBehaviour
{
    public float duration = 5f;

    [SerializeField] private Gradient colorGradient; // Gradient for light color
    [SerializeField] private AnimationCurve intensityCurve; // Curve for light intensity

    private Light2D _light2D;
    private float _startTime;

    private void Awake()
    {
        _light2D = GetComponent<Light2D>();
        _startTime = Time.time;
    }

    public void Update()
    {
        float timeElapsed = Time.time - _startTime;
        float percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;
        percentage = Mathf.Clamp01(percentage);

        _light2D.color = colorGradient.Evaluate(percentage); // Adjust the light's color based on the gradient
        _light2D.intensity = intensityCurve.Evaluate(percentage); // Adjust the light's intensity based on the curve
    }
}
