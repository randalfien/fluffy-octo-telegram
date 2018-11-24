using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Blood : MonoBehaviour {

	void Start ()
	{
		GetComponent<SpriteRenderer>().DOFade(0, 1f).OnComplete(Rem);
	}

	private void Rem()
	{
		Destroy(gameObject);
	}

}
