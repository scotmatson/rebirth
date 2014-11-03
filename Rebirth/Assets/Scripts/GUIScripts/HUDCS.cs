using UnityEngine;
using System.Collections;

public class HUDCS : MonoBehaviour
{


    private Rect hudWindowRect;

	// Use this for initialization
	void Start () {
	    hudWindowRect = new Rect(10,450,100,75);
	}

    void HeadUpDisplay(int windowId)
    {

        var health = PlayerState.GetHealth();
        var treasure = PlayerState.GetTreasure();

        GUILayout.BeginVertical();
        GUILayout.Label("Score: " + treasure);
        GUILayout.Label("Health: " + health);
        GUILayout.EndVertical();

    }


	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        hudWindowRect = GUI.Window(0, hudWindowRect, HeadUpDisplay, "");
    }
}
