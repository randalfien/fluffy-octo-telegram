using UnityEngine;
using System.Collections;

public class PlatformerHero : MonoBehaviour {

	public enum inputState 
	{ 
		None, 
		WalkLeft, 
		WalkRight, 
		Jump
	}



    [HideInInspector] 
	public inputState currentInputState;

    public bool MultiJump = true;
    private bool jumpedSinceGrounded = false;
	
	[HideInInspector] 
	public enum facing { Right, Left }

	[HideInInspector] 
	public facing facingDir;

	// raycast stuff
	private RaycastHit2D hit;
	private Vector2 physVel = new Vector2();
	[HideInInspector] public bool Grounded = false;
	public LayerMask GroundMask; // Ground layer mask

	private Transform _transform;
	private Rigidbody2D _rigidbody;

	// edit these to tune character movement	
	public float RunVel = 25f;
	public float JumpVel = 80f; 
	public float Jump2Vel = 40f;
	public float FallVel = 10f;
	
	private float _moveVel;
	private float _pVel = 0f;


	/// ANIMATION
	public enum anim 
	{ 
		None,
		WalkLeft,
		WalkRight,
		StandLeft,
		StandRight,
		FallLeft,
		FallRight
	}
	private Animator _animator;
	// hash the animation state string to save performance
//	private int _p1AnimState = Animator.StringToHash("State");
	private int _animState;
	private anim currentAnim;

	public Sprite[] WalkSprites;
	private float _walkAnimProgress = 0;
	public int FramesPerSecond = 12;
	private SpriteRenderer _renderer;

	/*private void OnCollisionEnter2D(Collision2D collision)
	{
		// Dirty hack, should  check whether standing instead
		jumpedSinceGrounded = false;
	}*/
	
	public void Awake()
	{
		_transform = transform;
		_rigidbody = GetComponent<Rigidbody2D>();
		_renderer = GetComponent<SpriteRenderer>();
//		_animator = this.GetComponent<Animator>();
//		_animState = _p1AnimState;
	}


    // Update is called once per frame
    void Update ()
    {
	    int spriteFrame = 0; 
		// run left
		if( currentInputState ==  inputState.WalkLeft &&  Grounded == true && currentAnim != anim.WalkLeft)
		{
			currentAnim = anim.WalkLeft;
//			_animator.SetInteger(_animState, 1);
			_walkAnimProgress += Time.deltaTime*100;
			_renderer.flipX = true;
		}
		
		// stand left
		if( currentInputState !=  inputState.WalkLeft &&  Grounded == true && currentAnim != anim.StandLeft &&  facingDir ==  facing.Left)
		{
			currentAnim = anim.StandLeft;
//			_animator.SetInteger(_animState, 0);
			_walkAnimProgress = 0;
			_renderer.flipX = true;
		}
		
		// run right
		if( currentInputState ==  inputState.WalkRight &&  Grounded == true && currentAnim != anim.WalkRight)
		{
			currentAnim = anim.WalkRight;
//			_animator.SetInteger(_animState, 1);
			_renderer.flipX = false;
		}
	    if (Grounded && (currentInputState == inputState.WalkRight || currentInputState == inputState.WalkLeft))
	    {
		    _walkAnimProgress += Time.deltaTime*FramesPerSecond;
		    spriteFrame = Mathf.FloorToInt(_walkAnimProgress) % WalkSprites.Length;
	    }
		
		// stand right
		if( currentInputState !=  inputState.WalkRight &&  Grounded == true && currentAnim != anim.StandRight &&  facingDir ==  facing.Right)
		{
			currentAnim = anim.StandRight;
	//		_animator.SetInteger(_animState, 0);
			_walkAnimProgress = 0;
			_renderer.flipX = false;
		}
		
		// fall or jump left
		if( Grounded == false && currentAnim != anim.FallLeft &&  facingDir ==  facing.Left)
		{
			currentAnim = anim.FallLeft;
	//		_animator.SetInteger(_animState, 2);
			_renderer.flipX = true;
		}
		
		// fall or jump right
		if( Grounded == false && currentAnim != anim.FallRight &&  facingDir ==  facing.Right)
		{
			currentAnim = anim.FallRight;
//			_animator.SetInteger(_animState, 2);
			_renderer.flipX = false;
		}
	    
	    _renderer.sprite = WalkSprites[spriteFrame];
	}

    public void FixedUpdate()
    {
        // inputstate is none unless one of the movement keys are pressed
        currentInputState = inputState.None;

        // move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            currentInputState = inputState.WalkLeft;
            facingDir = facing.Left;
        }

        // move right
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && currentInputState != inputState.WalkLeft)
        {
            currentInputState = inputState.WalkRight;
            facingDir = facing.Right;
        }

        // jump
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(MultiJump || !jumpedSinceGrounded)
            {
                currentInputState = inputState.Jump;
                jumpedSinceGrounded = true;

            }
        }

        physVel = Vector2.zero;

        // move left
        if (currentInputState == inputState.WalkLeft)
        {
            physVel.x = -RunVel;
        }

        // move right
        if (currentInputState == inputState.WalkRight)
        {
            physVel.x = RunVel;
        }

        // jump
        if (currentInputState == inputState.Jump)
        {
            _rigidbody.velocity = new Vector2(physVel.x, JumpVel);
        }

        // use raycasts to determine if the player is standing on the ground or not
        if (Physics2D.Raycast(new Vector2(_transform.position.x - 0.1f, _transform.position.y-5f), Vector2.down, 8f, GroundMask).collider != null
            || Physics2D.Raycast(new Vector2(_transform.position.x + 0.1f, _transform.position.y-5f), Vector2.down, 8f, GroundMask).collider != null)
        {
            // Doesn't work properly (not sure why, something to do with layers)
	        print("GROUNDED");
            Grounded = true;
        }
        else
        {
	        print("NOT GROUNDED");
            Grounded = false;
            _rigidbody.AddForce(-Vector3.up * FallVel);
        }

        if (Grounded)
        {
            jumpedSinceGrounded = false;
        }
		
		// actually move the player
		_rigidbody.velocity = new Vector2(physVel.x, _rigidbody.velocity.y);
	}

}
