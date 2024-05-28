using System;
using UnityEngine;

public abstract class EatableBase : MonoBehaviour
{
    public bool LeaveLast = false;
    [NonSerialized] public int DisplayIndex = 0;

    // Eating
    public AudioClip EatingSound;
    public bool disableRespawn = true;
    public Mouth mouth;
    private bool eating = false;

    // Starting transform
    private Vector3 startPosition;
    private Quaternion startRotation;

	float targetTime = 2.0f;
	bool groja = false;

	public bool shouldPlaySound = true;

	void Start()
    {
        if (mouth == null)
            mouth = GameObject.FindGameObjectWithTag("Mouth").GetComponent<Mouth>();

        startPosition = transform.position.Copy();
        startRotation = transform.rotation.Copy();

        StartExtra();
    }

    public virtual void StartExtra()
    {

    }

    void Update()
    {
        var distance = Vector3.Distance(mouth.transform.position, transform.position);

        if (distance <= mouth.radius)
        {
            if (!eating)
            {
                Eat();
                eating = true;
            }
        } 
		if (groja)
		{
			targetTime -= Time.deltaTime;

			if (targetTime <= 0.0f)
			{
				SoundManager.instance.destroyEffects();
				groja = false;
				targetTime = 2.0f;
				eating = false;
			}
		}
      
	}

    public void Eat()
    {
        if (shouldPlaySound)
            SoundManager.instance.playEfektus(EatingSound, transform);
            groja = true;
            
        if (++DisplayIndex < GetDisplayCount()) {
            DisplayByIndex(DisplayIndex);
            if (DisplayIndex == GetDisplayCount() - 1)
            {
                enabled = false;
            }
        }  else {
            ProcessEaten();
        }
    }

    public abstract void DisplayByIndex(int index);
    public abstract int GetDisplayCount();

    void ProcessEaten()
    {
        if (LeaveLast) {
            return;
        }

        if (!disableRespawn)
        {
            transform.position = startPosition.Copy();
            transform.rotation = startRotation.Copy();
            DisplayIndex = 0;
            Instantiate(gameObject, startPosition, startRotation);
        }
		SoundManager.instance.destroyEffects2();
		Destroy(gameObject);
	} 
}