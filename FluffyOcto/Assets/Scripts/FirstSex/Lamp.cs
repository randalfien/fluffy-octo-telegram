using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Microsoft.SqlServer.Server;
using UnityEngine;

public class Lamp : MonoBehaviour
{

	public SpriteRenderer Background;
	public SpriteRenderer Face;
	public Color BackgroundColorTarget;
	public Sprite LampaSpriteOn;
	private bool _triggered;

	public GameObject FirstBubble;

	public bool isReal;
	
	private void Start()
	{
		var blc = Color.white;
		blc.a = 0;
		Face.color = blc;
		FirstBubble.SetActive(false);
	}

	void Update () {
		if (!_triggered && !Input.GetKey(KeyCode.Space)&& (Input.GetKeyDown(KeyCode.DownArrow)
		    || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
		{
			Trigger();
		}
	}

	private void OnMouseDown()
	{
		if (!_triggered)
		{
			Trigger();
		}
	}

	private void Trigger()
	{
		_triggered = true;
		Background.DOColor(BackgroundColorTarget, 2.5f);
		GetComponent<SpriteRenderer>().sprite = LampaSpriteOn;
		Face.DOFade(1, 2.5f);
		FindObjectOfType<RealityScheduler>().ScheduleMe(ShowBubble, 3.8f, gameObject.layer);
	}

	private void ShowBubble()
	{
		FirstBubble.SetActive(true);
	}

	public void ShowFace(Sprite sprite)
	{
		FindObjectOfType<RealityScheduler>().ScheduleMe(()=>Face.sprite = sprite , 0.8f, gameObject.layer);
	}
}
