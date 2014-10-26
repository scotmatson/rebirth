using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	GameObject playerObj;
	PlayerState player;

	void start () {
		playerObj = GameObject.FindWithTag ("Player");
		player = playerObj.GetComponent<PlayerState> ();
	}
	// Update is called once per frame
	void Update () {
		//If the timer hasn't zero'd out and the player is still alive
		//continue to count down.
		if (player.health > 0) {
			guiText.text = "Health: " + player.health;
			player.health -= Time.deltaTime;
		}
	}
}