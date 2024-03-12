using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class Grabbing : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Awake() 
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        grabInteractable.activated.AddListener(HandleActivate);
    }

    public abstract void HandleActivate(ActivateEventArgs args);

    public virtual void HandleRelease()
    {

    }

    void OnDestroy()
    {
        grabInteractable.activated.RemoveAllListeners();
    }
}
