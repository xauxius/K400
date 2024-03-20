using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // public Collider ForkCollider;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     var colliders = GetComponents<Collider>();

    //     foreach (var collider in colliders)
    //     {
    //         Physics.IgnoreCollision(ForkCollider, collider, true);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        var rBody = GetComponent<Rigidbody>();
        var force = rBody.GetAccumulatedForce();
        Debug.Log(force);
        // Debug.Log(rBody)
    }
}
