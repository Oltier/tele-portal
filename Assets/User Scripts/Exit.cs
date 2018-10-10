using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
    }

    public void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            restartText.text = "Press 'R' to Restart the game";
            restart = true;
            Cursor.visible = true;
            GameObject player = GameObject.FindWithTag("Player");
            GameObject gun = GameObject.FindWithTag("Gun");
            GameObject camera = GameObject.FindWithTag("MainCamera");
            GameObject.Find("PlayerCamera").GetComponent<Camera>().enabled = false;
            GameObject.Find("Camera").GetComponent<Camera>().enabled = true;
            gun.transform.GetComponent<Shoot>().enabled = false;
            player.transform.GetComponent<MouseLook>().enabled = false;
            GetComponent<AudioSource>().Stop();
        }

        else
        {
            GameObject camera = GameObject.FindWithTag("MainCamera");
            GameObject.Find("PlayerCamera").GetComponent<Camera>().enabled = true;
            if(Application.loadedLevel==Application.levelCount-1)
                GameObject.Find("Camera").GetComponent<Camera>().enabled = false;
        }

        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(0);
            }
        }

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Exit") && Application.loadedLevel == Application.levelCount-1)
        {
            GameOver();
        }
        else if (other.gameObject.CompareTag("Exit"))
            Application.LoadLevel(Application.loadedLevel+1);
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
