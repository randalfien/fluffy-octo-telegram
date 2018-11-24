using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

	public GameObject RealityOnRoot;
	
	public GameObject RealityOffRoot;
	public ToggleButton Toggle;
	private void Start()
	{
		RealityOffRoot.SetActive(false);
		RealityOnRoot.SetActive(true);
		Toggle.OnToggled.AddListener(ToggleReality);
	}
	
	private void ToggleReality()
	{
		bool on = Toggle.Toggled;
		Debug.Log(""+on);
		RealityOffRoot.SetActive(!on);
		RealityOnRoot.SetActive(on);
	}
}
