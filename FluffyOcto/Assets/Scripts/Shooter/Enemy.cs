using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Speed = 10f;
	public GameObject BloodPrefab;

	private void Start()
	{
		Speed += Random.Range(-2f, 2f);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Bullet>() != null)
		{
			Destroy(other.gameObject);
			Die();
		}
	}

	void Update()
	{
		transform.localPosition += Vector3.left * Speed *  Mathf.Min(Time.deltaTime,0.1f);;
		if (transform.position.x < -45f)
		{
			var blood = Instantiate(BloodPrefab, transform.parent);
			blood.transform.position = transform.position;
			Destroy(gameObject);
		}
	}

	public void Die()
	{
		var blood = Instantiate(BloodPrefab, transform.parent);
		blood.transform.position = transform.position;
		Destroy(gameObject);
	}
}