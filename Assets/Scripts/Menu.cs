using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Pradeti()
    {
        SceneManager.LoadScene("SampleScene");
    }
	public void Iseiti()
	{
		Application.Quit();
		Debug.Log("Iseita");
	}
}
