using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldTime
{
    [RequireComponent(typeof(UnityEngine.Rendering.Universal.Light2D))]  // Fixed the typo in the typeof() method

    public class WorldLight : MonoBehaviour
    {
        public float duration = 5f;

        [SerializeField] private Gradient gradient;
        private UnityEngine.Rendering.Universal.Light2D _light;
        private float _startTime;

        private void Awake()
        {
            _light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
            _startTime = Time.time;
        }

        public void Update()
        {
            float timeElapsed = Time.time - _startTime;  // Corrected syntax
            float percentage = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;  // Corrected syntax
            percentage = Mathf.Clamp01(percentage);
            _light.color = gradient.Evaluate(percentage);
        }
    }
}
