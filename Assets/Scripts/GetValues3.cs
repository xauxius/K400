using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Sprites;
using UnityEngine;

public class GetValues3 : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown dropdown;
	public static string vardas3;

	public void Start()
	{
		vardas3 = dropdown.options[0].text;
	}
	public void GetValue(){
		int picked = dropdown.value;
		string selected = dropdown.options[picked].text;
		vardas3 = selected;
	}
}
