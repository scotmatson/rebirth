using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
        {
            // Load the Next Level
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }

}
