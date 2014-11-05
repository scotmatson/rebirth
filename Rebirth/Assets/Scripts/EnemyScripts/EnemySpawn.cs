using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{

    public GameObject SpawnedObject;
    public float Frequency;
    private float _nextSpawn;

	// Use this for initialization
	void Start () {
		Frequency = 3f;
	}
	

    //When the bound box is with in distance
    void OnTriggerStay(Collider col)
    {
        //Destroys Axe if it hits anything other than Player and Enemy
        //The Axe gets destroyed by Enemy in Enemy script for other reasons
        if (col.gameObject.name == "Bounded View")
        {
            if (Time.time > _nextSpawn)
	        {
            //Spawns New Enemy based on Frequency
	        _nextSpawn = Time.time + Frequency;
	        Instantiate(SpawnedObject, transform.position, Quaternion.identity);
	        }
        }

    }

}
