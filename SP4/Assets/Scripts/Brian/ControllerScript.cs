using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {
	
	
	public float maxSpeed = 10;
	bool facingRight = true;
	
	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpForce = 700; 
	public float forwardMovementSpeed = 3.0f;
	private bool dead = false;
	float groundRadius = 0.2f;

	bool doubleJump = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		if (grounded)
			doubleJump = false;

		//anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		if (!dead) {
			Vector2 newVelocity = rigidbody2D.velocity;
			newVelocity.x = forwardMovementSpeed;
			rigidbody2D.velocity = newVelocity;
		}
	
		//if (!grounded)return; /*for disabling areal turn*/
	

		//float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs(forwardMovementSpeed));
		rigidbody2D.velocity = new Vector2 (forwardMovementSpeed * maxSpeed, rigidbody2D.velocity.y); 
		if (forwardMovementSpeed > 0 && !facingRight)
			Flip ();
		else if (forwardMovementSpeed < 0 && facingRight)
			Flip (); 
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		HitByFire(collider);
	}
	
	void HitByFire(Collider2D firecollider)
	{
		dead = true;
	}

	void Update()
	{
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) 
		{
			anim.SetBool ("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce*0.7f));

			if(!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}