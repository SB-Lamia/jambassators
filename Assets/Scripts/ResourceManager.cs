using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int food;
    public int wood;
    public int civilians;

    public TextMeshProUGUI foodText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI civiliansText;

    public GameObject endGame;
    public AudioManager audioManager;

    //private IEnumerator DisplayChange;


    void Start()
    {
        foodText.text = food.ToString();
        woodText.text = wood.ToString();
        civiliansText.text = civilians.ToString();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        
    }

    //Takes an amount from a foodtile script and updates foodvalues
    public void UpdateFood(int amount)
    {
        food += amount;
        foodText.text = food.ToString();
        StartCoroutine(DisplayChange(foodText, amount));
        if(food <= 0)
        {
            UpdateCivilians(-1);
        }
    }

    //Takes an amount from a woodtile script and updates woodvalues
    public void UpdateWood(int amount)
    {
        wood += amount;
        woodText.text = wood.ToString();
        StartCoroutine(DisplayChange(woodText, amount));
    }
    //Takes an amount from a civtile script and updates civvalues
    public void UpdateCivilians(int amount)
    {
        civilians += amount;
        civiliansText.text = civilians.ToString();
        StartCoroutine(DisplayDeaths(amount));
        if(civilians == 0)
        {
            audioManager.GetLose();
            endGame.SetActive(true);
        }
    }

    IEnumerator DisplayChange(TextMeshProUGUI targetText, int amount)
    {
        while(true)
        {
            string original = targetText.text;
            string temp = amount.ToString();
            targetText.text = temp + " " + original;

            float duration = 1f;
            float currentTime = 0f;
            while(currentTime < duration)
            {
                float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
                targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, alpha);
                currentTime += Time.deltaTime;
                yield return null;
            }
            targetText.text = original;
            yield break;
        }
    }
        IEnumerator DisplayDeaths(int amount)
    {
        while(true)
        {
            string original = civiliansText.text;
            string temp = amount.ToString();
            civiliansText.text = temp;

            float duration = 1f;
            float currentTime = 0f;
            while(currentTime < duration)
            {
                float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
                civiliansText.color = new Color(civiliansText.color.r, civiliansText.color.g, civiliansText.color.b, alpha);
                currentTime += Time.deltaTime;
                yield return null;
            }
            civiliansText.text = original;
            yield break;
        }
    }
}
