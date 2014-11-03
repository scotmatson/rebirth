

//Variables
var GamePaused = false;
var mySkin : GUISkin;

//The Postion of the Pause Screen
var pauseWindowRect = Rect (350,10, 350, 510);


//Done by from Asset COlleciton
private var spikeCount;
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

//This Functions Content of the Pause Menu
function PauseMenu (windowID : int) 
{
		//Adds the Spikes
		AddSpikes(pauseWindowRect.width);

		GUILayout.BeginVertical();
		
		GUILayout.Label("Paused");
		
		if (GUILayout.Button("Unpause"))
		{
			GamePaused = false;
			Time.timeScale = 1;
		}
		
		if (GUILayout.Button("Restart Level"))
		{
			//Sets the Scene to Current Level Index
			RestartLevel();
		}
		
		if (GUILayout.Button("Main Menu"))
		{
			//Go to the Main Menu
			MainMenu();
		}

		GUILayout.Space(8);
		GUILayout.EndVertical();
		GUI.DragWindow (Rect (0,0,10000,10000));
		
}

function Start() {
	GamePaused = false;
}

function Update() {

	if (!GamePaused)
	{
		GamePaused = Input.GetKey(KeyCode.Escape);
	}
	
	if (GamePaused) {
		//Stops the Updates
		Time.timeScale = 0;
	}
	
}

var RestartLevel = function () {
	//Reloads Current Scene
	Application.LoadLevel(Application.loadedLevel);
};

var MainMenu = function() {
	
	//Loads the Main Menu Which should be Scene 0
	Application.LoadLevel(0);
};


function OnGUI ()
{
	if (GamePaused) {
		GUI.skin = mySkin;
		pauseWindowRect = GUI.Window (0, pauseWindowRect, PauseMenu, "");
	}
}