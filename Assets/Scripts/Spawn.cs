using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	[SerializeField] private int optionsCount = 5;
	[SerializeField] private List<Transform> spawnPoints;
	[SerializeField] private GameObject platePrefab;

	private Mouth mouth;

	void Start()
	{
		mouth = GameObject.FindGameObjectWithTag("Mouth").GetComponent<Mouth>();

		for (int i = 0; i < optionsCount; i++)
		{
			var foodPrefab = Selections.Selected[i];
			var spawnPoint = spawnPoints[i]; 

			Spawning(foodPrefab, spawnPoint);
		}
	}

	void Spawning(GameObject foodPrefab, Transform spawnTransform) 
	{
		foodPrefab.GetComponent<Eatable>().mouth = mouth;

		if (foodPrefab.GetComponent<Info>().SpawnPlate)
		{
			Instantiate(platePrefab, spawnTransform.position, platePrefab.transform.rotation);
			spawnTransform.position += Vector3.up * 0.2f;
		}

		var multiple = foodPrefab.GetComponent<Multiple>();
		if (multiple != null)
		{
			for (int i = 0; i < multiple.spawnOffsets.Count; i++)
			{
				var offset = multiple.spawnOffsets[i];

				var food = Instantiate(foodPrefab, spawnTransform.position + offset, foodPrefab.transform.rotation);
				if (i > 0)
				{
					food.GetComponent<Info>().Pavadinimas = "NE";
				}
			}
		}
		else
		{
			Instantiate(foodPrefab, spawnTransform.position, foodPrefab.transform.rotation);
		}
	}

}
