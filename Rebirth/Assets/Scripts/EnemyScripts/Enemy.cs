using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float AtackFreq;
    public float Damage; // Damage Enemy does to playe
    public bool InPursuit;
    public float PursuitDistance;
    public float Speed;
    public bool TouchingPlayer;
    private CharacterController _cont;
    private float _nextAttack;
    private GameObject _playerTarget;
    public bool isAlive;
    public AudioSource zombieIsHit;
    public int Health;

    // Use this for initialization
    private void Start()
    {
        isAlive = true;
        _playerTarget = GameObject.FindGameObjectWithTag("Player");

        zombieIsHit = GetComponent<AudioSource>();
        _cont = GetComponent<CharacterController>();
        Speed = 2;
        Damage = 10f;
        //Can we set up separate puruit variables for x and y axis?
        PursuitDistance = 20; //Enemies that exist just outside of the width of the viewport will pursue.
        InPursuit = false;

        //Freqeuency in which enemy does damage to the player
        AtackFreq = 2f; //Eveery 2s
        _nextAttack = 0f;

        TouchingPlayer = false;
    }

    private void Update()
    {
	   //I'm not sure we need this script. We are addressing Enemy through bullet collision
       //and health checks on line 150
       //if (!isAlive)
       // {
       //     Destroy(gameObject);
       // }

        if (!InPursuit)
        {
            InPursuit = ShouldPursuit();
        }
        
		else
        {
            if (!TouchingPlayer)
            {
                PursuitPlayer();
            }
        }
    }

    private bool ShouldPursuit()
    {
        float distanceToPlayer = Vector3.Distance(_playerTarget.transform.position, transform.position);
        return distanceToPlayer <= PursuitDistance;
    }

    // For AI Referenced 
    //http://answers.unity3d.com/questions/603634/having-issues-rotating-2d-sprites-to-face-another.html
    private void PursuitPlayer()
    {
        Vector3 newRotation = Quaternion.LookRotation(_playerTarget.transform.position - transform.position).eulerAngles;
        //for some reason this stil needs to be locked on the z
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 1);

        //Updating with .Move so that it obeys CharacterController Physics e.g dont go through walls
        Vector3 newPosition = transform.forward * Speed;
        _cont.Move(newPosition*Time.deltaTime);

		if(gameObject.name == "Demon") 
		{
			gameObject.animation.Play ("Walk");
		}
    }


    //Changed to continuously deal damage and not kill the enemy
    private void OnTriggerStay(Collider other)
    {
        // Debug.Log(other.gameObject.name);

        var playerState = GameObject.Find("PlayerSprite").GetComponent<PlayerState>();

        if (other.tag == "Player" || other.gameObject.tag == "Player")
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>().DealDamage(Damage);

            TouchingPlayer = true;
			if (Time.time > _nextAttack)
			{
				_nextAttack = Time.time + AtackFreq;
				playerState.DealDamage(Damage);
			}
		}
		else
		{
			TouchingPlayer = false;
		}
		
		//Dont try this at home. For some reason it doesnt like the tag...
        if (other.gameObject.tag == "Bullet" || other.tag == "Bullet" || other.name == "Bullet(Clone)")
        {
            //Gives Player Treasure for killing enemy with axe
            //GetComponent<AudioSource> ().Play ();
            //Triggers zombie groan sound when taking damage if this enemy is in fact a zombie
            if (gameObject.name == "ZombieWalker" || gameObject.name == "ZombieCrawler")
            {
                AudioSource.PlayClipAtPoint(zombieIsHit.clip, Camera.main.transform.position);
            }
			if (gameObject.name == "Demon")
			{
				//Make demon sounds
			}

            Debug.Log("Health Before : " + Health);
            //Lose one health
            Health--;
            Debug.Log("Health After : " + Health);
            if (Health <= 0)
            {
				if (gameObject.name == "Demon")
				{
					Debug.Log("Should Die.");
					isAlive = false;
					// Next two variables needed to allow the demon to die.
					InPursuit = false;
					PursuitDistance = 0;
					gameObject.animation.Play("Death");
				
				}
				else
				{
					//Destroy the Enemy
                	Destroy(gameObject);
                	playerState.KilledEnemyTreasure(10f);
				}
            }
           

            //Destroy the Bullet this solves an issue with collisions
            Destroy(other.gameObject);
        }
    }
}