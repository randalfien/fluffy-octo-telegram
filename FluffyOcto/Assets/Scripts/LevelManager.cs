using DG.Tweening;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

	public GameObject RealityOnRoot;
	
	public GameObject RealityOffRoot;
	public ToggleButton Toggle;
	
	public GameObject WipeObjectReal;
	public GameObject WipeObjectUnReal;

	public Camera RealCamera;
	public Camera UnrealCamera;

	private RealityScheduler _scheduler;
	
	private void Start()
	{
		/*	RealityOffRoot.SetActive(false);
			RealityOnRoot.SetActive(true);*/
		Toggle.OnToggled.AddListener(ToggleReality);
		_scheduler = GetComponent<RealityScheduler>();
		if (_scheduler)
		{
			_scheduler.VisibleLayer = LayerMask.NameToLayer("Scene Unreal");
		}
		SetCameras(false);
	}

	private void SetCameras(bool realOn)
	{
		
		
		RealityOffRoot.SetActive(!realOn);
		RealityOnRoot.SetActive(realOn);
		
		RealCamera.gameObject.SetActive(realOn);
		UnrealCamera.gameObject.SetActive(!realOn);
		
		RealCamera.clearFlags = CameraClearFlags.SolidColor;
		UnrealCamera.clearFlags = CameraClearFlags.SolidColor;
		
		WipeObjectUnReal.SetActive(false);
		WipeObjectReal.SetActive(false);
	}

	private void SetReal(bool realOn)
	{
		Debug.Log(""+realOn);
		
		RealityOffRoot.SetActive(true);
		RealityOnRoot.SetActive(true);
		
		RealCamera.gameObject.SetActive(true);
		UnrealCamera.gameObject.SetActive(true);

		// THE SCENE THATS COMING IN VIEW SHOULD BE ON TOP
		RealCamera.clearFlags = realOn ? CameraClearFlags.Nothing : CameraClearFlags.SolidColor;
		UnrealCamera.clearFlags = !realOn ? CameraClearFlags.Nothing : CameraClearFlags.SolidColor;

		RealCamera.depth = realOn ? 1 : 0;
		UnrealCamera.depth = realOn ? 0 : 1;

		var wiper = realOn ? WipeObjectReal : WipeObjectUnReal;
		wiper.SetActive(true);
		wiper.transform.localPosition = new Vector3(0, 0, -10);
		wiper.transform.DOMoveX(-400f, 1f).OnComplete(() =>
		{
			Toggle.gameObject.SetActive( true );
			SetCameras(realOn);
		});
	}

	private void ToggleReality()
	{
		bool realOn = Toggle.Toggled;
		Toggle.gameObject.SetActive( false );
		if (_scheduler)
		{
			_scheduler.VisibleLayer = LayerMask.NameToLayer(realOn ? "Scene Real" : "Scene Unreal");
		}
		SetReal(realOn);
	}
}

