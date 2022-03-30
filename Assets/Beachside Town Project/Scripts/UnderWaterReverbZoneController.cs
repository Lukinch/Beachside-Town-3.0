using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterReverbZoneController : MonoBehaviour
{
    // Put the reverb zone in the variable below (in the editor)
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private Camera objectToCollideWith;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("MainCamera")) {
            // If the trigger is enetered, enable the "objectToEnable"
            objectToEnable.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera")) {
        // If the trigger is exited, disable the "objectToEnable"
        objectToEnable.SetActive(false);
        }
    }
}
