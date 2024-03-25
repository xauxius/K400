using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PatiekaluInfo : MonoBehaviour
{
	
    public TMP_Text text;
	
	void Start()
    {
		GameObject[] maistas = GameObject.FindGameObjectsWithTag("Food");
		GameObject[] maistas2 = GameObject.FindGameObjectsWithTag("Spoonable");

		
		
		text.text = "<size=20px>" + "<align=\"center\">" + "Menu\n\n";
	
		foreach (GameObject maist in maistas)
		{
			text.text += "<size=10px>" + "<align=\"center\">" + maist.name + "\n\n";
			text.text += "<align=\"justified\">" + maist.GetComponent<Info>().Notes + "\n\n";
			text.alignment = TextAlignmentOptions.Center;
		}
		foreach (GameObject maist in maistas2)
		{
			text.text += "<align=\"center\">" + maist.name + "\n\n";
			text.text += "<align=\"justified\">" + maist.GetComponent<Info>().Notes + "\n\n";
		}
	}

    
}
