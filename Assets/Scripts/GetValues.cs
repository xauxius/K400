using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown dropdown;
	[SerializeField] private AudioSource audio;
	[SerializeField] private AudioClip clip1,clip2, clip3;

	public void GetValue(){
		int picked = dropdown.value;
		string selected = dropdown.options[picked].text;
		Debug.Log(selected);
		if (picked == 0)
		{
			audio.Stop();
		}
		if (picked == 1)
		{
			audio.clip = clip1;
			audio.Play();
		}
		if (picked == 2)
		{
			audio.clip = clip2;
			audio.Play();
		}
		if (picked == 3)
		{
			audio.clip = clip3;
			audio.Play();
		}
	}
}
