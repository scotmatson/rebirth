using Assets.Scripts.PlayerScripts;
using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float Speed = 10.0f;
    public FacingDirection Direction;
    //public GameObject parent;

    void Start()
    {
        //This needs to be updated so its not hardcoded to PlayerSpriter
        Direction = GameObject.Find("PlayerSprite").GetComponent<Player>().Direction;
    }


	// Update is called once per frame
	void Update () {


        var newPos = this.transform.position;

	    switch (Direction)
	    {
	        case FacingDirection.RIGHT:
	            newPos.x += Speed * Time.deltaTime;
	            break;
	        case FacingDirection.LEFT:
	            newPos.x -= Speed * Time.deltaTime;
	            break;
	        case FacingDirection.UP:
	            newPos.y += Speed * Time.deltaTime;
	            break;
	        case FacingDirection.DOWN:
	            newPos.y -= Speed * Time.deltaTime;
	            break;
	    }


        this.transform.position = newPos;
	}
}
