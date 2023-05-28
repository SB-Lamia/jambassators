using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Winning : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject endGame;
    public ResourceManager resourceManager;
    public TextMeshProUGUI endGameText;
    public TextMeshProUGUI winText;

    private int saved;
    private int lost;

    void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }

    public void DisplayWins()
    {
        saved = resourceManager.wood / 10;
        lost = resourceManager.civilians - saved;
        endGame.SetActive(true);

        if(lost > 0)
        {
            Debug.Log(saved + lost);
            endGameText.text = $"You have collected enough wood to save {saved} people.<br>"+
            $"You had to leave {lost} people behind. They are swimming in lava now.";

        }
        else
        {
            endGameText.text = "You gathered enough wood to save everyone that made it this far";
        }
        
        //winPanel.SetActive(true);
        //winText.text = "You Win! The village is now safe";
    }

    public void DisplayLose()
    {
        //winPanel.SetActive(true);
        //winText.text = "You Lose! The village is now destroyed";
    }
}
