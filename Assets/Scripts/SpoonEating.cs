using UnityEngine;

public class SpoonEating : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spoonable"))
        {
            Eatable eatable = collision.gameObject.GetComponent<Eatable>();

            if (eatable is not null)
            {
                eatable.Eat();
            }
        }
    }
}
