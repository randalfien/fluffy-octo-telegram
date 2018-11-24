using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedItem
{
	public float TimeLeft;
	public UnityAction action;

	public TimedItem(float t, UnityAction a)
	{
		TimeLeft = t;
		action = a;
	}
} 

public class RealityScheduler : MonoBehaviour
{
	public int VisibleLayer;
	
	private Dictionary<int, List<TimedItem>> items = new Dictionary<int, List<TimedItem>>();
	
	public void ScheduleMe(UnityAction a, float time, int layer)
	{
		if (!items.ContainsKey(layer))
		{
			items.Add(layer,new List<TimedItem>());
		}
		items[layer].Add(new TimedItem(time, a));
	}
	
	public void Update()
	{
		
		if (items.ContainsKey(VisibleLayer))
		{
			
			var itm = items[VisibleLayer];
			var toDelete = new List<TimedItem>();
			foreach (var timedItem in itm)
			{
				timedItem.TimeLeft -= Mathf.Min(1.0f, Time.deltaTime);
				if (timedItem.TimeLeft < 0)
				{
					toDelete.Add(timedItem);
					timedItem.action.Invoke();
				}
			}
			
			foreach (var timedItem in toDelete)
			{
				itm.Remove(timedItem);
			}
		}		
	}
}
