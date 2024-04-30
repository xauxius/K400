using System.Collections.Generic;
using UnityEngine;

public class EatableChildEat : EatableBase
{
	// Managing mesh
	public List<Mesh> meshes = new List<Mesh>();
	private MeshFilter meshFilter;

	public override void StartExtra()
	{
		meshFilter = GetComponent<MeshFilter>();
	}

	public override int GetDisplayCount()
	{
		return meshes.Count;
	}

    public override void DisplayByIndex(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
		{
			EatChild food = transform.GetChild(i).gameObject.GetComponent<EatChild>();
			if (food != null)
			{
				food.EatChildFood();
			}
		}

		meshFilter.mesh = meshes[index];
    }
}
