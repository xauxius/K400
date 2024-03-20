using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nesimas : MonoBehaviour
{
    public void Nesti()
    {
		GameObject maistas = GameObject.FindWithTag("Food");

		float dist = Vector3.Distance(maistas.transform.position, transform.position);


		if (dist <= 0.2)
		{
			maistas.transform.parent = transform;
			maistas.GetComponent<Rigidbody>().isKinematic = true;

		}

	}
	public void Atnesta()
	{
		GameObject maistas = GameObject.FindWithTag("Food");

		if (transform.GetChild(0).gameObject == maistas)
		{
			maistas.GetComponent<Rigidbody>().isKinematic = false;
			maistas.transform.parent = null;
		}

	}

}
