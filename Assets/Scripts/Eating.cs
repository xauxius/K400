using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Eat : MonoBehaviour
{
    public List<Mesh> meshes;

    private XRGrabInteractable grabInteractable;
    private MeshFilter meshFilter;
    private int meshIndex = -1;

    void Awake() 
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        meshFilter = GetComponent<MeshFilter>();
        
        grabInteractable.activated.AddListener(HandleActivate);
    }

    void HandleActivate(ActivateEventArgs args)
    {
        if (++meshIndex < meshes.Count)
        {
            meshFilter.mesh = meshes[meshIndex];
        } else {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        grabInteractable.activated.RemoveAllListeners();
    }
}
