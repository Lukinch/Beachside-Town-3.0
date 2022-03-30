using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateDolphin : MonoBehaviour
{
    [SerializeField] private float deactivationPoint = 500f;

    void Update()
    {
        Vector3 position = transform.position;
        if (
            position.x > deactivationPoint ||
            position.x < -deactivationPoint ||
            position.z > deactivationPoint ||
            position.z < -deactivationPoint
        ) {
            gameObject.SetActive(false);
        }
    }
}
