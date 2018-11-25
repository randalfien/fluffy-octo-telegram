using UnityEngine;

public class Bullet : MonoBehaviour
{

	private Vector3 _dirVector;
	private float _timer;
	
	void Start ()
	{
		_dirVector = transform.up.normalized*100;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += _dirVector *  Mathf.Min(Time.deltaTime,0.1f);;
		_timer +=  Mathf.Min(Time.deltaTime,0.1f);;
		if (_timer > 1.5f)
		{
			Destroy(gameObject);
		}
	}
}
