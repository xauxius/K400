using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class PatiekaluInfo : MonoBehaviour
{
	
    public TMP_Text text;
	public TMP_Text text1;

	void Start()
    {

		GameObject[] maistas = GameObject.FindGameObjectsWithTag("Food");
		GameObject[] maistas2 = GameObject.FindGameObjectsWithTag("Spoonable");

		List<string> pav = new List<string>();


		text.text = "<size=20px>" + "<align=\"center\">" + "Menu\n\n";
		text1.text = "<size=20px>" + "<align=\"center\">" + "Menu\n\n";

		int sk = 0;

		foreach (GameObject maist in maistas)
		{
			if (sk % 2 == 0)
			{
				if (maist.GetComponent<Info>() != null && maist.GetComponent<Info>().Pavadinimas != "NE" &&
					!pav.Contains(maist.GetComponent<Info>().Pavadinimas))
				{

					text.text += "<size=10px>" + "<align=\"center\">" + maist.GetComponent<Info>().Pavadinimas + "\n\n";
					text.text += "<align=\"justified\">" + maist.GetComponent<Info>().Notes + "\n\n";
					text.alignment = TextAlignmentOptions.Center;
					pav.Add(maist.GetComponent<Info>().Pavadinimas);
				}
			}
			else {
				if (maist.GetComponent<Info>() != null && maist.GetComponent<Info>().Pavadinimas != "NE" &&
					!pav.Contains(maist.GetComponent<Info>().Pavadinimas))
				{

					text1.text += "<size=10px>" + "<align=\"center\">" + maist.GetComponent<Info>().Pavadinimas + "\n\n";
					text1.text += "<align=\"justified\">" + maist.GetComponent<Info>().Notes + "\n\n";
					text1.alignment = TextAlignmentOptions.Center;
					pav.Add(maist.GetComponent<Info>().Pavadinimas);
				}
			}
			sk++;
		}
		foreach (GameObject maist in maistas2)
		{
			if (sk % 2 == 0)
			{
				if (maist.GetComponent<Info>() != null && maist.GetComponent<Info>().Pavadinimas != "NE" &&
				!pav.Contains(maist.GetComponent<Info>().Pavadinimas))
				{
					text.text += "<align=\"center\">" + maist.GetComponent<Info>().Pavadinimas + "\n\n";
					text.text += "<align=\"justified\">" + maist.GetComponent<Info>().Notes + "\n\n";
					pav.Add(maist.GetComponent<Info>().Pavadinimas);
				}
			}
			else {
				if (maist.GetComponent<Info>() != null && maist.GetComponent<Info>().Pavadinimas != "NE" &&
				!pav.Contains(maist.GetComponent<Info>().Pavadinimas))
				{
					text1.text += "<align=\"center\">" + maist.GetComponent<Info>().Pavadinimas + "\n\n";
					text1.text += "<align=\"justified\">" + maist.GetComponent<Info>().Notes + "\n\n";
					pav.Add(maist.GetComponent<Info>().Pavadinimas);
				}
			}
			sk++;
		}
	}

    
}
