using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 40;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FPS: " + (int)(1 / Time.smoothDeltaTime));
    }
}
