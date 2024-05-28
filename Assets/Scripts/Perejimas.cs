using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Perejimas : MonoBehaviour
{
    public void Jura()
    {
		SceneManager.LoadScene("Jura 360");
	}
	public void Kambarys()
	{
		SceneManager.LoadScene("Kambarys");
	}
	public void Menu()
	{
		SceneManager.LoadScene("Pradzios ekranas");
	}
}
