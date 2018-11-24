using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RealitySchedulerTest : MonoBehaviour
{

	public float TT = 2f;
	// Use this for initialization
     	void Start ()
	     {
		     var sch = FindObjectOfType<RealityScheduler>();
		     sch.ScheduleMe(Rotate, TT, gameObject.layer);
	     }
     	
     	
     	void Rotate ()
	     {
		     print("rotate");
		     transform.DOBlendableLocalRotateBy(new Vector3(0,0,30f), 1f);
	     }
}
