using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    // Managing mesh
    public List<Mesh> meshes;
    public Mesh last;
    private MeshFilter meshFilter;
    private int meshIndex = 0;

    // Eating
    public Mouth mouth;
    private bool eating = false;

    // Starting transform
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position.Copy();
        startRotation = transform.rotation.Copy();

        meshFilter = GetComponent<MeshFilter>();
    }

    void Update()
    {
        var distance = Vector3.Distance(mouth.transform.position, transform.position);

        if (distance <= mouth.radius)
        {
            if (!eating)
            {
                Eat();
                eating = true;
            }
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
        }
    }

    void ResetFood()
    {
        meshIndex = 0;
        meshFilter.mesh = meshes[0];

        Instantiate(gameObject, startPosition, startRotation);
        Destroy(gameObject);
    } 
}