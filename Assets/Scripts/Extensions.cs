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
}