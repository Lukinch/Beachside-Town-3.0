using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class FireLogsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> firepits;

    [Header("Childrens")]
    [SerializeField] private List<Light> fireLight;
    [SerializeField] private List<ParticleSystem> fireVFX;
    [SerializeField] private List<ParticleSystem> smokeVFX;

    [Header("External")]
    [SerializeField] private float timeOfDay;
    [SerializeField] private float morningHour = 7f;
    [SerializeField] private float nightHour = 18f;
    [SerializeField] private AzureTimeController azureTimeController;

    private bool areFiresOn = true;

    private void Awake() {
        
        for (int i = 0; i < firepits.Count; i++)
        {
            fireLight.Add(firepits[i].GetComponentInChildren<Light>());
            var partciles = firepits[i].GetComponentsInChildren<ParticleSystem>();
            foreach (var item in partciles)
            {
                if (item.CompareTag("FireVFX")) fireVFX.Add(item);
                if (item.CompareTag("FireSmokeVFX")) smokeVFX.Add(item);
            }
        }
    }

    private void Update() {
        timeOfDay = azureTimeController.GetTimeline();

        var isDayTime = (timeOfDay > morningHour) && (timeOfDay < nightHour);

        if ( !isDayTime && !areFiresOn) TurnOnFires();
        if ( isDayTime && areFiresOn) TurnOffFires();
    }

    private void TurnOnFires()
    {
        for (int i = 0; i < fireLight.Count; i++)
        {
            fireLight[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < fireVFX.Count; i++)
        {
            fireVFX[i].Play();
        }
        areFiresOn = true;
    }

    private void TurnOffFires()
    {
        for (int i = 0; i < fireLight.Count; i++)
        {
            fireLight[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < fireVFX.Count; i++)
        {
            fireVFX[i].Stop();
        }
        for (int i = 0; i < smokeVFX.Count; i++)
        {
            smokeVFX[i].Play();
        }
        areFiresOn = false;
    }
    
}
