using UnityEngine;
using System.Collections;

public class AddTreasure : MonoBehaviour {

	public float increase;

	// Use this for initialization
	void Start () {
		increase = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Player")) {

			PlayerState.treasure += increase;
			Object.Destroy (this.gameObject);
		}
	}
}
