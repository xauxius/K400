using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Playables;
using UnityEngine.Formats.Alembic.Importer;

public class MachinePlay : MonoBehaviour
{

	public GameObject cup;
	bool werefilling = false;
	bool stopedrefiling = false;
	public GameObject coffemachinecup;
	public PlayableDirector director;
	public AlembicStreamPlayer streamPlayerScript;
    void Update()
    {
		
		if (werefilling && stopedrefiling)
		{
			if (director.time >= 3.5) {  }
			else
			{
				director.time = 3.5;
				streamPlayerScript.CurrentTime = (float)director.time;
			}
		}
		if (director.time >= streamPlayerScript.EndTime - 0.3) {
			werefilling = false;
			stopedrefiling = false;
			director.Stop();
			director.time = 0;
			streamPlayerScript.CurrentTime = 0;
			SoundManager.instance.destroyEffects();
		}

	

		}
	public void Pour()
	{
		var distance = Vector3.Distance(cup.transform.position, coffemachinecup.transform.position);
		if (distance <= 0.05)
		{
			stopedrefiling = false;
			werefilling = true;
			director.Play();
		}
	}
	public void StopPour()
	{
		if (werefilling && !stopedrefiling)
		{
			stopedrefiling = true;
		}
		SoundManager.instance.destroyEffects();
	}

}
