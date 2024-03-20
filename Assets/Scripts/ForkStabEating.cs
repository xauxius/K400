using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ForkStabEating : Grabbing
{
    public float stabTreshold = 0.1f;

    private Stack<FixedJoint> joints = new Stack<FixedJoint>();
    private Collider ForkCollider;

    void Start()
    {
        ForkCollider = gameObject.GetComponent<Collider>();
    }

    // Stabbing

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Forkable") || BodyIsAllreadyOnFork(collision.rigidbody))
            return;

        foreach (ContactPoint contact in collision.contacts)
        {
            var localContactNormal = transform.InverseTransformDirection(contact.normal);
            
            if (1 + localContactNormal.x <= stabTreshold)
            {
                AddBodyToJoint(collision.rigidbody);

                DisableForkAndForkedColliders(collision.gameObject);

                return;
            }
        }
    }

    bool BodyIsAllreadyOnFork(Rigidbody body)
    {
        var found = joints.FirstOrDefault(j => j.connectedBody.Equals(body));
        return found != null;
    }

    void AddBodyToJoint(Rigidbody body)
    {
        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = body;
        joints.Push(joint);
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
        if (joints.Count > 0)
        {
            FixedJoint joint = joints.Pop();
            Eatable food = joint.connectedBody.gameObject.GetComponent<Eatable>();
            if (food is not null)
            {
                food.Eat();
            }
            Destroy(joint);
        }
    }
}