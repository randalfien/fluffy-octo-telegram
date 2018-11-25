using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform ToFollow;
	public Transform FollowCamera;

    public bool InitOnPosition = false;
    private bool inited = false;

	public Vector3 Offset;
    public Vector3 OffsetFlipX = new Vector3(0, 0, 0);
    private Vector3 lastOffset;

	private Vector3 _speed;

    public bool FlipX = false;
    private Vector3 lastLocation = new Vector3();

	private float _startZ;

	private void Awake()
	{
        lastOffset = Offset;
        _startZ = FollowCamera.transform.localPosition.z;
	}

	// Update is called once per frame
	void Update ()
	{
        if(!inited && InitOnPosition)
        {
            lastOffset = Offset;

            inited = true;
            FollowCamera.transform.position = ToFollow.position + Offset;

            lastLocation = ToFollow.localPosition;
            return;
        }

        if (FlipX)
        {
            var xDiff = lastLocation.x - ToFollow.localPosition.x;
            if(xDiff < 0)
            {
                lastOffset = Offset;
            }
            else if(xDiff > 0)
            {
                lastOffset = OffsetFlipX;
            }
        }
        
        var targetPos = ToFollow.position + lastOffset;

        var current = FollowCamera.transform.position;
		current = Vector3.SmoothDamp(current, targetPos, ref _speed, 0.3f );
		current.z = _startZ;
		FollowCamera.transform.position = current;

        lastLocation = ToFollow.localPosition;

    }
}
