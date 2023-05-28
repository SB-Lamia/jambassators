using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodTile : MonoBehaviour
{
    public ResourceManager resourceManager;
    private int successFood = 5;
    private int failFood = 3;
    public List<string> descriptionTexts;

    public GameObject infoBox;
    public List<TextMeshProUGUI> textBoxes;

    void Start()
    {
        descriptionTexts[0] = "Wild Game";
        descriptionTexts[1] = "Go on a hunt";
        descriptionTexts[2] = $"70% chance: The hunt goes well. You will gain {successFood} food for the tribe";
        descriptionTexts[3] = $"30% chance: The hunt goes poorly. You will gain {failFood} food for the tribe";
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        GenerateOutcome();
    }

    void GenerateOutcome()
    {
        int rng = Random.Range(0, 10);
        if(rng <= 3)
        {
            Debug.Log("Bad hunt");
            resourceManager.UpdateFood(failFood);
        }
        else
        {
            Debug.Log("Good hunt");
            resourceManager.UpdateFood(successFood);
        }
    }

    IEnumerator coroutine;

    void OnMouseEnter()
    {
        Debug.Log("Mouse");
        coroutine = DisplayPossibilities();
        StartCoroutine(coroutine);
    }
    void OnMouseExit()
    {
        Debug.Log("out");
        StopCoroutine(coroutine);
        infoBox.SetActive(false);
    }

    public IEnumerator DisplayPossibilities()
    {
        float duration = 2f;
        float currentTime = 0f;
        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        int count = 0;
        infoBox.SetActive(true);
        foreach(TextMeshProUGUI textBox in textBoxes)
        {
            textBox.text = descriptionTexts[count];
            count++;
        }
        yield break;
    }
}
