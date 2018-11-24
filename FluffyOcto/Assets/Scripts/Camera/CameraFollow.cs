using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform ToFollow;
	public Transform FollowCamera;

	public Vector3 Offset;
	private Vector3 _speed;

	private float _startZ;

	private void Awake()
	{
		_startZ = FollowCamera.transform.localPosition.z;
	}

	// Update is called once per frame
	void Update ()
	{
		var targetPos = ToFollow.position + Offset;
		var current = FollowCamera.transform.position;
		current = Vector3.SmoothDamp(current, targetPos, ref _speed, 0.3f );
		current.z = _startZ;
		FollowCamera.transform.position = current;
	}
}
