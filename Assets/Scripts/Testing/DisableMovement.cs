using UnityEngine;

public class DisableMovement: MonoBehaviour
{
    Rigidbody body;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    void Update()
    {
        body.velocity = new Vector3(0, 0, 0);
        body.angularVelocity = new Vector3(0, 0, 0);
    }
}