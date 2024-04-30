using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsEating : Grabbing
{
	[SerializeField] private bool debugMode = false;
	
    private EatableBase food;
	private XRGrabInteractable xrGrab;

	void Awake()
    {
		food = GetComponent<EatableBase>(); 

		xrGrab = GetComponent<XRGrabInteractable>();
		if (debugMode)
			xrGrab.activated.AddListener((args) => food.Eat());
		
        xrGrab.selectExited.AddListener((e) => RestartInteractable());
	}

    public void RestartInteractable()
    {
        xrGrab.interactionManager.UnregisterInteractable(xrGrab.GetComponent<IXRInteractable>());
        xrGrab.interactionManager.RegisterInteractable(xrGrab.GetComponent<IXRInteractable>());
    }

	public void FixColliders()
	{
		var colliders = GetComponents<Collider>();
        foreach (var collider in colliders)
        {
            xrGrab.colliders.Add(collider);
        }
	}
}
