using System;
using UnityEngine;
using UnityEngine.Events;

public class ProgressBar : MonoBehaviour
{
	public SpriteRenderer ActiveSprite;

	private float _step = 0;
	private float _startX;
	[Range(0, 1)] public float Progress;

	public bool TimedProgress;
	public float Time;

	public UnityEvent Complete;
	private bool invokedAlready;

	public Transform HookToCamera;
	// Use this for initialization
	void Start()
	{
		var ratio = Screen.width / (float) Screen.height;
		if (ratio > 16 / 9f)
		{
			transform.localScale = new Vector3(ratio * 9 / 16f, 1, 1);
		}

		_step = (ActiveSprite.transform.localScale.x * 1280f / 10f) / 16f;
		print(_step);
		_startX = ActiveSprite.transform.localPosition.x;

		if (TimedProgress)
		{
			FindObjectOfType<RealityScheduler>().ScheduleMe(Advance, Time / 16f, gameObject.layer);
		}
	}

	public void AddProgress(float amount)
	{
		Progress += amount;
	}

	void Advance()
	{
		Progress += 1 / 16f;
		if (Math.Abs(Progress - 1) < 0.01f)
		{
			Progress = 1;
		}
		else
		{
			FindObjectOfType<RealityScheduler>().ScheduleMe(Advance, Time / 16f, gameObject.layer);
		}
	}

	public void CompleteAfterDelay()
	{
		FindObjectOfType<RealityScheduler>().ScheduleMe(CompleteProgress, 1.5f, gameObject.layer);
	}

	private void CompleteProgress()
	{
		Progress = 1;
	}

	
	void Update()
	{
		if (HookToCamera != null)
		{
			var camPos = HookToCamera.localPosition;
			transform.localPosition = new Vector3( camPos.x, camPos.y, transform.localPosition.z );
		}
		
		if (invokedAlready) return;
	
		
		var pos = ActiveSprite.transform.localPosition;
		Progress = Mathf.Min(1f, Progress);
		pos.x = _startX + Mathf.Floor(Progress * 16f - 16f) * _step;
		ActiveSprite.transform.localPosition = pos;

		if (Progress >= 1 && !invokedAlready)
		{
			invokedAlready = true;
			Complete.Invoke();
		}
	}
}