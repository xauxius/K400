using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public List<Mesh> meshes;
    public Mouth mouth;

    public Mesh last;
    
    private MeshFilter meshFilter;
    private Vector3 startPosition;
    private int meshIndex = -1;
    private bool eating = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    void Update()
    {
        var distance = Vector3.Distance(mouth.transform.position, transform.position);

        if (distance <= mouth.radius && !eating)
        {
            Debug.Log($"eating: {eating}");
            Eat();
            eating = true;
        } else {
            eating = false;
        }
    }

    public void Eat()
    {
        if (++meshIndex < meshes.Count) {
            meshFilter.mesh = meshes[meshIndex];
        } else if (last != null) {
            meshFilter.mesh = last;
            enabled = false;
        } else {
            ResetFood();
            // Destroy(gameObject);
        }
    }

    void ResetFood()
    {
        meshFilter.mesh = meshes[0];
        meshIndex = 0;
        transform.position = startPosition;
    } 
}