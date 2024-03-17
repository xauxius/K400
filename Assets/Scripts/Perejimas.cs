using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Perejimas : MonoBehaviour
{
    public void Jura()
    {
		SceneManager.LoadScene("Jura");
	}
	public void Kambarys()
	{
		SceneManager.LoadScene("Kambarys");
	}
}
