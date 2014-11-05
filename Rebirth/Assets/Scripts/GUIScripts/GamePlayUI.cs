using UnityEngine;
using System.Collections;

public class GamePlayUI : MonoBehaviour {

    public bool GamePaused;
    public bool IsDead;

    public GUISkin guiSkin;

    private Rect _pauseMenuRect;
    private Rect _gameOverRect;
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
        _ravenCaw.audio.Pause();
        _playerAxe.audio.Pause();

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().IsPaused = true;
    }

    private void UnPause()
    {
        GamePaused = false;
        Time.timeScale = 1;

        _gameMusic.audio.Play();
        _ravenCaw.audio.Play();
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

        _gameMusic = GameObject.Find("Main Camera");
        _ravenCaw = GameObject.Find("Raven");
        _playerAxe = GameObject.Find("PlayerSprite");


	    _width = 350;
	    _height = 500;

        var x = (Screen.width / 2) - (_width / 2);
	    var y = (Screen.height/2) - (_height/2);
        _pauseMenuRect = new Rect(x,y,_width,_height);
        _gameOverRect = new Rect(x,y,_width,_height);

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
            PauseGame();
            _gameOverRect = GUI.Window(0, _gameOverRect, GameOverMenu, "");
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

        var playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();

        //Resets Basic Player State
        playerState.health = 100;
        playerState.treasure = 0;
        IsDead = false;
    }

}
