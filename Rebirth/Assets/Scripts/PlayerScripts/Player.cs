using UnityEngine;


public class Player : MonoBehaviour {
	//float deltaX;
	//float deltaY;
	//float newPosition;
    public float PlayerMovementSpeed;
    private Animator _anim;
    //private CharacterController _cont;

    // Use this for initialization
    void Start () {
		PlayerMovementSpeed = 3.0F;
    	_anim = GetComponent<Animator>();
        //_cont = GetComponent<CharacterController>();
    }
	
    // Update is called once per frame
   	void Update () {
		move ();
		attack ();
    }

	void move () {
		//deltaX = Input.GetAxis( "Horizontal" ) * PlayerMovementSpeed;
		//deltaY = Input.GetAxis( "Vertical" ) * PlayerMovementSpeed;
		//newPosition = new Vector3(deltaX, deltaY, 0);
		//_cont.Move( newPosition * Time.deltaTime );
		float translateX = Input.GetAxis ("Horizontal") * PlayerMovementSpeed;
		float translateY = Input.GetAxis ("Vertical") * PlayerMovementSpeed;
		
		//Run left and right
		if (translateX != 0) {
			translateY = 0;
			translateX *= Time.deltaTime;
			transform.Translate (translateX, 0f, 0f);
		}

		//Run up and down
		if (translateY != 0) {
			translateX = 0;
			translateY *= Time.deltaTime;
			transform.Translate (0f, translateY, 0f);
		}

		_anim.SetFloat ("moveX", translateX);
		_anim.SetFloat ("moveY", translateY);
	}

	void attack () {
		bool attacking = false;
		attacking = (Input.GetAxis ("Fire1") == 1) ? true : false;
		_anim.SetBool ("attacking", attacking);
	}	
}

