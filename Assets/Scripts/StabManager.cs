using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class StabManager
{
    // private List<Collider> disabledColliders;

    private List<StabConnection> stabConnections;

    private List<RayCaster> rayCasters;
    private GameObject stabber;
    private Collider stabberCollider;

    public StabManager(GameObject stabber, List<RayCaster> rayCasters)
    {
        this.stabber = stabber;
        this.rayCasters = rayCasters;

        stabConnections = new List<StabConnection>();
        stabberCollider = stabber.GetComponent<Collider>();
    }

    public void Update()
    {
        foreach (var rayCaster in rayCasters)
        {
            RaycastHit hit;
            var didHit = Physics.Raycast(rayCaster.GetRay(), out hit, rayCaster.RayDistance);

            if (didHit)
            {
                var stabbed = hit.collider.gameObject;

                if (SuitableForStab(stabbed))
                {
                    DisableStabbedColliders(stabbed);

                    if (hit.distance <= 0.005)
                    {
                        if (!ObjectAllreadyStabbed(stabbed))
                            stabConnections.Add(StabConnection.CreateConnection(stabber, stabbed));
                    }
                }
            }
        }
    }

    public void StickObjects()
    {
        foreach (var stab in stabConnections)
        {
            stab.LimitAxis();
        }
    }

    private bool SuitableForStab(GameObject obj)
    {
        return obj.GetComponent<Forkable>() != null;
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