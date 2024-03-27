using Unity.VisualScripting;
using UnityEngine;

public static class Extensions
{
    public static Vector3 Copy(this Vector3 original)
    {
        return new Vector3(original.x, original.y, original.z);
    }

    public static Quaternion Copy(this Quaternion original)
    {
        return new Quaternion(original.x, original.y, original.z, original.w);
    }

    public static void Copy(this Eatable eatable, Eatable other)
    {
        eatable.eatingSound = other.eatingSound;
        eatable.mouth = other.mouth;
        eatable.disableRespawn = true;
    }

    public static void Copy(this Stabable stabable, Stabable other)
    {
        stabable.innerMaterial = other.innerMaterial;
    }
}