using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0f;
    }
    public void MainMenu()
    {
        Debug.Log("MAINMENO");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
