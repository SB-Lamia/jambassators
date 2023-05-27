using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Winning : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI winText;

    public void DisplayWins()
    {
        winPanel.SetActive(true);
        winText.text = "You Win! The village is now safe";
    }

    public void DisplayLose()
    {
        winPanel.SetActive(true);
        winText.text = "You Lose! The village is now destroyed";
    }
}
