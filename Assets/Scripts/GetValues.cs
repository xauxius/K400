using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] private TMP_Dropdown dropdown;
	[SerializeField] private AudioSource audios;
	[SerializeField] private AudioClip clip1,clip2, clip3;

	public void GetValue(){
		int picked = dropdown.value;
		//string selected = dropdown.options[picked].text;
		if (picked == 0)
		{
			audios.Stop();
		}
		if (picked == 1)
		{
			audios.clip = clip1;
			audios.Play();
		}
		if (picked == 2)
		{
			audios.clip = clip2;
			audios.Play();
		}
		if (picked == 3)
		{
			audios.clip = clip3;
			audios.Play();
		}
	}
}
