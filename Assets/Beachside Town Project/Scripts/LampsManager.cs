using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class LampsManager : MonoBehaviour
{
    [SerializeField] private bool areLightsOn = true;
    
    [Header("Lamps")]
    [SerializeField] private List<GameObject> lamps;
    [SerializeField] private List<Light> lampLights;
    [SerializeField] private Material lampMaterial;
    [SerializeField] private Color lampEmissionColor;
    [SerializeField] private float lampIntensityOn = 2.0f;
    [SerializeField] private float lampIntensityOff = 0.0f;

    [Header("Windows")]
    [SerializeField] private Material windowMaterial;
    [SerializeField] private Color windowEmissionColor;
    [SerializeField] private float windowIntensityOn = 2.0f;
    [SerializeField] private float windowIntensityOff = 0.0f;

    [Header("External")]
    [SerializeField] private float timeOfDay;
    [SerializeField] private float morningHour = 7f;
    [SerializeField] private float nightHour = 18f;
    [SerializeField] private AzureTimeController azureTimeController;


    private void Awake()
    {
        SetLightsList();
        TurnOffLights();
    }

    private void SetLightsList()
    {
        for (int i = 0; i < lamps.Count; i++)
        {
            var light = lamps[i].GetComponentInChildren<Light>();
            lampLights.Add(light);
        }
    }

    private void Update() {
        timeOfDay = azureTimeController.GetTimeline();

        var isDayTime = (timeOfDay > morningHour) && (timeOfDay < nightHour);

        if ( !isDayTime && !areLightsOn) TurnOnLights();
        if ( isDayTime && areLightsOn) TurnOffLights();
    }

    private void TurnOnLights()
    {
        lampMaterial.SetColor("_EmissionColor", lampEmissionColor * lampIntensityOn);
        windowMaterial.SetColor("_EmissionColor", windowEmissionColor * windowIntensityOn);
        for (int i = 0; i < lampLights.Count; i++)
        {
            lampLights[i].enabled = true;
        }
        areLightsOn = true;
    }

    private void TurnOffLights()
    {
        lampMaterial.SetColor("_EmissionColor", lampEmissionColor * lampIntensityOff);
        windowMaterial.SetColor("_EmissionColor", windowEmissionColor * windowIntensityOff);
        for (int i = 0; i < lampLights.Count; i++)
        {
            lampLights[i].enabled = false;
        }
        areLightsOn = false;
    }
}
