using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
	[SerializeField]
	public string Pavadinimas;

	[TextArea(10, 10)]
	public string Notes = "";

	[SerializeField]
	public bool Indas;

}
