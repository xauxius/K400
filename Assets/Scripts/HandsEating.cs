using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsEating : Grabbing
{
    private Eatable food;

	void Start()
    {
		//Debug.Log(transform.position);
		//Debug.Log(transform.localPosition);
		//GameObject plate = GameObject.FindWithTag("Lekste");
		//Debug.Log(plate.transform.localPosition);
		//GameObject plate2 = GameObject.FindWithTag("Lekste2");
		//Debug.Log(plate2.transform.localPosition);
		food = GetComponent<Eatable>(); 
		
	}    

    public override void HandleActivate(ActivateEventArgs args)
    {
        food.Eat();
	}
	//public void Lekste()
	//{
	//	GetComponent<Rigidbody>().isKinematic = false;
	//	GameObject plate = GameObject.FindWithTag("Lekste");
	//	GameObject plate2 = GameObject.FindWithTag("Lekste2");

	//	float dist = Vector3.Distance(plate.transform.position, transform.position);
	//	float dist2 = Vector3.Distance(plate2.transform.position, transform.position);

	//	//Debug.Log(dist2);
	//	if (dist <= dist2) {
	//		transform.position = new Vector3(plate.transform.position.x, (float)(plate.transform.position.y + 0.3),
	//										 plate.transform.position.z);
	//	}
	//	else
	//	{
	//		transform.position = new Vector3(plate2.transform.position.x, (float)(plate2.transform.position.y + 0.3),
	//										 plate2.transform.position.z);
	//	}
	//}
	
}
