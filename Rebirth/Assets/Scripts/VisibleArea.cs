//This script is for a transparent mesh which has access to all visible game objects 
//as a trigger. It does not effect any region outside of its bounds.

using UnityEngine;
using System.Collections;

public class VisibleArea : MonoBehaviour {

	//GameObject[] enemies;
	public static bool kill;

	void Start () {

		//enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		kill = false;
	}
	
	void OnTriggerStay(Collider collider) {
		if (collider.tag == "Enemy") {
			GameObject target = collider.gameObject;

			if (kill) {
				Enemy enemy = target.GetComponent<Enemy>();
				enemy.isAlive = false;
				//kill = false; If uncommented, this will flip back on too fast and only allow 1 enemy to die
			}
		}
	}
}