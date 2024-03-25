using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Rendering.DebugUI;

public class SpoonEating : MonoBehaviour
{
	private bool antsauksto = false;
	private void Start()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}

	[SerializeField] private AudioClip valgymogarsas;
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spoonable"))
        {
            Eatable eatable = collision.gameObject.GetComponent<Eatable>();

            if (eatable is not null && antsauksto == false)
            {
				
				Material newMat = eatable.GetComponent<MeshRenderer>().material;
				transform.GetChild(0).gameObject.SetActive(true);
				transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = newMat;

				antsauksto = true;

				eatable.Eat();

			
			}
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
