using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	

	// Start is called before the first frame update
	GameObject mouth;



	void Start()
	{
		string vardas = GetValues.vardas;
		Vector3 start = new Vector3((float)1.817, (float)0.733334184, (float)0.088149786);
		Vector3 v = new Vector3(270, 0, 0);
		Vector3 startPosition = new Vector3((float)1.817, (float)0.9, (float)0.088149786);
		Vector3 v3 = new Vector3((float)273.048126, (float)29.6944389, (float)240.372345);
		Spawning(vardas, start, v, startPosition, v3);

		string vardas1 = GetValues1.vardas1;
		start = new Vector3((float)1.54333746, (float)0.734000027, (float)-0.214850187);
		v = new Vector3(270, 0, 0);
		startPosition = new Vector3((float)1.54333746, (float)0.9, (float)-0.214850187);
		v3 = new Vector3((float)273.048126, (float)29.6944389, (float)240.372345);
		Spawning(vardas1, start, v, startPosition, v3);

		string vardas2 = GetValues2.vardas2;
		start = new Vector3((float)1.82700002, (float)0.734000027, (float)-0.596000016);
		v = new Vector3(270, 0, 0);
		startPosition = new Vector3((float)1.82700002, (float)0.9, (float)-0.596000016);
		v3 = new Vector3((float)273.048126, (float)29.6944389, (float)240.372345);
		Spawning(vardas2, start, v, startPosition, v3);

		string vardas3 = GetValues3.vardas3;
		start = new Vector3((float)1.56599998, (float)0.734000027, (float)-0.921);
		v = new Vector3(270, 0, 0);
		startPosition = new Vector3((float)1.56599998, (float)0.9, (float)-0.921);
		v3 = new Vector3((float)273.048126, (float)29.6944389, (float)240.372345);
		Spawning(vardas3, start, v, startPosition, v3);

		string vardas4 = GetValues4.vardas4;
		start = new Vector3((float)1.80900002, (float)0.734000027, (float)-1.29299998);
		v = new Vector3(270, 0, 0);
		startPosition = new Vector3((float)1.80900002, (float)0.9, (float)-1.29299998);
		v3 = new Vector3((float)273.048126, (float)29.6944389, (float)240.372345);
		Spawning(vardas4, start, v, startPosition, v3);

	}
	void Spawning(string vardas, Vector3 ls, Vector3 lr, Vector3 ms, Vector3 mr) {

		string name = vardas;

		string lekstepath = "Assets/Spawninimui";
		lekstepath += "/" + "Lekste" + ".prefab";
		Object lekste = AssetDatabase.LoadAssetAtPath(lekstepath, typeof(GameObject));
		
		Quaternion Rotation = Quaternion.Euler(lr.x, lr.y, lr.z);
		GameObject Lekste1 = (GameObject)Instantiate(lekste, ls, Rotation);


		if (name == "Mėsa")
		{
			for (int i = 0; i < 5; i++)
			{

				string path = "Assets/Spawninimui";
				path += "/" + name + ".prefab";
				Object prefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));
				
				Quaternion startRotation = Quaternion.Euler(mr.x, mr.y, mr.z);
				mouth = GameObject.FindGameObjectWithTag("Mouth");
				prefab.GetComponent<Eatable>().mouth = mouth.GetComponent<Mouth>();
				if (i > 0)
				{
					prefab.GetComponent<Info>().Pavadinimas = "NE";
				}
				if (i == 0 && prefab.GetComponent<Info>().Indas == true)
				{
					DestroyImmediate(Lekste1, true);
				}
				Instantiate(prefab, ms, startRotation);
				ms = new Vector3(ms.x, ms.y + 0.2F, ms.z);
			}

		}
		if (name == "Ryžiai")
		{

				string path = "Assets/Spawninimui";
				path += "/" + name + ".prefab";
				Object prefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));

				Quaternion startRotation = Quaternion.Euler(mr.x, mr.y, mr.z);
				mouth = GameObject.FindGameObjectWithTag("Mouth");
				prefab.GetComponent<Eatable2>().mouth = mouth.GetComponent<Mouth>();
			
				if (prefab.GetComponent<Info>().Indas == true)
				{
					DestroyImmediate(Lekste1, true);
				}
				Instantiate(prefab, ms, startRotation);
			
		}
		else
		{
			string path = "Assets/Spawninimui";
			path += "/" + name + ".prefab";
			Object prefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));
			Quaternion startRotation = Quaternion.Euler(mr.x, mr.y, mr.z);
			mouth = GameObject.FindGameObjectWithTag("Mouth");
			prefab.GetComponent<Eatable>().mouth = mouth.GetComponent<Mouth>();
			if (prefab.GetComponent<Info>().Indas == true)
			{
				DestroyImmediate(Lekste1, true);
			}

			Instantiate(prefab, ms, startRotation);
		}

	}

}
