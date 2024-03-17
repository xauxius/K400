using UnityEngine;

public class SpoonEating : MonoBehaviour
{

	[SerializeField] private AudioClip valgymogarsas;
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spoonable"))
        {
            Eatable eatable = collision.gameObject.GetComponent<Eatable>();

            if (eatable is not null)
            {

				SoundManager.instance.playEfektus(valgymogarsas, transform);
				eatable.Eat();

			
			}
        }
    }
}
