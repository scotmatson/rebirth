using System;
using UnityEngine;


    public class Player : MonoBehaviour {
        public float PlayerMovementSpeed;

        private Animator _anim;
        private CharacterController _cont;
        private Direction _dir;
        private float _scaleX; // This is based on the transformation Scale size set in Unity editor

        // Use this for initialization
        void Start () {
            _anim = GetComponent<Animator>();
            _cont = GetComponent<CharacterController>();
            _scaleX = transform.localScale.x;
        }
	
        // Update is called once per frame
        void Update () {
            var deltaX = Input.GetAxis( "Horizontal" ) * PlayerMovementSpeed;
            var deltaY = Input.GetAxis( "Vertical" ) * PlayerMovementSpeed;

            var scale = transform.localScale;



            var notMoving = (deltaX == 0) && (deltaY == 0);
            _anim.SetFloat("HorizontalSpeed",Math.Abs(deltaX));
            _anim.SetFloat("VerticalSpeed",deltaY);
            _anim.SetBool("NotWalking", notMoving );

            if (deltaX > 0)
            {
                scale.x = 5;
                transform.localScale = scale;
                _dir = Direction.RIGHT;
            }
            else if (deltaX < 0)
            {
                scale.x = -5;
                transform.localScale = scale;
                _dir = Direction.LEFT;
            }
            else if (deltaY > 0)
            {
                _dir = Direction.UP;
            }
            else if (deltaY < 0)
            {
                _dir = Direction.DOWN;
            }



            var newPosition = new Vector3(deltaX,deltaY,0);
            _cont.Move( newPosition * Time.deltaTime );
        }
    }

    public enum Direction { LEFT = 1, RIGHT = 2, UP = 3, DOWN = 4 };