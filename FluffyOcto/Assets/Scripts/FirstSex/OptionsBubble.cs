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
		if (_firstSelected && Input.GetKeyDown(KeyCode.DownArrow))
		{
			_firstSelected = false;
			SetVisibility();
		}
		
		if (!_firstSelected && Input.GetKeyDown(KeyCode.UpArrow))
		{
			_firstSelected = true;
			SetVisibility();
		}

		if ( Input.GetKeyDown(KeyCode.RightArrow))
		{
			_ended = true;
			if (NextBubble1 == null)
			{
				Arrow1.SetActive(false);
				Arrow2.SetActive(false);
				if (_firstSelected)
				{
					Text2.SetActive(false);
				}
				else
				{
					Text1.SetActive(false);
				}
				print("ENDD");
				OnEnd.Invoke();
				return;
			}
			
			
			if (_firstSelected)
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
}
