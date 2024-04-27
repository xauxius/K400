using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EatChild : MonoBehaviour
{
	// Managing mesh
	public List<Mesh> meshes = new List<Mesh>();
	public Mesh last;
	private MeshFilter meshFilter;
	private int meshIndex = 0;

	// Starting transform
	private Vector3 startPosition;
	private Quaternion startRotation;

	public bool disableRespawn = true;

	void Start()
	{
		startPosition = transform.position.Copy();
		startRotation = transform.rotation.Copy();

		meshFilter = GetComponent<MeshFilter>();

	}
	public void EatChildFood()
	{

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
			ResetChildFood();
		}

	}
	void ResetChildFood()
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
		//Debug.Log(gameObject.name);
		Destroy(gameObject);
	}
}
