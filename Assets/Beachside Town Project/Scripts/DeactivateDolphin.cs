using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateDolphin : MonoBehaviour
{
    private void Start() {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (
            position.x > 300 ||
            position.x < -300 ||
            position.z > 300 ||
            position.z < -300
        ) {
            gameObject.SetActive(false);
        }
    }
}
