using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ForkStabEating : Grabbing
{
    public float stabTreshold = 0.1f;

    private Stack<FixedJoint> joints = new Stack<FixedJoint>();

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            var localContactNormal = transform.InverseTransformDirection(contact.normal);
            
            if (1 + localContactNormal.x <= stabTreshold && collision.gameObject.CompareTag("Forkable"))
            {
                FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = collision.rigidbody;
                joints.Push(joint);
                return;
            }
        }
    }

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
        }
    }
}