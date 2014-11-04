

//Variables
var GamePaused = false;
var mySkin : GUISkin;
var gameMusic : GameObject;
var ravenCaw : GameObject;
var playerAxe : GameObject;

//The Rectangle Representing where the menu is 
var pauseWindowRect : Rect;



//Done by from Asset Colleciton
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
			UnPause();
			gameMusic.audio.Play();
			ravenCaw.audio.Play();
			playerAxe.audio.Play();
		}
		
		if (GUILayout.Button("Restart Level"))
		{
			UnPause();
			//Sets the Scene to Current Level Index
			RestartLevel();
		}
		
		if (GUILayout.Button("Main Menu"))
		{
			UnPause();
			//Go to the Main Menu
			MainMenu();
		}

		GUILayout.Space(8);
		GUILayout.EndVertical();
		GUI.DragWindow (Rect (0,0,10000,10000));
		
}

function Start() {
	GamePaused = false;
	gameMusic = GameObject.Find("Main Camera");
	ravenCaw = GameObject.Find("Raven");
	playerAxe = GameObject.Find("PlayerSprite");
	
	
	//Draw the rectangle
	var width = 350;
	var height = 500;
	
	var x = (Screen.width / 2 ) - (width / 2);
	var y = (Screen.height / 2 ) - (height / 2);
	pauseWindowRect = Rect (x,y, width, height);
	
}

function Update() {

	if (!GamePaused)
	{
		GamePaused = Input.GetKey(KeyCode.Escape);
	}
	
	if (GamePaused) {
		//Stops the Updates
		gameMusic.audio.Pause();

		ravenCaw.audio.Pause();
		playerAxe.audio.Pause();

		PauseGame();
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

var PauseGame = function() {

	//Sets Time Scale preventing Update Frame from being caleld making it seem like its paused
	Time.timeScale = 0;	
	//Toggle IsPaused On Player
	GameObject.FindGameObjectWithTag("Player").GetComponent("Player").IsPaused = true;
};

var UnPause = function() {
	GamePaused = false;
	Time.timeScale = 1;
	
	//Toggle ISPause on Player
	GameObject.FindGameObjectWithTag("Player").GetComponent("Player").IsPaused = false;
};

function OnGUI ()
{
	if (GamePaused) {
		GUI.skin = mySkin;
		pauseWindowRect = GUI.Window (0, pauseWindowRect, PauseMenu, "");
	}
}