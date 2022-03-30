using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public List<AudioClip> grassSteps = new List<AudioClip>();
    public List<AudioClip> waterSteps = new List<AudioClip>();

    private enum Surface { grass, water};

    private List<AudioClip> currentList;
    private Surface surface;

    private AudioSource source;
    
    private bool isOnWater = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();            
    }

    public void PlayStep ()
    {
        AudioClip clip = currentList[Random.Range(0, currentList.Count)];
        source.PlayOneShot(clip);
    }

    private void SelectStepList ()
    {
        switch (surface)
        {
            case Surface.grass:
                currentList = grassSteps;
                break;
            case Surface.water:
                currentList = waterSteps;
                break;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isOnWater && hit.transform.tag == "Grass")
        {
            surface = Surface.grass;
        }

        SelectStepList();
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Water") {
            isOnWater = true;
            surface = Surface.water;
        }
        
        SelectStepList();
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Water") {
            isOnWater = false;
        }
    }
}
