using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Microsoft.SqlServer.Server;
using UnityEngine;

public class Lamp : MonoBehaviour
{

	public SpriteRenderer Background;
	public SpriteRenderer FaceLeft;
	public SpriteRenderer FaceRight;
	public Color BackgroundColorTarget;
	public Sprite LampaSpriteOn;
	private bool _triggered;

	public GameObject FirstBubble;

	public bool isReal;
	
	private void Start()
	{
		var blc = Color.black;
		blc.a = 0;
		FaceLeft.color = blc;
		FaceRight.color = blc;
		FaceLeft.transform.position = new Vector3(-105,0,0);
		FaceRight.transform.position = new Vector3(105,0,0);
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
		FaceLeft.DOFade(1, 2.5f);
		FaceRight.DOFade(1, 2.5f);
		FaceLeft.transform.DOLocalMoveX(-72 +( isReal ? -15 : 0), 3.5f);
		FaceRight.transform.DOLocalMoveX(72 + (isReal ? 15 : 0), 3.5f);
		FindObjectOfType<RealityScheduler>().ScheduleMe(ShowBubble, 3.8f, gameObject.layer);
	}

	private void ShowBubble()
	{
		FirstBubble.SetActive(true);
	}
}
