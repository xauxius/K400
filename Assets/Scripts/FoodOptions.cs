using System;
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
            var info = food.GetComponent<Info>();
            if (info != null)
                foodsDict.Add(info.Pavadinimas, food);
            else
                Debug.Log("Nerastas info, kazkas gali but blogai.");
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
