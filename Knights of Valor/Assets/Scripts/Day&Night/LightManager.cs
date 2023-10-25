using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight; 
    [SerializeField] private LightShade Present; 

    [SerializeField, Range(0,24)] private float TimeOfDay; 

    private void OnValidate()
    {
        if(DirectionalLight != null)
        {
            return;
        }
        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun; 
        }
        else 
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>(); 
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light; 
                    return; 
                }
            }
        }
    }

    private void Update()
    {
        if(Present == null)
        {
            return; 
        }
        if(Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime; 
            TimeOfDay %= 24; 
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    public void UpdateLighting(float timePresent)
    {
        RenderSettings.ambientLight = Present.AmbientColor.Evaluate(timePresent);
        // No direct setting for fogColor in some versions of Unity. So ensure you have the correct version or handle it properly.
        RenderSettings.fog = true;
        RenderSettings.fogColor = Present.FogColor.Evaluate(timePresent);
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Present.DirectionalColor.Evaluate(timePresent);
            DirectionalLight.transform.localRotation = Quaternion.Euler((timePresent * 360f) - 90f, 170f, 0);
        }
    }
}