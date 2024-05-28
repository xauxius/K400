using System;
using Unity.Mathematics;
using UnityEngine;

public class EatableChildDestroy : EatableBase
{
	private int DisplayCount;
	[SerializeField] private int removeAmount;

	private void Start()
	{
		DisplayCount = transform.childCount;
		GetDisplayCount();
	}
	public override int GetDisplayCount()
    {
        return DisplayCount;
    }

    public override void DisplayByIndex(int index)
    {
		//  int removeAmount = (int)Math.Ceiling((double)transform.childCount / DisplayCount);
		DisplayCount = transform.childCount;
	
		if (removeAmount > transform.childCount)
		{
			removeAmount = transform.childCount;
		}
		for (int i = 0; i < removeAmount; i++)
		{
			
			Destroy(transform.GetChild(i).gameObject);
			
		}
		GetDisplayCount();
	}
}
