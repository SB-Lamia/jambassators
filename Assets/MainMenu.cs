using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Map");
    }
    public void TutorialGame()
    {

    }
    public void EndGame()
    {
        Application.Quit();
    }
}
