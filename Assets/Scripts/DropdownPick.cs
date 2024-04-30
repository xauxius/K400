using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Sprites;
using UnityEngine;

public class DropdownPick : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown dropdown;
	[SerializeField] private FoodOptions foodOptions;

	public void Start()
	{
		foreach (var option in foodOptions.GetOptions())
		{
			dropdown.options.Add(new TMP_Dropdown.OptionData(option));
		}
	}

	public GameObject GetSelectedPrefab()
	{
		int picked = dropdown.value;
		string selected = dropdown.options[picked].text;
		return foodOptions.GetPrefab(selected);
	}
}
