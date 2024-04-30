using System.Collections.Generic;
using UnityEngine;

public class Eatable : EatableBase
{
    public List<Mesh> meshes = new List<Mesh>();
    private MeshFilter meshFilter;
    
    public override void StartExtra()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    public override int GetDisplayCount()
    {
        return meshes.Count;
    }

    public override void DisplayByIndex(int index)
    {
        meshFilter.mesh = meshes[index];
    }
}