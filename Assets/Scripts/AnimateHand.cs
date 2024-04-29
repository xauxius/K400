using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHand : MonoBehaviour
{
    [SerializeField] InputActionProperty gripInput;
    [SerializeField] Animator handAnimator;

    void Update()
    {
        var gripValue = gripInput.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
