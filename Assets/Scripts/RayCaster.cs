using UnityEngine;

public class RayCaster: MonoBehaviour
{
    public float RayDistance = 0.02f;

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.0025f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * RayDistance);
    }

    public Ray GetRay()
    {
        return new Ray(transform.position, transform.up);
    }
}