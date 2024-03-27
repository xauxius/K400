using System.Collections.Generic;
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

    public static List<RaycastHit> RayCastRays(List<RayCaster> rayCasters)
    {
        List<RaycastHit> hits = new List<RaycastHit>();
        foreach (var rayCaster in rayCasters)
        {
            RaycastHit hit;
            var didHit = Physics.Raycast(rayCaster.GetRay(), out hit, rayCaster.RayDistance);

            if (didHit)
            {
                hits.Add(hit);
            }
        }
        return hits;
    }
}