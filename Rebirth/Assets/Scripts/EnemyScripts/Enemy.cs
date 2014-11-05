using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float AtackFreq;
    public float Damage; // Damage Enemy does to playe
    public bool InPursuit;
    public float PursuitDistance;
    public float Speed;
    private CharacterController _cont;
    private float _nextAttack;
    private GameObject _playerTarget;
    public bool isAlive;
    public AudioSource zombieIsHit;

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
        PursuitDistance = 15; //Enemies that exist just outside of the width of the viewport will pursue.
        InPursuit = false;

        //Freqeuency in which enemy does damage to the player
        AtackFreq = 2f; //Eveery 2s
        _nextAttack = 0f;
    }

    void Update()
    {
        if (!isAlive) { Destroy(this.gameObject); }
        if (!InPursuit) { InPursuit = ShouldPursuit(); }
        else { PursuitPlayer(); }
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
        newRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 1);

        //Updating with .Move so that it obeys CharacterController Physics e.g dont go through walls
        Vector3 newPosition = transform.forward*Speed;
        newPosition.y = 0f;
        _cont.Move(newPosition*Time.deltaTime);
    }

    //Changed to continuously deal damage and not kill the enemy
    private void OnTriggerStay(Collider other)
    {
     
       // Debug.Log(other.gameObject.name);

            var playerState = GameObject.Find("PlayerSprite").GetComponent<PlayerState>();

            if (other.tag == "Player" || other.gameObject.tag == "Player")
            {
                //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>().DealDamage(Damage);
                
                if (Time.time > _nextAttack)
                {
                    _nextAttack = Time.time + AtackFreq;
                    playerState.DealDamage(Damage);
                }
            }

            //Dont try this at home. For some reason it doesnt like the tag...
            if (other.gameObject.tag == "Bullet" || other.tag == "Bullet" || other.name == "Bullet(Clone)")
            {

               

                //Gives Player Treasure for killing enemy with axe
                //GetComponent<AudioSource> ().Play ();
                playerState.KilledEnemyTreasure(10f);
                //Triggers zombie groan sound when taking damage if this enemy is in fact a zombie
                if (gameObject.name == "ZombieWalker" || gameObject.name == "ZombieCrawler")
                {
                    AudioSource.PlayClipAtPoint(zombieIsHit.clip, Camera.main.transform.position);
                }

                //Destroy the Enemy
                Destroy(gameObject);

                //Destroy the Bullet this solves an issue with collisions
                Destroy(other.gameObject);
            }

          
        
    }
}