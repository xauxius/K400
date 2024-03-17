using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsEating : Grabbing
{
    private Eatable food;

	[SerializeField] private AudioClip valgymogarsas;

	void Start()
    {
        food = GetComponent<Eatable>();
    }    

    public override void HandleActivate(ActivateEventArgs args)
    {
        food.Eat();
		SoundManager.instance.playEfektus(valgymogarsas, transform);
	}
}
