using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Eatable3 : MonoBehaviour
{
	// Managing mesh
	public List<Mesh> meshes = new List<Mesh>();
	public Mesh last;
	private MeshFilter meshFilter;
	private int meshIndex = 0;

	// Eating
	public AudioClip EatingSound;
	public bool disableRespawn = true;
	public Mouth mouth;
	private bool eating = false;

	// Starting transform
	private Vector3 startPosition;
	private Quaternion startRotation;

	public bool shouldPlaySound;
	bool groja = false;

	float targetTime = 2.0f;
	void Start()
	{
		startPosition = transform.position.Copy();
		startRotation = transform.rotation.Copy();

		meshFilter = GetComponent<MeshFilter>();

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
		if (groja)
		{
			targetTime -= Time.deltaTime;

			if (targetTime <= 0.0f)
			{
				SoundManager.instance.destroyEffects();
				groja = false;
				targetTime = 2.0f;
				eating = false;
			}
		}
	}

	public void Eat()
	{
		if (shouldPlaySound)
			SoundManager.instance.playEfektus(EatingSound, transform);
		    groja = true;


		for (int i = 0; i < transform.childCount; i++)
		{
			EatChild food = transform.GetChild(i).gameObject.GetComponent<EatChild>();
			if (food != null)
			{
				food.EatChildFood();
			}
		}

		if (++meshIndex < meshes.Count)
		{
			meshFilter.mesh = meshes[meshIndex];
		}
		else if (last != null)
		{
			meshFilter.mesh = last;
			enabled = false;
		}
		else
		{
			ResetFood();
		}


	}

	void ResetFood()
	{

		if (meshes.Count > 0)
		{
			meshIndex = 0;
			meshFilter.mesh = meshes[0];
		}

		if (!disableRespawn)
		{
			Instantiate(gameObject, startPosition, startRotation);
		}
		SoundManager.instance.destroyEffects2();
		Destroy(gameObject);
	}
}
