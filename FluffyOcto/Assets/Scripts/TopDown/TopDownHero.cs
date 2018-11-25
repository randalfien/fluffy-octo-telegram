using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Networking;

public class TopDownHero : MonoBehaviour
{
    public bool Animate = true;
    public bool FlipX = true;

	private Rigidbody2D body;
	private float horizontal;
	private float vertical;
	private float moveLimiter = 0.7f;
	public float runSpeed = 20;

	private SpriteRenderer _renderer;


    public int FramesPerSecond = 12;
    private float _walkAnimProgress = 0;
    public Sprite[] WalkSprites;
	
	private void Start()
	{
		body = GetComponent<Rigidbody2D>();
		_renderer = GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{

        if(horizontal != 0 || vertical != 0)
        {
            _walkAnimProgress += Time.deltaTime * FramesPerSecond;
        }


        if (FlipX)
        {
            if (horizontal < 0) { _renderer.flipX = true; }
            else if (horizontal > 0) { _renderer.flipX = false; }
        }


        horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

        if (Animate)
        {
            int spriteFrame = Mathf.FloorToInt(_walkAnimProgress) % WalkSprites.Length;
            _renderer.sprite = WalkSprites[spriteFrame];
        }
    }

    void FixedUpdate()
	{
		if (horizontal != 0 && vertical != 0)
		{
			body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
		}
		else
		{
			body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		}
	}


	private void SetOrientation(int angle)
	{
		_renderer.gameObject.transform.DOLocalRotate(new Vector3(0, 0, angle), 0.3f);
	}
}