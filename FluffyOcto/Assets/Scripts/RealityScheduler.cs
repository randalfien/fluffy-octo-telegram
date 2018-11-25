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
	private Dictionary<int, List<TimedItem>> temp = new Dictionary<int, List<TimedItem>>();
	
	public void ScheduleMe(UnityAction a, float time, int layer)
	{
			if (!temp.ContainsKey(layer))
			{
				temp.Add(layer, new List<TimedItem>());
			}
			temp[layer].Add(new TimedItem(time, a));
			print("Scheduling:" + time + " t:" + layer);
		// SAVE TO TEMP, SO WE CAN MODIFY LIST FROM UPDATE
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
		
		// ADD ALL FROM TEMP
		foreach (var keyValuePair in temp)
		{
			var list = temp[keyValuePair.Key];
			if (!items.ContainsKey(keyValuePair.Key))
			{
				items.Add(keyValuePair.Key, new List<TimedItem>());
			}
			
			for (var i = 0; i < list.Count; i++)
			{
				items[keyValuePair.Key].Add(list[i]);	
			}
			list.Clear();
		}
	}
}
