using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AzureSky;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private ThirdPersonController playerInput;

    [Header("Time stuff")]
    [SerializeField] private AzureTimeController azureTimeController;
    [SerializeField] private Slider sliderInSettingsToUpdate;
    [SerializeField] private Slider sliderToUpdate;

    public bool isCanvasActive = false;

    public float timeOfDay = 0f;

    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    private void Update() {
        timeOfDay = azureTimeController.GetTimeline();
        sliderToUpdate.value = timeOfDay;
        sliderInSettingsToUpdate.value = timeOfDay;

        if (Input.GetKeyDown(KeyCode.P)) {
            if (isCanvasActive) {
                DisableCanvas();
            }
            else {
                EnableCanvas();
            }
        }
    }

    public void EnableCanvas() {
        playerInput.enabled = false;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        canvas.SetActive(true);
        isCanvasActive = true;
    }

    public void DisableCanvas() {
        playerInput.enabled = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        canvas.SetActive(false);
        isCanvasActive = false;
    }

    public void SetIsCanvasActive() {
            if (isCanvasActive) isCanvasActive = false;
            else isCanvasActive = true;
    }
}
