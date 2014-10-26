using UnityEngine;
using System.Collections;

public class PotionHealth : MonoBehaviour {
	//TODO Add audio
	//TODO Add text, +x value that appears temporarily with fade
	//TODO Consider randomizing health gain or developing algorithm to determine value
	
	public float increase;

	void Start() {
		increase = 50;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player")) {
			PlayerState.health += increase;
			//AudioSource.PlayClipAtPoint(gemSound.clip, Camera.main.transform.position);
			Object.Destroy (this.gameObject);
		}
	}
}
