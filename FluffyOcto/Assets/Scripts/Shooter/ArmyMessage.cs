using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ArmyMessage : MonoBehaviour
{
	public float Delay;
	public float Duration = 2f;

	public UnityEvent OnShow;
	// Use this for initialization
	void Start ()
	{
		var text = GetComponent<TextMeshPro>(); 
		text.color = Color.clear;
		FindObjectOfType<RealityScheduler>().ScheduleMe(StartMsg, Delay, gameObject.layer);
		FindObjectOfType<RealityScheduler>().ScheduleMe(Rem, Delay+Duration, gameObject.layer);
	}
	
	void StartMsg () {
		OnShow.Invoke();
		var text = GetComponent<TextMeshPro>();
		text.DOFade(1, 0.1f);
	}
	
	void Rem () {
		Destroy(gameObject);
	}
}
