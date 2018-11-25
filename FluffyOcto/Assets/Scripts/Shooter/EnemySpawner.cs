using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public GameObject EnemyPrefab;

	public float EnemyTimeDelay = 0.6f;

	private float _timeSinceLast;

	public bool IsSpawning;
	
	// Update is called once per frame
	void Update ()
	{
		if (!IsSpawning) return;
		_timeSinceLast += Mathf.Min(Time.deltaTime,0.1f);
		if (_timeSinceLast > EnemyTimeDelay)
		{
			AddEnemy();
			_timeSinceLast = 0;
		}
	}

	public void Stop()
	{
		IsSpawning = false;
	}

	private void AddEnemy()
	{
		var enemy = Instantiate(EnemyPrefab, transform.parent);
		enemy.transform.localPosition = new Vector3(transform.localPosition.x, Random.Range(-35f,35f), 0);
	}
}
