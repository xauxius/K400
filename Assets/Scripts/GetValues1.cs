using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetValues1 : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown dropdown;
	public static string vardas1;

	public void Start()
	{
		vardas1 = dropdown.options[0].text;
	}
	public void GetValue(){
		int picked = dropdown.value;
		string selected = dropdown.options[picked].text;
		vardas1 = selected;
	}
}
