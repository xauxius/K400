using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nesimas : MonoBehaviour
{
    public void Nesti()
    {
		GameObject[] maistas = GameObject.FindGameObjectsWithTag("Food");

		foreach (GameObject maistai in maistas)
		{
			float dist = Vector3.Distance(maistai.transform.position, transform.position);
			if (dist <= 0.2)
			{
				maistai.transform.parent = transform;
				maistai.GetComponent<Rigidbody>().isKinematic = true;
			}
		}
		GameObject[] maistas1 = GameObject.FindGameObjectsWithTag("Spoonable");

		foreach (GameObject maistai in maistas1)
		{
			float dist = Vector3.Distance(maistai.transform.position, transform.position);
			if (dist <= 0.2)
			{
				maistai.transform.parent = transform;
				maistai.GetComponent<Rigidbody>().isKinematic = true;
			}
		}


	}
	public void Atnesta()
	{
		GameObject[] maistas = GameObject.FindGameObjectsWithTag("Food");
		foreach (GameObject maistai in maistas)
		{
			if (transform.GetChild(0).gameObject == maistai)
			{
				maistai.GetComponent<Rigidbody>().isKinematic = false;
				maistai.transform.parent = null;
			}
		}
		GameObject[] maistas1 = GameObject.FindGameObjectsWithTag("Spoonable");
		foreach (GameObject maistai in maistas1)
		{
			if (transform.GetChild(0).gameObject == maistai)
			{
				maistai.GetComponent<Rigidbody>().isKinematic = false;
				maistai.transform.parent = null;
			}
		}
	}

}
