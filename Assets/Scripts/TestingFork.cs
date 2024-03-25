using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestingFork : Grabbing
{
    public float StabTreshold = 0.1f;

    private Collider forkCollider;
    private GameObject forked;
    private Vector3 lastPosition;
    private ConfigurableJoint joint;
    private GameObject food;

    void Start()
    {
        // joint = gameObject.GetComponent<FixedJoint>();
        // Debug.Log(joint.axis);
        // ConfigurableJoint joint;

        forkCollider = gameObject.GetComponent<Collider>();
    }

    // Stabbing

    void Update()
    {
        Rigidbody body = gameObject.GetComponent<Rigidbody>();

        body.velocity = new Vector3(0, 0, 0);
        body.angularVelocity = new Vector3(0, 0, 0);
        // Debug.Log(joint.currentForce);

        // if (forked == null)
        //     return;
        
        if (joint != null && ForkIsGoingBack())
        {
            LimitAxis();
        }
        
        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Forkable")) //|| BodyIsAllreadyOnFork(collision.rigidbody))
            return;

        foreach (ContactPoint contact in collision.contacts)
        {
            var localContactNormal = transform.InverseTransformDirection(contact.normal);
            
            if (1 + localContactNormal.x <= StabTreshold)
            {
                food = collision.gameObject;
                AddObjectToFork(collision.rigidbody);
                DisableForkAndForkedColliders(collision.gameObject);
                // collision.gameObject.transform.parent = transform;
                // DisableForkAndForkedColliders(collision.gameObject);
                // forked = collision.gameObject;

                return;
            }
        }
    }

    // bool BodyIsAllreadyOnFork(Rigidbody body)
    // {
    //     var found = joints.FirstOrDefault(j => j.connectedBody.Equals(body));
    //     return found != null;
    // }

    bool ForkIsGoingBack()
    {
        Vector3 direction = Vector3.Normalize(transform.position - lastPosition);
        Vector3 back = -transform.right;

        return Vector3.Dot(direction, back) > 0.7;
    }

    void AddObjectToFork(Rigidbody body)
    {
        if (joint == null)
        {
            joint = gameObject.AddComponent<ConfigurableJoint>();

            joint.xMotion = ConfigurableJointMotion.Free;
            joint.yMotion = ConfigurableJointMotion.Locked;
            joint.zMotion = ConfigurableJointMotion.Locked;
            joint.angularXMotion = ConfigurableJointMotion.Locked;
            joint.angularYMotion = ConfigurableJointMotion.Locked;
            joint.angularZMotion = ConfigurableJointMotion.Locked;

            // joint.linearLimit = new SoftJointLimit {limit = 0.1f};

            joint.connectedBody = body;
        }
    }

    void LimitAxis()
    {
        Debug.Log(food.transform.position);
        joint.xMotion = ConfigurableJointMotion.Locked;
        Debug.Log(food.transform.position);
    }

    void FreeAxis()
    {
        joint.xMotion = ConfigurableJointMotion.Limited;
    }

    // void AddBodyToJoint(Rigidbody body)
    // {
    //     FixedJoint joint = gameObject.AddComponent<FixedJoint>();
    //     joint.connectedBody = body;
    //     joints.Push(joint);
    // }

    void DisableForkAndForkedColliders(GameObject forked)
    {
        var colliders = forked.GetComponents<Collider>();

        foreach (var collider in colliders)
        {
            Physics.IgnoreCollision(forkCollider, collider, true);
        }
    }

    // Eating

    public override void HandleActivate(ActivateEventArgs args)
    {
        // if (joints.Count > 0)
        // {
        //     FixedJoint joint = joints.Pop();
        //     Eatable food = joint.connectedBody.gameObject.GetComponent<Eatable>();
        //     if (food is not null)
        //     {
        //         food.Eat();
        //     }
        //     Destroy(joint);
        // }
    }
}