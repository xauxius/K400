using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class StabManager
{
    // private List<Collider> disabledColliders;
    public List<StabConnection> stabConnections;
    private Collider stabberCollider;
    private GameObject stabber;
    private Axis freeAxis;

    public StabManager(GameObject stabber, Axis freeAxis)
    {
        this.stabber = stabber;
        this.freeAxis = freeAxis;

        stabConnections = new List<StabConnection>();
        stabberCollider = stabber.GetComponent<Collider>();
    }

    public void ProcessRayStabbing(RaycastHit hit)
    {
        var stabbed = hit.collider.gameObject;

        DisableStabbedColliders(stabbed);

        if (hit.distance <= 0.005)
        {
            if (!ObjectAllreadyStabbed(stabbed))
                stabConnections.Add(StabConnection.CreateConnection(stabber, stabbed, freeAxis));
        }
    }

    public void StickObjects()
    {
        foreach (var stab in stabConnections)
        {
            stab.LimitAxis();
        }
    }

    private void CleanupDisabledColliders()
    {
        // Reiks sutvarkyt colliders :/
    }

    public bool SuitableForStab(GameObject obj)
    {
        return obj.GetComponent<Stabable>() != null;
        // return obj.CompareTag("Forkable");
    }

    private void DisableStabbedColliders(GameObject stabbed)
    {
        var colliders = stabbed.GetComponents<Collider>();

        foreach (var collider in colliders)
        {
            Physics.IgnoreCollision(stabberCollider, collider, true);
            // disabledColliders.Add(collider);
        }
    }

    private bool ObjectAllreadyStabbed(GameObject toStab)
    {
        var found = stabConnections.FirstOrDefault(s => s.Stabbed.Equals(toStab));
        return found != null;
    }
}