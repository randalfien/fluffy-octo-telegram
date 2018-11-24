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

    public GameObject Horizont;
	
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		var collectible = other.gameObject.GetComponent<CollectibleItem>();
		if (collectible)
		{
			other.gameObject.SetActive(false);
			collectible.TextObject.SetActive(true);
			var nextItem = collectible.NextItem;
			if (nextItem != null)
			{
				Horizont.transform.DOLocalMoveY(nextItem.transform.localPosition.y + 150f, 1f);
			}

			if (collectible.ClosestThis != null)
			{
				collectible.ClosestThis.SetActive(true);
				var closingSprite = collectible.ClosestThis.GetComponent<SpriteRenderer>();
				var clr = collectible.OrigClosestThisColor;
				clr.a = 0;
				closingSprite.color = clr;
				closingSprite.DOFade(1, 0.3f);
			}
		}
	}

	private void SetOrientation(int angle)
	{
		_renderer.gameObject.transform.DOLocalRotate(new Vector3(0, 0, angle), 0.3f);
	}
}