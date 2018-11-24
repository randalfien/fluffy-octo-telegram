using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public GameObject EnemyPrefab;

	public float EnemyTimeDelay = 0.5f;

	private float _timeSinceLast; 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		_timeSinceLast += Time.deltaTime;
		if (_timeSinceLast > EnemyTimeDelay)
		{
			AddEnemy();
			_timeSinceLast = 0;
		}
	}

	private void AddEnemy()
	{
		var enemy = Instantiate(EnemyPrefab, transform.parent);
		enemy.transform.localPosition = new Vector3(transform.localPosition.x, Random.Range(-47f,47f), 0);
	}
}
