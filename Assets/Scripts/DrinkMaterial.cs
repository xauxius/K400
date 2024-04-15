using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DrinkMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		string name = GetValues5.vardas5;
		
		Spawning(name);
	}
	void Spawning(string name)
	{
		string path = "Assets/Materials";
		path += "/" + name + ".mat";
		Material newMat = (Material)AssetDatabase.LoadAssetAtPath(path, typeof(Material));
		GetComponent<MeshRenderer>().material = newMat;
		
	}
}
