using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	void start () {

	}
	// Update is called once per frame
	void Update () {
		//If the timer hasn't zero'd out and the player is still alive
		//continue to count down.
		if (PlayerState.health > 0) {
			guiText.text = "Health: " + PlayerState.health.ToString("f0");
			PlayerState.health -= Time.deltaTime * 2;
		}
	}
}