using UnityEngine;

public class ForkAction: GeneralStabbing
{
    private Vector3 lastPosition;

    public override void UpdateExtra()
    {
        if (ForkIsGoingBack())
        {
            stabManager.StickObjects();
        }
        
        lastPosition = transform.position;
    }

    
    bool ForkIsGoingBack()
    {
        Vector3 direction = Vector3.Normalize(transform.position - lastPosition);
        Vector3 back = -transform.right;

        return Vector3.Dot(direction, back) > 0.7;
    }

    public void ProcessForkedCollision()
    {
        // FreeAxis(); // Kolkas neveikia kaip turėtų, kolkas tiks be šito... :(
    }
}