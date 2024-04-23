using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;

	[SerializeField] private AudioSource m_AudioSource;
	AudioSource audioSource;

	public void Awake()
	{
		if (instance == null)
			instance = this;
	}
	public void playEfektus(AudioClip audioClip, Transform spawntransform){

			audioSource = Instantiate(m_AudioSource, spawntransform.position, Quaternion.identity);
			audioSource.clip = audioClip;
			audioSource.Play();
	}
	public void destroyEffects()
	{
		if (audioSource != null)
		{
			Destroy(audioSource.gameObject, 1);
		}
	}
}
