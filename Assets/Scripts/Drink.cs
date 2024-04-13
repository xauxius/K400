using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;
using UnityEngine.Playables;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.ParticleSystem;

public class Drink : MonoBehaviour
{
	[SerializeField] private AudioClip drinksound;
	private bool drinkable = true;
	private bool drinking = false;
	public Mouth mouth;
	public PlayableDirector director;
	public AlembicStreamPlayer streamPlayerScript;

	// Starting transform
	private Vector3 startPosition;
	private Quaternion startRotation;
	GameObject[] particles;
	// Start is called before the first frame update
	void Start()
    {
		director.time = streamPlayerScript.EndTime;
		particles = GameObject.FindGameObjectsWithTag("LiquidParticle");
	}

    // Update is called once per frame
    void Update()
    {
		var distance = Vector3.Distance(mouth.transform.position, transform.position);

		if (distance <= mouth.radius)
		{
			if (!drinking)
			{
				Slurp();
				drinking = true;
			}
			
		}
		else
		{
			drinking = false;
			director.Pause();
		}

	}
	public void Slurp()
	{
		if (drinkable)
		{
			director.Play();
			director.time -= (Time.deltaTime + 0.5);
			streamPlayerScript.CurrentTime = (float)director.time;
			if (director.time <= 0) {
				foreach (GameObject par in particles)
				{
					par.SetActive(false);
				}
				drinkable = false;
			
			}
			SoundManager.instance.playEfektus(drinksound, transform);
		}
	}
}
