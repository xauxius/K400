using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nesimas : MonoBehaviour
{
    public void Nesti()
    {
		GameObject[] maistas = GameObject.FindGameObjectsWithTag("Food");

		foreach (GameObject maist in maistas)
		{
			float dist = Vector3.Distance(maist.transform.position, transform.position);
			if (dist <= 0.2)
			{
			maist.transform.parent = transform;
			maist.GetComponent<Rigidbody>().isKinematic = true;
			}
		}

		

	}
	public void Atnesta()
	{
		GameObject[] maistas = GameObject.FindGameObjectsWithTag("Food");
		foreach (GameObject maist in maistas)
		{
			if (transform.GetChild(0).gameObject == maist)
			{
				maist.GetComponent<Rigidbody>().isKinematic = false;
				maist.transform.parent = null;
			}
		}

	}

}
