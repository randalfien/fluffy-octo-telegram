using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVisibilityTrigger : MonoBehaviour
{
	public GameObject ObjectToShow;

	private void Start()
	{
		ObjectToShow.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		ObjectToShow.SetActive(true);
	}


	private void OnTriggerExit2D(Collider2D other)
	{
		ObjectToShow.SetActive(false);
	}
}