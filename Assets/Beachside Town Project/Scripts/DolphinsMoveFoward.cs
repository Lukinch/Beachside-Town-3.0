using UnityEngine;

public class DolphinsMoveFoward : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
    }
}
