using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
	public Sprite SpriteOn;

	public Sprite SpriteOff;

	private bool _toggled;
	public bool Toggled => _toggled;

	public UnityEvent OnToggled;
	
	private void OnMouseDown()
	{
		_toggled = !_toggled;
		GetComponent<SpriteRenderer>().sprite = _toggled ? SpriteOn : SpriteOff;
		OnToggled?.Invoke();
	}
}
