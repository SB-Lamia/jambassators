using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject menu;
    public GameObject menuBackground;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();
        }
    }

    public void OpenPauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            menu.SetActive(true);
            menuBackground.SetActive(true);
            // Stop time to pause gameplay
            Time.timeScale = 0f;
        }
        else
        {
            menu.SetActive(false);
            menuBackground.SetActive(false);
            // Resume normal time to resume gameplay
            Time.timeScale = 1f;
        }
    }

    public void QuitToTitle()
    {
        // Load the title screen
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
