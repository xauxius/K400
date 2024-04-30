using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbing : MonoBehaviour
{
    [SerializeField] private Transform l_attach;
    [SerializeField] private Transform r_attach;
    private XRGrabInteractable grabInteractable;
    private bool transformRotated;

    void Awake() 
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(FixPosition);
    }

    void FixPosition(SelectEnterEventArgs selectArgs)
    {
        Transform attach;
        
        if (selectArgs.interactorObject.transform.gameObject.CompareTag("R")) {
            attach = r_attach;
        } else {
            attach = l_attach;
        }
        
        grabInteractable.attachTransform = attach;
    }
}
