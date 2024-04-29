using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	[SerializeField] List<DropdownPick> dropdownPicks;
    public void Pradeti()
    {
		foreach (var dropdownPick in dropdownPicks)
		{
			Selections.Selected.Add(dropdownPick.GetSelectedPrefab());
		}

        SceneManager.LoadScene("Kambarys");
    }
	public void Iseiti()
	{
		Application.Quit();
		Debug.Log("Iseita");
	}
}
