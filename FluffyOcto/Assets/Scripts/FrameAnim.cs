using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameAnim : MonoBehaviour {
	public Sprite[] Sprites;
	[HideInInspector] public float _AnimProgress = 0;
	public float FramesPerSecond = 12;
	private SpriteRenderer _renderer;
	// Use this for initialization
	void Start ()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		_AnimProgress += Time.deltaTime*FramesPerSecond;
		
		int spriteFrame = Mathf.FloorToInt(_AnimProgress) % Sprites.Length;
		_renderer.sprite = Sprites[spriteFrame];
	}
}
