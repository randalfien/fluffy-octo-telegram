using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Speed = 10f;
	public GameObject BloodPrefab;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Bullet>() != null)
		{
			var blood = Instantiate(BloodPrefab, transform.parent);
			blood.transform.position = transform.position;
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}

	void Update()
	{
		transform.localPosition += Vector3.left * Speed * Time.deltaTime;
	}
}