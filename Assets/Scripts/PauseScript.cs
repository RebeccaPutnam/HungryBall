using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{
   
    public static bool GameIsPaused = false; //keeps track of if game is paused
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        //Debug.Log("resuming game..");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //Debug.Log("loading menu..");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //Debug.Log("quitting game..");
        Application.Quit();
    }
}
