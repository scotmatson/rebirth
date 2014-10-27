//This script is for a transparent mesh which has access to all visible game objects 
//as a trigger. It does not effect any region outside of its bounds.

using UnityEngine;
using System.Collections;

public class VisibleArea : MonoBehaviour {

	public static bool killTargets;

	void Start () {
		killTargets = false;
	}
	
	IEnumerator OnTriggerStay(Collider collider) {
		if (collider.tag == "Enemy") {
			GameObject target = collider.gameObject;

			if (killTargets) {
				Enemy enemy = target.GetComponent<Enemy>();
				enemy.isAlive = false;
				yield return new WaitForSeconds(1); //Pause 1 second so all enemies have a chance to die
				killTargets = false;
			}
		}
	}
}