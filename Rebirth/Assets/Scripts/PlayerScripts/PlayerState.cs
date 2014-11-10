using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public  static float health = 100f;
	public  static float treasure = 0f;
	public bool isAlive;
	public AudioSource playerGetsHit;

	public static float currentLevelHealth = 100f;
	public static float currentLevelTreaure = 0f;

	// Use this for initialization
	void Start () {
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


    public static void KilledEnemyTreasure(float treasure)
    {
        PlayerState.treasure += treasure;
    }

    public static float GetHealth()
    {
        return PlayerState.health;
    }

    public static float GetTreasure()
    {
        return PlayerState.treasure;
    }

}
