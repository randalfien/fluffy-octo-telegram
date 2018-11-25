using UnityEngine;

public class Rainfall : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var tipOrig = transform.GetChild(0);
		for (int i = 0; i < 100; i++)
		{
			for (int j = 0; j < 100; j++)
			{
				var tip = Instantiate(tipOrig, transform);
				tip.transform.localPosition = new Vector3( i/100f * 45 - 10f, j/80f * 45,0)*10 + Random.insideUnitSphere*8;
				tip.transform.localRotation = Quaternion.Euler(0,0,165f);
				tip.GetComponent<Bullet>().speed = 10f + Random.Range(0f, 1f);
				tip.GetComponent<Bullet>().maxLife = 10f - Random.Range(0f,2f);
				tip.GetComponent<FrameAnim>()._AnimProgress = Random.Range(0f,2f);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
