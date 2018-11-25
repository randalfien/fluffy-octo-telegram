using UnityEngine;

public class IntroScript : MonoBehaviour
{

	public SpriteRenderer Logo;
	public SpriteRenderer Bg;

	public Sprite Logo1Sprite;
	public Sprite Logo2Sprite;
	
	public Sprite Bg1Sprite;
	public Sprite Bg2Sprite;

	private bool toggled;
	
	// Use this for initialization
	void Start ()
	{
		Logo.sprite = Logo1Sprite;
		Bg.sprite = Bg1Sprite;
	}
	
	
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			toggled = !toggled;
			Logo.sprite = toggled ? Logo2Sprite: Logo1Sprite;
			Bg.sprite = toggled ? Bg2Sprite : Bg1Sprite;
		}
	}
}
