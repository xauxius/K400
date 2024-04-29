using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsEating : Grabbing
{
	[SerializeField] private bool debugMode = false;
	
    private Eatable food;
	private XRGrabInteractable xrGrab;

	void Awake()
    {
		food = GetComponent<Eatable>(); 

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

	public void FixColliders(GameObject current)
	{
		var colliders = current.GetComponents<Collider>();
        foreach (var collider in colliders)
        {
            xrGrab.colliders.Add(collider);
        }
	}
}
