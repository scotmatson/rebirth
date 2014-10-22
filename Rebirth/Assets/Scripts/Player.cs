using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float PlayerMovementSpeed;

        private Animator _anim;
        private CharacterController _cont;

        // Use this for initialization
        void Start ()
        {
            _anim = GetComponent<Animator>();
            _cont = GetComponent<CharacterController>();
        }
	
        // Update is called once per frame
        void Update () {

            var deltaX = Input.GetAxis( "Horizontal" ) * PlayerMovementSpeed;
            var deltaY = Input.GetAxis( "Vertical" ) * PlayerMovementSpeed;

            var newPosition = new Vector3(deltaX,deltaY,0);

            _cont.Move( newPosition * Time.deltaTime );
        }
    }
}
