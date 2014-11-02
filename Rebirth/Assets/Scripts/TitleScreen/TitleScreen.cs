using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {


    public GUISkin buttonStyle;
    public GUIStyle headerStyle;
    public int selectedLevel = -1;

	// Use this for initialization
	void Start ()
	{
	  //  buttonStyle = GetComponent<GUISkin>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        int xOffset = (Screen.width - 600) / 2;
        int yOffset = (Screen.height - 400) / 2;

        Rect pos = new Rect(xOffset, yOffset, 600, 50);
      //  GUI.Label(pos, "Rebirth", headerStyle.);

        pos.y += 50;
        pos.height = 350;
        //GUI.Box(pos, "");

        int x;
        int y;
        int levelNumber = 1;

        //Levels
        const float buttonWidth = 250f;
        const float buttonHeight = 100f;

        pos.width = buttonWidth;
        pos.height = buttonHeight;

        pos.x = xOffset + 400;
        pos.y = yOffset + 50;
      
        if (GUI.Button(pos, "Level 1",headerStyle))
        {
            selectedLevel = 1;
        }
        pos.x = xOffset + 400;
        pos.y = yOffset + 175;
        if (GUI.Button(pos, "Level 2",headerStyle))
        {
            selectedLevel = 2;
        }
        pos.x = xOffset + 400;
        pos.y = yOffset + 300;
        
        if (GUI.Button(pos, "Level 3",headerStyle))
        {
            selectedLevel = 3;
        }


        /*for (y = 0; y < 3; y++)
        {
            for (x = 0; x < 4; x++)
            {
                pos.x = xOffset + 125 + x * 100;
                pos.y = yOffset + 50 + 50 + y * 100;
                pos.width = pos.height = 50;

                if (GUI.Button(pos, levelNumber.ToString()))
                {
                    selectedLevel = levelNumber;
                }
                levelNumber++;
            }
        }
        */
        pos.x = xOffset + 0;
        pos.y = yOffset + 400;
        pos.width = 600;
        pos.height = 20;
        GUI.Label(pos, "Selected Level is " + selectedLevel);
    }


}
