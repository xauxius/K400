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

	private void Start()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spoonable"))
        {
			Eatable eatable = collision.gameObject.GetComponent<Eatable>();
		
			if (eatable is not null && antsauksto == false && eatable.enabled == true)
            {
				
				Material newMat = eatable.GetComponent<MeshRenderer>().material;
				transform.GetChild(0).gameObject.SetActive(true);
				transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = newMat;
				AudioClip newAudio = eatable.EatingSound;
				eatingSound = newAudio;
				antsauksto = true;

				eatable.Eat(false);			
			}
			Eatable2 eatable2 = collision.gameObject.GetComponent<Eatable2>();

			if (eatable is null && eatable2 is not null && antsauksto == false && eatable2.enabled == true)
			{

				Material newMat = collision.gameObject.GetComponentInChildren<MeshRenderer>().material;
				transform.GetChild(0).gameObject.SetActive(true);
				transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = newMat;

				AudioClip newAudio = eatable2.EatingSound;
				Debug.Log(newAudio.name);
				eatingSound = newAudio;
				antsauksto = true;

				eatable2.Eat(false);
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
}
