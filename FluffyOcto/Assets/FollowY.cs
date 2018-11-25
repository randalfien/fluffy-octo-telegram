using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowY : MonoBehaviour
{
	public Transform ToFollow;
	
	// Update is called once per frame
	void Update ()
	{
		var pos = transform.localPosition;
		pos.y = ToFollow.localPosition.y;
		transform.localPosition = pos;
	}
}
