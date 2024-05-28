using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using UnityEditor;

public class FoodOptions : MonoBehaviour
{
    [SerializeField] private string SpawningPath = "Assets/Spawninimui/FoodOptions";
	private List<GameObject> FoodPrefabs = new List<GameObject>();

    Dictionary<string, GameObject> foodsDict = new Dictionary<string, GameObject>();

    void Awake()
    {
        LoadFoodPrefabs();

        foreach (var food in FoodPrefabs)
        {
            try {
                var info = food.GetComponent<Info>();
                foodsDict.Add(info.Pavadinimas, food);
            } catch (Exception) {
                Debug.Log($"Maisto {food.name}, nerastas info (greiciausiai).");

            }
        }
    }

    void LoadFoodPrefabs()
    {

        var files = Directory.GetFiles(SpawningPath);

        foreach (var file in files)
        {
            if (file.EndsWith(".prefab"))
            {
                GameObject food = (GameObject)AssetDatabase.LoadAssetAtPath(file, typeof(GameObject));
                FoodPrefabs.Add(food);
            }
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
