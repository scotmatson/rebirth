using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public bool alive;
	public float direction;
	public float runSpeed;
	public bool isGrounded;
	public float jumpHeight;
	protected Animator anim;
	public float jewels;

	// Use this for initialization
	void Start () {
		alive = true;
		direction = 1;
		runSpeed = 3.0F;
		jewels = 0.0F;

		//Controls jump behavior
		isGrounded = false;
		jumpHeight = 105.0F;

		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGrounded) anim.SetBool ("Grounded", true);

		if (Input.GetAxis ("Jump") == 1 && isGrounded)
			jump ();

		if (Input.GetAxis ("Jump") == 0 && !isGrounded)
			fall ();

		run ();
	}

	
	void FixedUpdate() {
		isGrounded = Physics.Raycast (transform.position, -Vector3.up, .3f);
	}

	void run() {
		float translateX = Input.GetAxis ("Horizontal") * runSpeed;

		//Run left and right
		translateX *= Time.deltaTime;
		transform.Translate (translateX * direction, 0f, 0f);
		
		//Run animation
		if ((translateX < 0) && (direction == 1)) {
			transform.Rotate(0, -180, 0); direction = -1; 
		}
		if ((translateX > 0) && (direction == -1)) {
			transform.Rotate(0, 180, 0); direction = 1;
		}
		anim.SetFloat ("RunSpeed", Mathf.Abs (translateX));
	}

	void jump() {
		if (!isGrounded) return;
		isGrounded = false;
		anim.SetBool ("Grounded", false);
		rigidbody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Force);
	}

	void fall() {
		if (isGrounded) return;
		isGrounded = false;
		anim.SetBool ("Grounded", false);
	}
}
