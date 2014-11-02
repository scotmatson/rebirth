using Assets.Scripts.PlayerScripts;
using UnityEngine;


public class Player : MonoBehaviour {


    public float PlayerMovementSpeed;
    private Animator _anim;
    private CharacterController _cont;
    public  FacingDirection Direction;
    public GameObject ShootableGameObject;

    // Use this for initialization
    void Start () {
		PlayerMovementSpeed = 6.0F;
    	_anim = GetComponent<Animator>();
        _cont = GetComponent<CharacterController>();
        Direction = FacingDirection.RIGHT;
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
	    var attacking = Input.GetKeyDown(KeyCode.Mouse0);

	    _anim.SetBool("attacking", attacking);

	    var offset = 1;

	    Vector3 spawnPosition = transform.position;

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
            Instantiate(ShootableGameObject, spawnPosition, transform.rotation);
			GetComponent<AudioSource> ().Play ();

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