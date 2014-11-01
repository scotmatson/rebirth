using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	GameObject player;
	Transform playerPos;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerPos = player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerPos.transform.position.x, 
		                                  playerPos.transform.position.y,
		                                  transform.position.z);
	}
}
