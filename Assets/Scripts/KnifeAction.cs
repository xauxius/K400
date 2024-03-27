using EzySlice;
using UnityEngine;

public class KnifeAction: GeneralStabbing
{
    public override void UpdateExtra()
    {
        ReleaseConnections();
    }

    public override void Cut()
    {
        foreach (StabConnection stab in stabManager.stabConnections)
        {
            Slice(stab.Stabbed);
        }

        CleanubStabConnections();
    }

    private void ReleaseConnections()
    {
        if (RayCaster.RayCastRays(rayCasters).Count == 0)
        {
            CleanubStabConnections();
        }
    }

    private void Slice(GameObject target)
    {
        SlicedHull hull = target.Slice(transform.position, transform.forward);
        Material innerMaterial = target.GetComponent<Stabable>().innerMaterial;

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, innerMaterial);
            SetupSlicedObject(upperHull, target);

            GameObject lowerHull = hull.CreateLowerHull(target, innerMaterial);
            SetupSlicedObject(lowerHull, target);
            
            Destroy(target);
        }
    }

    private void SetupSlicedObject(GameObject sliced, GameObject beforeSlice)
    {
        sliced.AddComponent<Rigidbody>();

        MeshCollider collider = sliced.AddComponent<MeshCollider>();
        collider.convex = true;

        Eatable eatable = sliced.AddComponent<Eatable>();
        eatable.Copy(beforeSlice.GetComponent<Eatable>());

        Stabable stabable = sliced.AddComponent<Stabable>();
        stabable.Copy(beforeSlice.GetComponent<Stabable>());
    }
}