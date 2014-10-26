using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public float health = 1000F;
	public bool isAlive;

	// Use this for initialization
	void Start () {
		health = 1000F;
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) { isAlive = false; }
		if (!isAlive) { Destroy (this.gameObject); }
	}
}
