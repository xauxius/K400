using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    // Managing display object
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private bool LeaveLast;
    private int prefabIndex = 0;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    // Eating
    public bool disableRespawn = true;
    public AudioClip eatingSound;
    public Mouth mouth;
    private bool eating = false;
    private HandsEating handsEating;

    // Starting transform
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        if (mouth == null)
            mouth = GameObject.FindGameObjectWithTag("Mouth").GetComponent<Mouth>();

        handsEating = GetComponent<HandsEating>();

        startPosition = transform.position.Copy();
        startRotation = transform.rotation.Copy();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();

        DisplayByIndex(0);
        transform.rotation = prefabs[0].transform.rotation;

        handsEating?.RestartInteractable();
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

    public void Eat(bool shouldPlaySound = true)
    {
        if (shouldPlaySound)
            SoundManager.instance.playEfektus(eatingSound, transform);
            
        if (++prefabIndex < prefabs.Count) {
            DisplayByIndex(prefabIndex);
        }  else {
            ProcessEaten();
        }
    }

    void DisplayByIndex(int index)
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

    void ProcessEaten()
    {
        if (LeaveLast) {
            enabled = false;
            return;
        }

        if (!disableRespawn)
        {
            transform.position = startPosition.Copy();
            transform.rotation = startRotation.Copy();
            prefabIndex = 0;
            DisplayByIndex(0);
        }
        Destroy(gameObject);
    } 
}