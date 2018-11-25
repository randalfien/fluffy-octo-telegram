using UnityEngine;
using UnityEngine.Events;

public class OptionsBubble : MonoBehaviour
{

	public GameObject Arrow1;
	public GameObject Arrow2;

	public GameObject NextBubble1;
	public GameObject NextBubble2;

	public GameObject Text1;
	public GameObject Text2;

	private bool _firstSelected;

	private bool _ended;
	public UnityEvent OnEnd;
	
	public ProgressBar Progress;
	// Use this for initialization
	void Start ()
	{
		_firstSelected = true;
		SetVisibility();
		if (NextBubble1 != null)
		{
			NextBubble1.SetActive(false);
			NextBubble2.SetActive(false);
		}

		Invoke("ResetColliders",0.5f);
	}

	private void ResetColliders()
	{
		Text1.AddComponent<BoxCollider2D>();
		var list1 = Text1.AddComponent<EventListener>();
		list1.OnMouseClick.AddListener(Option1Clicked);
		
		Text2.AddComponent<BoxCollider2D>();
		var list2 = Text2.AddComponent<EventListener>();
		list2.OnMouseClick.AddListener(Option2Clicked);
	}

	private void Option1Clicked()
	{
		EndOn(true);
	}
	private void Option2Clicked()
	{
		EndOn(false);
	}
	
	
	
	private void SetVisibility()
	{
		Arrow1.SetActive(_firstSelected);
		Arrow2.SetActive(!_firstSelected);
	}

	// Update is called once per frame
	void Update ()
	{
		if (_ended) return;
		if (_firstSelected && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			_firstSelected = false;
			SetVisibility();
		}
		
		if (!_firstSelected && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			_firstSelected = true;
			SetVisibility();
		}

		if ( Input.GetKeyDown(KeyCode.RightArrow) ||  Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			EndOn(_firstSelected);
		}
	}

	private void EndOn(bool isFirst)
	{
		Progress.AddProgress(0.25f);
		_ended = true;
		if (NextBubble1 == null)
		{
			Arrow1.SetActive(false);
			Arrow2.SetActive(false);
			if (isFirst)
			{
				Text2.SetActive(false);
			}
			else
			{
				Text1.SetActive(false);
			}
			GetComponent<SpriteRenderer>().enabled = false;
			OnEnd.Invoke();
			return;
		}
			
			
		if (isFirst)
		{
			NextBubble1.SetActive(true);
		}
		else
		{
			NextBubble2.SetActive(true);
		}
			
		gameObject.SetActive(false);
	}
}
