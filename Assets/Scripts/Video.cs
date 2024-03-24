using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
	[SerializeField] long pradzia;
	[SerializeField] double galas;
	[SerializeField] VideoPlayer videoPlayer;
	private double laikas;
	private double trukme;

	private void Start()
	{
		videoPlayer.frame = pradzia;
		laikas = videoPlayer.frameCount;
	}
	private void Update()
	{
		trukme++;
		if (laikas + pradzia + galas == trukme)
		{
			videoPlayer.frame = pradzia;
			trukme = 0;
		}
	}
}
