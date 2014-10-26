using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public PlayerState playerState;

	void start () {
	}
	// Update is called once per frame
	void Update () {
		//If the timer hasn't zero'd out and the player is still alive
		//continue to count down.
		if (playerState.health > 0) {
			guiText.text = "Health: " + playerState.health;
			playerState.health -= Time.deltaTime;
		}
	}
}