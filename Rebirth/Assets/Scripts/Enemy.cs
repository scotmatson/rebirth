﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        public float Speed;
        public float RotationSpeed;
        public float PursuitDistance;
        public bool InPursuit;

        private GameObject _playerTarget;
        private CharacterController _cont;


        // Use this for initialization
        void Start ()
        {
            _playerTarget = GameObject.FindGameObjectWithTag("Player");
            _cont = GetComponent<CharacterController>();
            Speed = 3;
            RotationSpeed = 3;
            PursuitDistance = 5;
            InPursuit = false;
        }

       
        // Update is called once per frame
        void Update ()
        {
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


        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("Player");
            }
            Debug.Log("Collision");
        }
    }
}
