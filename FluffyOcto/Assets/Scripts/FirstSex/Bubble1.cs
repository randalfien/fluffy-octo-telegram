﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble1 : MonoBehaviour
{

	public GameObject NextBubble;

	public ProgressBar Progress;

	private float minTime = 1.2f;
	// Use this for initialization
	void Start () {
		NextBubble.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update ()
	{
		minTime -= Time.deltaTime;
		if ( minTime > 0 ) return;
		
		if (    Input.GetKeyDown(KeyCode.DownArrow)
			 || Input.GetKeyDown(KeyCode.LeftArrow) 
			 || Input.GetKeyDown(KeyCode.RightArrow) 
			 || Input.GetKeyDown(KeyCode.UpArrow)   )
		{
			FindObjectOfType<RealityScheduler>().ScheduleMe(() => NextBubble.SetActive(true),0.8f,gameObject.layer);
			gameObject.SetActive(false);
			Progress.AddProgress(0.2f);
		}
	}
}
