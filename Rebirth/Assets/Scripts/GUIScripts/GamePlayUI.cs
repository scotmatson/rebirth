using UnityEngine;
using System.Collections;

public class GamePlayUI : MonoBehaviour {

    public bool GamePaused;
    public bool IsDead;
    public bool WonGame;

    public GUIStyle hudStyle;

    public GUISkin guiSkin;

    private Rect _pauseMenuRect;
    private Rect _gameOverRect;
    private Rect _winScreenRect;

    public Rect _hudDisplay;
    
    
    private GameObject _gameMusic;
    private GameObject _ravenCaw;
    private GameObject _playerAxe;

    private float _width;
    private float _height;


    /*
     * Method sets up Stuff in Pause Menu
     * */
    void PauseMenu(int windowID)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("Paused");

        if (GUILayout.Button("Unpause"))
        {
            UnPause();
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
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
		
    }

    private void PauseGame()
    {
        Time.timeScale = 0;

        //Audio
        _gameMusic.audio.Pause();
        if (_ravenCaw != null)
        {
            _ravenCaw.audio.Pause();
        }
        _playerAxe.audio.Pause();

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().IsPaused = true;
    }

    private void UnPause()
    {
        GamePaused = false;
        Time.timeScale = 1;

        _gameMusic.audio.Play();
        if (_ravenCaw != null)
        {
            _ravenCaw.audio.Play(); 
        }
        
        _playerAxe.audio.Play();

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().IsPaused = false;
    }

    private void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    private void MainMenu()
    {
        Application.LoadLevel(0);
    }

	// Use this for initialization
	void Start ()
	{

	    GamePaused = false;
	    IsDead = false;
	    WonGame = false;

        _gameMusic = GameObject.Find("Main Camera");
        _ravenCaw = GameObject.Find("Raven");
        _playerAxe = GameObject.Find("PlayerSprite");


	    _width = 350;
	    _height = 500;

        var x = (Screen.width / 2) - (_width / 2);
	    var y = (Screen.height/2) - (_height/2);
        _pauseMenuRect = new Rect(x,y,_width,_height);
        _gameOverRect = new Rect(x,y,_width,_height);
        _winScreenRect = new Rect(x,y,_width,_height);


	    var hud_x = 10F;
        var hud_y = 10F;
	    var hudHeight = 40F;
	    var hudWidth = 300f;

        _hudDisplay = new Rect(hud_x, hud_y , hudWidth,hudHeight);
	}
	
	// Update is called once per frame
	void Update () {

        if (!GamePaused)
        {
            GamePaused = Input.GetKey(KeyCode.Escape);
        }

        if (GamePaused)
        {
            PauseGame();
        }
	}

    void OnGUI()
    {
        GUI.skin = guiSkin;
        if (GamePaused)
        {
            _pauseMenuRect = GUI.Window(0, _pauseMenuRect, PauseMenu, "");
        }
        if (IsDead)
        {
			PauseGame ();
            _gameOverRect = GUI.Window(1, _gameOverRect, GameOverMenu, "");

        }

        if (WonGame)
        {
            PauseGame();
            _winScreenRect = GUI.Window(4, _gameOverRect, WonGameMenu, "");
        }

        if (!GamePaused && !IsDead)
        {
            //Use the default Skin for this
            //GUI.skin = null;

            RenderHUD();
        }

    }


    ///Game Over Stuff

    void GameOverMenu(int windoID)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("Game Over");


        if (GUILayout.Button("Restart Level"))
        {
            ResetConfig();
            UnPause();

            RestartLevel();
        }

        if (GUILayout.Button("Main Menu"))
        {
            ResetConfig();
            UnPause();

            MainMenu();
        }

        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
        }

        GUILayout.Space(8);
        GUILayout.EndVertical();
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    private void ResetConfig()
    {
        //Resets Basic Player State
        PlayerState.health = 100;
        PlayerState.treasure = 0;
        IsDead = false;
    }

    // HUD stuff

    void RenderHUD()
    {


        var health = PlayerState.GetHealth();
        var score = PlayerState.GetTreasure();

        GUI.Box(_hudDisplay,"");

        var healthRect = _hudDisplay;
        healthRect.x += 10;
        healthRect.width = _hudDisplay.width/2;
        GUI.Label(healthRect,"Health: " + health);

        var scoreRect = _hudDisplay;
        scoreRect.x += (_hudDisplay.width / 2);
        scoreRect.width = _hudDisplay.width/2;
        GUI.Label(scoreRect,"Score: " + score);
    }

    //Won Game Stuff
    void WonGameMenu(int windowId)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("You Win!");

        if (GUILayout.Button("Main Menu"))
        {
            ResetConfig();
            UnPause();

            MainMenu();
        }

        if (GUILayout.Button("Exit"))
        {
            Application.Quit();
        }

        GUILayout.Space(8);
        GUILayout.EndVertical();
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }


}
