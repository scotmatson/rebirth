using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class Enemy : MonoBehaviour
    {
        public float Speed;
        public float PursuitDistance;
        public bool InPursuit;
		public bool isAlive;
        public float Damage; // Damage Enemy does to player

        private GameObject _playerTarget;
        private CharacterController _cont;


        // Use this for initialization
        void Start ()
        {
			isAlive = true;
            _playerTarget = GameObject.FindGameObjectWithTag("Player");
            _cont = GetComponent<CharacterController>();
            Speed = 3;
            Damage = 10f;
			//Can we set up separate puruit variables for x and y axis?
            PursuitDistance = 15; //Enemies that exist just outside of the width of the viewport will pursue.
            InPursuit = false;
        }

       
        // Update is called once per frame
        void Update ()
        {
			if (!isAlive) { Destroy (this.gameObject); }
            if (!InPursuit)
            {
                InPursuit = ShouldPursuit();
            }
            else
            {
                PursuitPlayer(); 
            }
        }

        bool ShouldPursuit()
        {
            var distanceToPlayer = Vector3.Distance(_playerTarget.transform.position, this.transform.position);
            return distanceToPlayer <= PursuitDistance;
        }

        // For AI Referenced 
        //http://answers.unity3d.com/questions/603634/having-issues-rotating-2d-sprites-to-face-another.html
        void PursuitPlayer()
        {
            
            var newRotation = Quaternion.LookRotation(_playerTarget.transform.position - transform.position).eulerAngles;
			//for some reason this stil needs to be locked on the z
            newRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 1);

            //Updating with .Move so that it obeys CharacterController Physics e.g dont go through walls
            var newPosition = transform.forward * Speed;
			newPosition.y =  0f;
            _cont.Move(newPosition * Time.deltaTime);
        }

		//Changed to continuously deal damage and not kill the enemy
        void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" || other.gameObject.tag == "Player")
            {
                //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>().DealDamage(Damage);
                
                //If Health is left as static
                PlayerState.DealDamage(Damage);
                Destroy(this.gameObject);
            }

            if (other.gameObject.tag == "Bullet" ||other.tag == "Bullet" || other.name == "Bullet(Clone)")
            {
                //Gives Player Treasure for killing enemy with axe
				//GetComponent<AudioSource> ().Play ();
                PlayerState.KilledEnemyTreasure(10f);
                Destroy(this.gameObject);
            }

        }


    }
