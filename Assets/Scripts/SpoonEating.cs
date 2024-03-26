using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Rendering.DebugUI;

public class SpoonEating : MonoBehaviour
{
	[SerializeField] private AudioClip valgymogarsas;
	private bool antsauksto = false;

	// Eating
	[SerializeField] private AudioClip eatingSound;
	public bool DisableRespawn = false;
	public Mouth mouth;
	private bool eating = false;

	// Starting transform
	private Vector3 startPosition;
	private Quaternion startRotation;

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

				antsauksto = true;

				eatable.Eat(false);			
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
	}
	public void Valgyti()
	{
		if (antsauksto)
		{
			antsauksto = false ;
			transform.GetChild(0).gameObject.SetActive(false);
			SoundManager.instance.playEfektus(valgymogarsas, transform);
		}
	}
}
