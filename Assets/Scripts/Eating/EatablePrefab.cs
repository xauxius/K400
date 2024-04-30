using System.Collections.Generic;
using UnityEngine;

public class EatablePrefab : EatableBase
{
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private HandsEating handsEating;

    public override int GetDisplayCount()
    {
        return prefabs.Count;
    }

    public override void StartExtra()
    {
        handsEating = GetComponent<HandsEating>();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();

        DisplayByIndex(0);
        transform.rotation = prefabs[0].transform.rotation;

        handsEating?.RestartInteractable();
    }

    public override void DisplayByIndex(int index)
    {
        var current = prefabs[index];
        CopyDisplayComponents(current);
        CopyCollider(current);

        handsEating?.FixColliders();
    }

    void CopyDisplayComponents(GameObject copyFrom)
    {
        meshFilter.mesh = copyFrom.GetComponent<MeshFilter>().sharedMesh;
        meshRenderer.materials = copyFrom.GetComponent<MeshRenderer>().sharedMaterials;
        transform.localScale = copyFrom.transform.localScale; 
    }

    void CopyCollider(GameObject copyFrom)
    {
        Destroy(GetComponent<Collider>());

        var collider = copyFrom.GetComponent<Collider>();
        if (collider is BoxCollider boxCollider)
        {
            var newBoxCollider = gameObject.AddComponent<BoxCollider>();
            newBoxCollider.center = boxCollider.center;
            newBoxCollider.size = boxCollider.size;
        } else {
            var newCollider = gameObject.AddComponent<MeshCollider>();
            newCollider.convex = true;
        }
    }
}