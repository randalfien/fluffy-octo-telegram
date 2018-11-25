using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble1 : MonoBehaviour
{

	public GameObject NextBubble;
	
	// Use this for initialization
	void Start () {
		NextBubble.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			FindObjectOfType<RealityScheduler>().ScheduleMe(() => NextBubble.SetActive(true),0.8f,gameObject.layer);
			gameObject.SetActive(false);
		}
	}
}
