using UnityEngine;

public class Forkable: MonoBehaviour
{
    public ForkStabbing ForkedBy;

    void OnCollisionEnter()
    {
        if (ForkedBy != null)
        {
            ForkedBy.ProcessForkedCollision();
        }
    }
}