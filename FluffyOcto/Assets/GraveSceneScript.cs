using DG.Tweening;
using TMPro;
using UnityEngine;

public class GraveSceneScript : MonoBehaviour
{

	public GameObject Text1;

	public GameObject Person;
	public GameObject TextXToPress;

	public GameObject Konev;
	public GameObject KonevAktive;

	private bool isWaitingToWater;

	public ProgressBar Progress;
	
	public bool isHappy;
	// Use this for initialization
	void Start () {
		Text1.SetActive(false);
		Person.SetActive(false);
		TextXToPress.SetActive(false);
		KonevAktive.SetActive(false);
		FindObjectOfType<RealityScheduler>().ScheduleMe(Step1, 1f, gameObject.layer);
	}

	void Step1()
	{
		Text1.SetActive(true);
		FindObjectOfType<RealityScheduler>().ScheduleMe(Step2, 1.8f, gameObject.layer);
	}

	void Step2()
	{
		Text1.transform.DOMoveY(20f, 3);
		Text1.GetComponent<TextMeshPro>().DOFade(0, 2f);
		FindObjectOfType<RealityScheduler>().ScheduleMe(Step3, 2f, gameObject.layer);
	}

	void Step3()
	{
		Person.SetActive(true);
		var blc = Color.black;
		blc.a = 0;
		Person.GetComponent<SpriteRenderer>().color = blc;
		Person.GetComponent<SpriteRenderer>().DOFade(1, 1);
		FindObjectOfType<RealityScheduler>().ScheduleMe(Step4, 1f, gameObject.layer);
	}

	void Step4()
	{
		TextXToPress.SetActive(true);
		isWaitingToWater = true;
	}

	// Update is called once per frame
	void Update () {
		if (isWaitingToWater && Input.GetKeyDown(KeyCode.X))
		{
			WaterPlants();
		}
	}

	private void WaterPlants()
	{
		TextXToPress.SetActive(false);
		isWaitingToWater = false;
		Konev.SetActive(false);
		KonevAktive.SetActive(true);
		KonevAktive.transform.DOShakePosition(3f);
		FindObjectOfType<RealityScheduler>().ScheduleMe(FinalStep, 2f, gameObject.layer);
	}

	private void FinalStep()
	{
		Progress.CompleteAfterDelay();
	}
}
