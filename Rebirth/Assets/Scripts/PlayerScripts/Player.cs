using UnityEngine;


public class Player : MonoBehaviour {


    public float PlayerMovementSpeed;
    private Animator _anim;
    private CharacterController _cont;
    private FacingDirection _direction;

    // Use this for initialization
    void Start () {
		PlayerMovementSpeed = 3.0F;
    	_anim = GetComponent<Animator>();
        _cont = GetComponent<CharacterController>();
        _direction = FacingDirection.RIGHT;
    }
	
    // Update is called once per frame
   	void Update () {
		Move ();
		Attack ();
    }

	void Move () {

		var deltaX = Input.GetAxis( "Horizontal" ) * PlayerMovementSpeed;
		var deltaY = Input.GetAxis( "Vertical" ) * PlayerMovementSpeed;
		var newPosition = new Vector3(deltaX, deltaY, 0);

        //Move the Player using Character Controller Move to obey basic collsion
        _cont.Move(newPosition * Time.deltaTime);
        
        UpdateDirection(deltaX,deltaY);
		
        _anim.SetFloat ("moveX", deltaX);

        //Prvents animation problem with moving diagnol by animiation going sideways but up or down
	    if (deltaX != 0f)
	    {
	        deltaY = 0f;
	    }
        _anim.SetFloat("moveY", deltaY);

    }

	void Attack ()
	{
	    var attacking = Input.GetKeyDown(KeyCode.Mouse0);
	    _anim.SetBool("attacking", attacking);


	}

    /// <summary>
    /// Method that updates the Facing Direction to be used for Firing
    /// </summary>
    /// <param name="deltaX"></param>
    /// <param name="deltaY"></param>
    void UpdateDirection(float deltaX, float deltaY)
    {
        if (deltaX > 0)
        {
            _direction = FacingDirection.RIGHT;
        }
        else if (deltaX < 0)
        {
            _direction = FacingDirection.LEFT;
        }
        else if (deltaY > 0)
        {
            _direction = FacingDirection.UP;
        }
        else if (deltaY < 0)
        {
            _direction = FacingDirection.DOWN;
        }
    }


}

public enum FacingDirection { LEFT = 1, RIGHT = 2, UP = 3, DOWN = 4 };

