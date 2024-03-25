using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ForkStabEating : Grabbing
{
    public float stabTreshold = 0.1f;

    private GameObject forked;
    private FixedJoint joint;
    private Vector3 lastPosition;
    private Collider ForkCollider;

    void Start()
    {
        ForkCollider = gameObject.GetComponent<Collider>();
    }

    void Update()
    {
        if (forked != null && joint == null && ForkIsGoingBack())
        {
            StickToFork();
        }
        lastPosition = transform.position.Copy();
    }

    // Stabbing

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Forkable"))
            return;

        foreach (ContactPoint contact in collision.contacts)
        {
            var localContactNormal = transform.InverseTransformDirection(contact.normal);
            
            if (1 + localContactNormal.x <= stabTreshold)
            {
                forked = collision.gameObject;
                DisableForkAndForkedColliders(collision.gameObject);

                return;
            }
        }
    }

    bool ForkIsGoingBack()
    {
        Vector3 direction = Vector3.Normalize(transform.position - lastPosition);
        Vector3 back = -transform.right;

        return Vector3.Dot(direction, back) > 0.7;
    }

    void StickToFork()
    {
        joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = forked.gameObject.GetComponent<Rigidbody>();
    }

    void DisableForkAndForkedColliders(GameObject forked)
    {
        var colliders = forked.GetComponents<Collider>();

        foreach (var collider in colliders)
        {
            Physics.IgnoreCollision(ForkCollider, collider, true);
        }
    }

    // Eating

    public override void HandleActivate(ActivateEventArgs args)
    {
        Eatable food = joint.connectedBody.gameObject.GetComponent<Eatable>();
        if (food is not null)
        {
            Destroy(joint);
            food.Eat();
            joint = null;
            forked = null;
        }
    }
}