using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TopDownHero : MonoBehaviour
{
	private Rigidbody2D body;
	private float horizontal;
	private float vertical;
	private float moveLimiter = 0.7f;
	public float runSpeed = 20;

	private SpriteRenderer _renderer;

	public GameObject Horizont;
	
	private void Start()
	{
		body = GetComponent<Rigidbody2D>();
		_renderer = GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
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


		if (Mathf.Abs(horizontal) > 0.5f && Mathf.Abs(horizontal) > Mathf.Abs(vertical))
		{
			if (horizontal > 0)
			{
				SetOrientation(270);
			}
			else
			{
				SetOrientation(90);
			}
		}else if (Mathf.Abs(vertical) > 0.5f && Mathf.Abs(vertical) > Mathf.Abs(horizontal))
		{
			if (vertical > 0)
			{
				SetOrientation(0);
			}
			else
			{
				SetOrientation(180);
			}
		}else if (vertical > 0.5f && Math.Abs(vertical - horizontal) < 0.1f)
		{
			SetOrientation(-45);
		}else if (vertical > 0.5f && Math.Abs(vertical - (-horizontal)) < 0.1f)
		{
			SetOrientation(45);
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
		}
	}

	private void SetOrientation(int angle)
	{
		_renderer.gameObject.transform.DOLocalRotate(new Vector3(0, 0, angle), 0.3f);
	}
}