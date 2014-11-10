using Assets.Scripts.PlayerScripts;
using UnityEngine;


public class Player : MonoBehaviour {


    public float PlayerMovementSpeed;
    public  FacingDirection Direction;
    public GameObject ShootableGameObject;
    public float ThrowingFrequency;
    public bool IsPaused;
    private Animator _anim;
    private CharacterController _cont;
    private float _nextThrow ;
	public AudioSource playerSwingsAxe;

    // Use this for initialization
    void Start () {
		PlayerMovementSpeed = 6.0F;
    	_anim = GetComponent<Animator>();
        _cont = GetComponent<CharacterController>();
        Direction = FacingDirection.RIGHT;
        IsPaused = false;
		ThrowingFrequency = 0.5f;
		AudioSource[] playerAudio = GetComponents<AudioSource>();
		playerSwingsAxe = playerAudio [0];
    }
	
    // Update is called once per frame
   	void Update () {
		Move ();
		Attack ();
    }

	void Move () {

		var deltaX = Input.GetAxis( "Horizontal" ) * PlayerMovementSpeed;
		var deltaY = Input.GetAxis( "Vertical" ) * PlayerMovementSpeed;
		var newPosition = new Vector3(deltaX, 0, deltaY);

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

	    var attacking = (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && (Time.time > _nextThrow) && !IsPaused  ;

	    _anim.SetBool("attacking", attacking);

	    const int offset = 1;
	    var spawnPosition = transform.position;

        //These offsets stop the Axe from getting stuck wiht player collider
        switch (Direction)
        {
            case FacingDirection.RIGHT:
                spawnPosition.x += offset;
                break;
            case FacingDirection.LEFT:
                spawnPosition.x -= offset;
                break;
            case FacingDirection.UP:
                spawnPosition.z += offset;
                break;
            case FacingDirection.DOWN:
                spawnPosition.z -= offset;
                break;
        }


	    if (attacking)
	    {
            //Next Time Available to throw
	        _nextThrow = Time.time + ThrowingFrequency;
			playerSwingsAxe.Play ();
            Instantiate(ShootableGameObject, spawnPosition, transform.rotation);
	    }
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
            Direction = FacingDirection.RIGHT;
        }
        else if (deltaX < 0)
        {
            Direction = FacingDirection.LEFT;
        }
        else if (deltaY > 0)
        {
            Direction = FacingDirection.UP;
        }
        else if (deltaY < 0)
        {
            Direction = FacingDirection.DOWN;
        }
    }
}