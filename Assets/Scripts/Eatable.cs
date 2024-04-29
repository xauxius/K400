using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Eatable : MonoBehaviour
{
    // Managing display object
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private bool LeaveLast;
    private int prefabIndex = 0;
    private GameObject current;

    // Eating
    public bool disableRespawn = true;
    public AudioClip eatingSound;
    public Mouth mouth;
    private bool eating = false;
    private HandsEating handsEating;

    // Starting transform
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        handsEating = GetComponent<HandsEating>();

        startPosition = transform.position.Copy();
        startRotation = transform.rotation.Copy();

        DisplayByIndex(0);

        handsEating?.RestartInteractable();
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
        } else {
            eating = false;
        }
    }

    public void Eat(bool shouldPlaySound = true)
    {
        if (shouldPlaySound)
            SoundManager.instance.playEfektus(eatingSound, transform);
            
        if (++prefabIndex < prefabs.Count) {
            DisplayByIndex(prefabIndex);
        }  else {
            ProcessEaten();
        }
    }

    void DisplayByIndex(int index)
    {
        if (current != null)
        {
            Destroy(current);
        }

        current = Instantiate(prefabs[index], transform);        
        current.transform.parent = gameObject.transform;

        handsEating?.FixColliders(current);
    }

    void ProcessEaten()
    {
        if (LeaveLast) {
            enabled = false;
            return;
        }

        if (!disableRespawn)
        {
            transform.position = startPosition.Copy();
            transform.rotation = startRotation.Copy();
            prefabIndex = 0;
            DisplayByIndex(0);
        }
        Destroy(gameObject);
    } 
}