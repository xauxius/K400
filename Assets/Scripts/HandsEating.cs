using UnityEngine.XR.Interaction.Toolkit;

public class HandsEating : Grabbing
{
    private Eatable food;

    void Start()
    {
        food = GetComponent<Eatable>();
    }    

    public override void HandleActivate(ActivateEventArgs args)
    {
        food.Eat();
    }
}
