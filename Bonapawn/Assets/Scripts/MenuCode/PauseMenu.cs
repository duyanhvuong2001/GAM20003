using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        if (GameObject.Find("testAudio"))
        {
            Destroy(GameObject.Find("testAudio"));
            Destroy(GameObject.Find("UI"));
        }
        Debug.Log("Loading Menu....");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    public void LoadSettings()
    {
        Debug.Log("Loading Settings....");

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game....");
        Application.Quit();
    }
}
