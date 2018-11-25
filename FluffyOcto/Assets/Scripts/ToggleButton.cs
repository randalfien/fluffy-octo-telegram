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
	public bool BanToggle;

	public bool Reposition = true;
	private float lastTime = 0;
	
	private void OnMouseDown()
	{
		if (!_shouldSwitch) return;
		if (Time.time - lastTime < 1.0)
		{
			return;
		}
		lastTime = Time.time;
		_toggled = !_toggled;
		GetComponent<SpriteRenderer>().sprite = _toggled ? SpriteOn : SpriteOff;
		OnToggled?.Invoke();
	}

	private void Start()
	{
		if (Reposition)
		{
			var ratio = Screen.width / (float) Screen.height;
			transform.localPosition = new Vector3(54 * ratio - 22f, transform.localPosition.y, transform.localPosition.z);
		}
	}

	public void SetEnabled(bool b)
	{
		_shouldSwitch = b;
	}

	private void Update()
	{
		if (!BanToggle && Input.GetKeyDown(KeyCode.Space))
		{
			OnMouseDown();
		}
	}
}
