using System;
using Unity.Mathematics;
using UnityEngine;

public class EatableChildDestroy : EatableBase
{
	[SerializeField] private int DisplayCount;
    public override int GetDisplayCount()
    {
        return DisplayCount;
    }

    public override void DisplayByIndex(int index)
    {
        int removeAmount = (int)Math.Ceiling((double)transform.childCount / DisplayCount);

		for (int i = 0; i < removeAmount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
    }
}
