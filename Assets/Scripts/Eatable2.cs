using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable2 : MonoBehaviour
{

	// Eating
	public AudioClip EatingSound;
	public bool disableRespawn = true;
	public Mouth mouth;
	private bool eating = false;

	// Starting transform
	private Vector3 startPosition;
	private Quaternion startRotation;

	void Start()
	{
		startPosition = transform.position.Copy();
		startRotation = transform.rotation.Copy();

	}

	void Update()
	{
		var distance = Vector3.Distance(mouth.transform.position, transform.position);

		if (distance <= mouth.radius)
		{
			if (!eating)
			{
				Eat();
				eating = true;
			}
		}
		else
		{
			eating = false;
		}
	}

	public void Eat(bool shouldPlaySound = true)
	{
		if (shouldPlaySound)
			SoundManager.instance.playEfektus(EatingSound, transform);

	
		for (int i = 0; i < transform.childCount; i++)
		{
			if (i <= 10)
			{
				Destroy(transform.GetChild(i).gameObject);
			}
		}
		if (transform.childCount == 0 )
		{
			ResetFood();
		}
		
		
	}

	void ResetFood()
	{
		

		if (!disableRespawn)
		{
			Instantiate(gameObject, startPosition, startRotation);
		}
		Destroy(gameObject);
	}
}
