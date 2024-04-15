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
	bool refiling = false;
	public Mouth mouth;
	public PlayableDirector director;
	public AlembicStreamPlayer streamPlayerScript;
	public GameObject coffemachine;
	float timetostop;

	// Starting transform
	private Vector3 startPosition;
	private Quaternion startRotation;
	GameObject[] particles;
	// Start is called before the first frame update
	void Start()
    {
		director.time = streamPlayerScript.CurrentTime;
		timetostop = streamPlayerScript.CurrentTime;
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
		if (refiling)
		{
			director.Play();
			streamPlayerScript.CurrentTime = (float)director.time;
			drinkable = true;
			if (director.time >= timetostop - 0.025)
			{
				streamPlayerScript.CurrentTime = streamPlayerScript.EndTime;
				director.Pause();
				StopRefil();
			}
		}

	}
	public void Slurp()
	{
		if (drinkable)
		{
			director.timeUpdateMode = DirectorUpdateMode.Manual;
			director.Play();
			director.time -= (Time.deltaTime + 0.5);
			streamPlayerScript.CurrentTime = (float)director.time;
			if (director.time <= 0) {
				foreach (GameObject par in particles)
				{
					par.SetActive(false);
				}
				drinkable = false;
				streamPlayerScript.CurrentTime = 0;

			}
			SoundManager.instance.playEfektus(drinksound, transform);
		}
	}
	public void Refill()
	{
		director.timeUpdateMode = DirectorUpdateMode.GameTime;
		var distance = Vector3.Distance(coffemachine.transform.position, transform.position);
		if (distance <= 0.5)
		{
			transform.position = coffemachine.transform.position;
			transform.rotation = coffemachine.transform.rotation;
			foreach (GameObject par in particles)
			{
				par.SetActive(true);
			}
			refiling = true;
			director.initialTime = streamPlayerScript.CurrentTime;
			director.time = streamPlayerScript.CurrentTime;
		}
		else {
			refiling = false;
		}
	}
	public void StopRefil()
	{
		refiling = false;
	}

}
