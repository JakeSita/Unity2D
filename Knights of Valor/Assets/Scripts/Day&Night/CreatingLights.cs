using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CreatingLights : MonoBehaviour
{
    public float duration = 5f; // Duration should match that of the WorldLight for sync

    [SerializeField] private Gradient colorGradient; // Use the same gradient for color change
    [SerializeField] private AnimationCurve intensityCurve; // Curve for light intensity

    private Light2D _light2D;
    private float _startTime;

    private void Awake()
    {
        _light2D = GetComponent<Light2D>();
        _startTime = Time.time;
    }

    private void Update()
    {
        float timeElapsed = Time.time - _startTime;
        float percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;
        percentage = Mathf.Clamp01(percentage);

        // Match the light's color to the WorldLight script
        _light2D.color = colorGradient.Evaluate(percentage);

        // Adjust the light's intensity based on the curve and the same percentage
        _light2D.intensity = intensityCurve.Evaluate(percentage);

        // Toggle the light on and off based on the percentage
        // When the sin wave is at its lowest, the light is off. When it's higher, the light is on.
        _light2D.enabled = percentage > 0.1f; // This threshold can be adjusted
    }
}
