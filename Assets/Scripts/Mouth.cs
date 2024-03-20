using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public float radius = 0.1f;

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
