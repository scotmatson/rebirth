using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public static float health;
	public static float treasure;
	public bool isAlive;

	// Use this for initialization
	void Start () {
		health = 1000F;
		treasure = 0F;
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (health <= 0)
	    {
	        isAlive = false;
            Destroy(this.gameObject); 
	    }
	}

    // I made this static since Health was static  above.
    public static void DealDamage(float damage)
    {
        health -= damage;
    }

    public static void KilledEnemyTreasure(float treasure)
    {
        treasure += treasure;
    }
}
