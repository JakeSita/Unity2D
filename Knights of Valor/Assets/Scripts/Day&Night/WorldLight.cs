using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WorldTime
{
    public class WorldLight : MonoBehaviour
    {
        public float duration = 5f;
        public float startDelay = 2f; // Delay in seconds before the light starts changing

        private Light2D _light;
        private float _startTime;
        private bool _startedChanging = false;
        private Color _startColor = new Color(1f, 0.64f, 0.34f, 1f); // Light orange color with full alpha

        private void Awake()
        {
            _light = GetComponent<Light2D>();
            _light.color = _startColor; // Set the initial color
            _startTime = Time.time;
        }

        public void Update()
        {
            // Wait for the start delay to pass
            if (Time.time - _startTime < startDelay && !_startedChanging)
            {
                return;
            }

            if (!_startedChanging)
            {
                // Reset the start time to the current time for the transition to start smoothly
                _startTime = Time.time;
                _startedChanging = true;
            }

            float timeElapsed = Time.time - _startTime;
            float percentage = timeElapsed / duration;

            if (percentage >= 1f)
            {
                _light.enabled = false; // Disable the light after the transition is complete
                return;
            }

            // Interpolate the alpha value of the light color from 1 to 0
            _light.color = new Color(_startColor.r, _startColor.g, _startColor.b, Mathf.Lerp(1f, 0f, percentage));
        }
    }
}
