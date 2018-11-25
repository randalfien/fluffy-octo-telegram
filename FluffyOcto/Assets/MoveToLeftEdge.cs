using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeftEdge : MonoBehaviour
{

	public float Offset; 
	// Use this for initialization
	void Start () {
		var ratio = Screen.width / (float) Screen.height;
		transform.localPosition = new Vector3(-54 * ratio + Offset, transform.localPosition.y, transform.localPosition.z);
	}

	private void Update()
	{
		Start();
	}
}
