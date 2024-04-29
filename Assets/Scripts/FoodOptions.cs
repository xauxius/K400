using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodOptions : MonoBehaviour
{
	public List<GameObject> FoodPrefabs;

    Dictionary<string, GameObject> foodsDict = new Dictionary<string, GameObject>();

    void Awake()
    {
        foreach (var food in FoodPrefabs)
        {
            foodsDict.Add(food.GetComponent<Info>().Pavadinimas, food);
        }
    }

    public GameObject GetPrefab(string name)
    {
        return foodsDict[name];
    }

    public List<string> GetOptions()
    {
        return foodsDict.Keys.ToList();
    }
}
