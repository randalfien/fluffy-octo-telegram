using System;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider2D))]
[AddComponentMenu("CE Toolbox/Event Listener")]
public class EventListener : MonoBehaviour {

	public UnityEvent OnMouseEnterEvent = new UnityEvent();
	public UnityEvent OnMouseExitEvent = new UnityEvent();
	public UnityEvent OnMouseClick = new UnityEvent();
	
	private void OnMouseEnter()
	{
		OnMouseEnterEvent.Invoke();
	}
	
	private void OnMouseExit()
	{
		OnMouseExitEvent.Invoke();
	}
		
	private void OnMouseUpAsButton()
	{
		OnMouseClick.Invoke();
	}
}
