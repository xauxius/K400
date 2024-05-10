using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetValues2 : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown dropdown;
	public static string vardas2;

	public void Start()
	{
		vardas2 = dropdown.options[0].text;
	}
	public void GetValue(){
		int picked = dropdown.value;
		string selected = dropdown.options[picked].text;
		vardas2 = selected;
	}
}
