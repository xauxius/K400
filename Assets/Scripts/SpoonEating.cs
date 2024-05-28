using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Rendering.DebugUI;

public class SpoonEating : MonoBehaviour
{
	private bool antsauksto = false;

	// Eating
	public AudioClip eatingSound;
	public bool DisableRespawn = false;
	public Mouth mouth;
	private bool eating = false;

	// Starting transform
	private Vector3 startPosition;
	private Quaternion startRotation;

	float targetTime = 2.0f;
	bool groja = false;


	private bool spooned = false;
	private void Start()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnCollisionEnter(Collision collision)
    {
		if (spooned)
		{
			Spoonable spoonable = collision.gameObject.GetComponent<Spoonable>();

			if (spoonable != null)
			{
				EatableBase eatable = collision.gameObject.GetComponent<EatableBase>();

				if (eatable is not null && antsauksto == false && eatable.enabled == true)
				{
					transform.GetChild(0).gameObject.SetActive(true);
					transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = spoonable.SpoonedMaterial;
					AudioClip newAudio = eatable.EatingSound;
					eatingSound = newAudio;
					antsauksto = true;

					eatable.Eat();
				}
			}
		}
    }

	void Update()
	{
		
		var distance = Vector3.Distance(mouth.transform.position, transform.position);

		if (distance <= mouth.radius)
		{
			if (!eating)
			{
				Valgyti();
				eating = true;
			}
		}
		else
		{
			eating = false;
		}
		if (groja)
		{
			targetTime -= Time.deltaTime;

			if (targetTime <= 0.0f)
			{
				SoundManager.instance.destroyEffects();
				groja = false;
				targetTime = 2.0f;
			}
		}
	}
	public void Valgyti()
	{
		if (antsauksto)
		{
			antsauksto = false ;
			transform.GetChild(0).gameObject.SetActive(false);
			SoundManager.instance.playEfektus(eatingSound, transform);
			groja = true;
		}
	}
	public void activatespoon()
	{
		spooned = true;
	}
	public void deactivatespoon()
	{
		spooned = false;
	}
}
