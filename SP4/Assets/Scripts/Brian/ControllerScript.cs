using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	private uint people = 0;
	float TimeCountDown;
	float groundRadius = 0.2f;

	bool doubleJump = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		TimeCountDown = 15f;
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

	void CollectPeople(Collider2D peopleCollider)
	{
		people++;
		Destroy (peopleCollider);

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
;
		if (collider.gameObject.CompareTag ("Citizen"))
			CollectPeople (collider);
		else
			HitByFire (collider);
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
		
		TimeCountDown = Mathf.MoveTowards(TimeCountDown, 0, Time.deltaTime);
		if(TimeCountDown <= 0)
		{
			LevelLoader.LoseLevel();
		}
		GameObject.Find("CountDown").GetComponent<Text>().text = "Time Left: " + TimeCountDown.ToString("n2");
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}