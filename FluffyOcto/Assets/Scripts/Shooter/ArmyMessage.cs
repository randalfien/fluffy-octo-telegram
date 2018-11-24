using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ArmyMessage : MonoBehaviour
{
	public float Delay;
	public float Duration = 2f;
	// Use this for initialization
	void Start ()
	{
		var text = GetComponent<TextMeshPro>(); 
		text.color = Color.clear;
		text.DOFade(1, 0.1f).SetDelay(Delay);
		Invoke(nameof(Rem),Delay+Duration);
	}
	
	// Update is called once per frame
	void Rem () {
		Destroy(gameObject);
	}
}
