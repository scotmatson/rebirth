using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
        {
            //Set the States of the next level
			PlayerState.currentLevelHealth = PlayerState.health;
			PlayerState.currentLevelTreaure = PlayerState.treasure;
			//Load the next level
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }

}
