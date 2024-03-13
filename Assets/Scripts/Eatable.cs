using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public List<Mesh> meshes;
    public Mesh last;
    
    private MeshFilter meshFilter;
    private int meshIndex = -1;

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    public void Eat()
    {
        if (++meshIndex < meshes.Count) {
            meshFilter.mesh = meshes[meshIndex];
        } else if (last is not null) {
            meshFilter.mesh = last;
            enabled = false;
        } else {
            Destroy(gameObject);
        }
    }
}