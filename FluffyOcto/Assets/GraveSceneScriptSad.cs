using UnityEngine;

public class GraveSceneScriptSad : MonoBehaviour {
	
	public GameObject Text1;
	private bool _waitingForX;
	public GameObject Dest;
	public ProgressBar Progress;
	void Start () 
	{
		Text1.SetActive(false);
		Dest.SetActive(false);
		FindObjectOfType<RealityScheduler>().ScheduleMe(Step1, 2f, gameObject.layer);
	}
	
	void Step1()
	{
		Text1.SetActive(true);
		_waitingForX = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_waitingForX && Input.GetKeyDown(KeyCode.X))
		{
			WaterPlants();
		}
	}
	
	
	private void WaterPlants()
	{
		_waitingForX = false;
		Text1.SetActive(false);
		Dest.SetActive(true);
		FindObjectOfType<RealityScheduler>().ScheduleMe(FinalStep, 4f, gameObject.layer);
	}
	
	private void FinalStep()
	{
		Progress.CompleteAfterDelay();
	}
}
