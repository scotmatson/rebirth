using UnityEngine;
using System.Collections;

public class TriggerDeath : MonoBehaviour {
	//TODO Destroy all enemies within view. 
	//Two ways to go about this.
	//  1) Actually find viewport range and target all enemies within area.
	//  2) Create a GameObject with xWidth x yHeight that follows player or rather is a child of the 
	//     potion and on potion trigger find all tag="enemy" and destroy it.


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player")) {
			VisibleArea.killTargets = true;
			Destroy (this.gameObject);
		}
	}
}
