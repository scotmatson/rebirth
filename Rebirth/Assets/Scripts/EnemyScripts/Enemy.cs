using UnityEngine;


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
            newRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 1);

            //If we want to move with updating pos
            //transform.position += transform.forward * speed * Time.deltaTime;

            //Updating with .Move so that it obeys CharacterController Physics e.g dont go through walls
            var newPosition = transform.forward * Speed;
            _cont.Move(newPosition * Time.deltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>().DealDamage(Damage);
                
                //If Health is left as static
                PlayerState.DealDamage(Damage);
                Destroy(this.gameObject);
            }
        }


    }
