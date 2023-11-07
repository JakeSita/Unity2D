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
    
    // This will now start from 1 and go towards 0 in the first half of the sine wave
    float percentage = 1 - (Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f);
    percentage = Mathf.Clamp01(percentage);

    // Match the light's color to the WorldLight script
    _light2D.color = colorGradient.Evaluate(percentage);

    // Adjust the light's intensity based on the curve and the same percentage
    _light2D.intensity = intensityCurve.Evaluate(percentage);

    // Assuming you want the light to be enabled when the percentage is below 0.9 (reversed logic)
    _light2D.enabled = percentage < 0.9f; // Adjust the threshold as necessary
}

}