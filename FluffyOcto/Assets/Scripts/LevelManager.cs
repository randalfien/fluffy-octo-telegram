using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool DefaultReal = true;

	public GameObject RealityOnRoot;
	
	public GameObject RealityOffRoot;
	public ToggleButton Toggle;
    private void Start()
    {
        RealityOffRoot.SetActive(!DefaultReal);
        RealityOnRoot.SetActive(DefaultReal);

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
