using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzikaisjungiama : MonoBehaviour

{
	[SerializeField] private AudioSource audios;
	// Start is called before the first frame update
	 public void Groti()
    {
		audios.Play();
	}
	public void Sustabdyti()
	{
		audios.Stop();
	}
}
