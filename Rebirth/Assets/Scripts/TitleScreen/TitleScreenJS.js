
//This is based off the exmaple
//Most of the code is from
//Necromancer GUI Demo Script
//Author: Jason Wentzel
//jc_wentzel@ironboundstudios.com


//The level to select
var selectedLevel;

//Done by from Asset COlleciton
private var spikeCount;
var mySkin : GUISkin;
var mainWindowRect = Rect (118, 18, 750, 510);
/*
	This function is from the assets 
*/
function AddSpikes(winX)
{
	spikeCount = Mathf.Floor(winX - 152)/22;
	GUILayout.BeginHorizontal();
	GUILayout.Label ("", "SpikeLeft");//-------------------------------- custom
	for (i = 0; i < spikeCount; i++)
        {
			GUILayout.Label ("", "SpikeMid");//-------------------------------- custom
        }
	GUILayout.Label ("", "SpikeRight");//-------------------------------- custom
	GUILayout.EndHorizontal();
}


function MainMenu (windowID : int) 
{
		//Adds the Spikes
		AddSpikes(mainWindowRect.width);

		GUILayout.BeginVertical();
		GUILayout.Space(8);
		GUILayout.Label("", "Divider");//-------------------------------- custom

		var labelPos = Rect(75,125,600,75); //Hardcoded dont touch
		GUI.Label(labelPos,"Rebirth",mySkin.FindStyle("Label"));
		
		//GUILayout.Label("Short Label", "ShortLabel");//-------------------------------- custom
		GUILayout.Label("", "Divider");//-------------------------------- custom

		//GUILayout.Button("Play Game");
		var playPos = Rect(175,200,400,75);
		
		var play = false;
		
		if (GUI.Button(playPos,"Play Game",mySkin.FindStyle("Button")))
		{
			play = true;
		}
		
		//This stuff is for the Levels
		//Fixed Width and Height and Y Axis so there are 3 level with eachother
		var pos = mainWindowRect;
		pos.y += 300;
		pos.width = 200;
		pos.height = 50;
		
		//Level 1
		pos.x = 60;
		if(GUI.Button(pos,"Level 1", mySkin.FindStyle("Button")))
		{
			selectedLevel = 1;
		}
	
		//Level 2
		pos.x = 280;
		if(GUI.Button(pos,"Level 2", mySkin.FindStyle("Button")))
		{
			selectedLevel = 2;
		}
		
		//Level 3
		pos.x = 500;
		if(GUI.Button(pos,"Level 3", mySkin.FindStyle("Button")))
		{
			selectedLevel =3;
		}
		
		//Start States the game
		if (play) 
		{
			PlayGame(selectedLevel);
		}
		GUILayout.EndVertical();
}

var PlayGame = function (selected) {

	//If No Levl was selected default to 1
	selected = selected || 1;
	Application.LoadLevel(1);
};

function OnGUI ()
{
	GUI.skin = mySkin;
	mainWindowRect = GUI.Window (0, mainWindowRect, MainMenu, "");
}