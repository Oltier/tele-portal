using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GUISkin skin;

    private Rect pauseMenu = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
    private Rect helpMenu = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400);

    private bool paused = false;
    private bool help = false;
    private bool changeLevel = false;

    public string helpTextTooltip = "In order to edit help text, you have to edit it in the script.";
    private string helpText = "Welcome to TelePortal!\n\nThis is a 3D platformer game, where your goal is to reach the exit with the use of game environments and your portals.\nThe portals' mechanic is simple: Go into the blue, get out of the orange one and reverse.\n\nControls:\n\nW: Forward\nS: Backwards\nA: Left\nD: Right\nSpace: Jump\n\nLeft mouse button: Open Blue portal\nRight mouse button: Open Orange portal\nE:Pick up objects";
    
    // Use this for initialization
	void Start () {
        Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused && !help && !changeLevel)
                paused = false;
            else if (paused && help)
                help = false;
            else if (paused && changeLevel)
                changeLevel = false;
            else
                paused = true;
        }


        if (paused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            GameObject player = GameObject.FindWithTag("Player");
            GameObject gun = GameObject.FindWithTag("Gun");
            GameObject camera = GameObject.FindWithTag("MainCamera");
            gun.transform.GetComponent<Shoot>().enabled = false;
            player.transform.GetComponent<MouseLook>().enabled = false;
            AudioListener.volume = 0;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            GameObject player = GameObject.FindWithTag("Player");
            GameObject gun = GameObject.FindWithTag("Gun");
            GameObject camera = GameObject.FindWithTag("MainCamera");
            gun.transform.GetComponent<Shoot>().enabled = true;
            player.transform.GetComponent<MouseLook>().enabled = true;
            AudioListener.volume = 1;
        }
	}

    private void OnGUI()
    {
        if (paused && !help && !changeLevel)
            GUI.Window(0, pauseMenu, windowFunc, "Pause Menu");
        else if (help)
        {
            GUILayout.Window(1, helpMenu, helpFunc, "Help");
        }
        else if(changeLevel)
        {
            GUI.Window(2, pauseMenu, changeLevelFunc, "Change Level");
        }
    }

    private void windowFunc(int id)
    {
        if (GUILayout.Button("Restart level"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (GUILayout.Button("Help"))
        {
            help = true;
        }

        if (GUILayout.Button("Change level"))
        {
            changeLevel = true;
        }

        if (GUILayout.Button("Quit game"))
        {
            Application.Quit();
        }

        if (GUILayout.Button("Resume"))
        {
            paused = false;
        }

    }
    private void helpFunc(int id)
    {

        GUILayout.TextArea(helpText);
        
        if (GUILayout.Button("Back to Pause Menu"))
        {
            help = false;
        }
    }

    private void changeLevelFunc(int id)
    {
        if (GUILayout.Button("Level 1"))
        {
            Application.LoadLevel(0);
        }

        if (GUILayout.Button("Level 2"))
        {
            Application.LoadLevel(1);
        }

        if (GUILayout.Button("Level 3"))
        {
            Application.LoadLevel(2);
        }

        if (GUILayout.Button("Back to Pause Menu"))
        {
            changeLevel = false;
        }
    }

}
