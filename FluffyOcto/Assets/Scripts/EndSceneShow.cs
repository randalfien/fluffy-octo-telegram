using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EndSceneShow : MonoBehaviour
{

	public GameObject ToShow;
	public float Delay = 2f;
	public float KeepOnScreen = 0;
	
	void Start ()
	{
		ToShow.SetActive(false);
		var scheduler = FindObjectOfType<RealityScheduler>();
		
		Invoke(nameof(StartMsg), Delay);
		if (KeepOnScreen != 0)
		{
			Invoke(nameof(Rem), Delay+KeepOnScreen);
		}
	}
	
	void StartMsg () {
		ToShow.SetActive(true);
	}
	
	void Rem () {
		Destroy(ToShow);
	}
}
