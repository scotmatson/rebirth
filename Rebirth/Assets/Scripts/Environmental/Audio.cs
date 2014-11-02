using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" || other.gameObject.tag == "Player") 
		{
			GetComponent<AudioSource> ().Play ();
		}

	}
}
