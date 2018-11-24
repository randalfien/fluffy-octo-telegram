using UnityEngine;

public class Bullet : MonoBehaviour
{

	private Vector3 _dirVector;
	private float _timer;
	
	void Start ()
	{
		_dirVector = transform.up.normalized*100;
		print(_dirVector);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += _dirVector * Time.deltaTime;
		_timer += Time.deltaTime;
		if (_timer > 1.5f)
		{
			Destroy(gameObject);
		}
	}
}
