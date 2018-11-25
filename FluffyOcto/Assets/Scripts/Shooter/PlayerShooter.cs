using DG.Tweening;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

	public Transform GunPivot;
	public Transform Gun;
	public Transform GunPoint;

	public float RotationSpeed;
	public GameObject BulletPrefab;
	private float _angle = 270;

	public float ShootTimeMin = 0.2f;

	private float _timeLast = 0;

	public float AngleMin = 200;
	public float AngleMax = 340;

	private bool _shootingEnabled = true;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _angle += RotationSpeed;
            if (_angle > AngleMax)
            {
                _angle = AngleMax;
            }
            GunPivot.transform.localRotation = Quaternion.Euler(0, 0, _angle);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _angle -= RotationSpeed;
            if (_angle < AngleMin)
            {
                _angle = AngleMin;
            }
            GunPivot.transform.localRotation = Quaternion.Euler(0, 0, _angle);
        }


        if (_shootingEnabled && Time.time - _timeLast > ShootTimeMin)
        {
            Shoot();
        }

    }

	public void StopShooting()
	{
		FindObjectOfType<RealityScheduler>().ScheduleMe(() => _shootingEnabled = false, 1f, gameObject.layer);
		var enemies = FindObjectsOfType<Enemy>();
		foreach (var enemy in enemies)
		{
			enemy.Die();
		}
	}

	private void Shoot()
	{
		_timeLast = Time.time;
		//Add bullet
		var bullet = Instantiate(BulletPrefab, transform.parent);
		bullet.transform.position = GunPoint.position;
		bullet.transform.localRotation = GunPivot.transform.localRotation;
		//Recoil
		var origY = Gun.localPosition.y; 
		Gun.localPosition += Vector3.down * 1f;
		Gun.DOLocalMoveY(origY, ShootTimeMin);
	}
}
