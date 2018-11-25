using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemVisibilityTrigger : MonoBehaviour
{
	public GameObject ObjectToShow;
	public UnityEvent OnShow;
	private bool _wasShown = false;
	private void Start()
	{
		ObjectToShow.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		ObjectToShow.SetActive(true);

		if (_wasShown == false)
		{
			_wasShown = true;
			OnShow.Invoke();
		}
	}


	private void OnTriggerExit2D(Collider2D other)
	{
		ObjectToShow.SetActive(false);
	}
}