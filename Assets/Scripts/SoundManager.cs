using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;

	[SerializeField] private AudioSource m_AudioSource;

	public void Awake()
	{
		if (instance == null)
			instance = this;
	}
	public void playEfektus(AudioClip audioClip, Transform spawntransform){

		AudioSource audioSource = Instantiate(m_AudioSource, spawntransform.position, Quaternion.identity);
		audioSource.clip = audioClip;
		audioSource.Play();
		Destroy(audioSource.gameObject, 1);
	}
}
