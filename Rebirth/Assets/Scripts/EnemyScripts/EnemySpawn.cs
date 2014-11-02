using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{

    public GameObject SpawnedObject;
    public float Frequency;

    
    private float _nextSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (Time.time > _nextSpawn)
	    {
            //Spawns New Enemy based on Frequency
	        _nextSpawn = Time.time + Frequency;
	        Instantiate(SpawnedObject, transform.position, Quaternion.identity);
	    }
	}
}
