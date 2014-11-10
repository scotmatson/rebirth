using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public  float health;
	public  float treasure;
	public bool isAlive;
	public AudioSource playerGetsHit;


	// Use this for initialization
	void Start () {
		health = 100F;
		treasure = 0F;
		isAlive = true;
		AudioSource[] playerAudio = GetComponents<AudioSource>();
		playerGetsHit = playerAudio [1];
	}
	
	// Update is called once per frame
	void Update () {
	    if (health <= 0)
	    {
	        isAlive = false;
	        GameObject.FindGameObjectWithTag("Player").GetComponent<GamePlayUI>().IsDead = true;
	    }
	}

    // I made this static since Health was static  above.
    public  void DealDamage(float damage)
    {
        Debug.Log("Health before: " + health);
		playerGetsHit.Play ();
        health -= damage;
        Debug.Log("Health after: " + health);
    }


    public  void KilledEnemyTreasure(float treasure)
    {
        this.treasure += treasure;
    }

    public  float GetHealth()
    {
        return health;
    }

    public  float GetTreasure()
    {
        return treasure;
    }

}
