using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
	public Sprite SpriteOn;

	public Sprite SpriteOff;

	private bool _toggled;
	public bool Toggled => _toggled;

	public UnityEvent OnToggled;
	private bool _shouldSwitch = true;
	private void OnMouseDown()
	{
		if (!_shouldSwitch) return;
		_toggled = !_toggled;
		GetComponent<SpriteRenderer>().sprite = _toggled ? SpriteOn : SpriteOff;
		OnToggled?.Invoke();
	}

	public void SetEnabled(bool b)
	{
		_shouldSwitch = b;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnMouseDown();
		}
	}
}
