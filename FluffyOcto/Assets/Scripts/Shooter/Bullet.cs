using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	private Vector3 _dirVector;
	private float _timer;
	public float speed = 100;
	public float maxLife = 1.5f;
	void Start ()
	{
		_dirVector = transform.up.normalized*speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += _dirVector *  Mathf.Min(Time.deltaTime,0.1f);;
		_timer +=  Mathf.Min(Time.deltaTime,0.1f);;
		if (_timer > maxLife)
		{
			Destroy(gameObject);
		}
	}
}
