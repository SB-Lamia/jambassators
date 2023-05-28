using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodTile : MonoBehaviour
{
    public ResourceManager resourceManager;
    public GameObject player; 
    private IEnumerator coroutine;
    private int successFood = 5;
    private int failFood = 3;
    public List<string> descriptionTexts;

    public GameObject infoBox;
    public List<TextMeshProUGUI> textBoxes;
    public GameObject glowTile;

    private bool empty = false;
    public GameObject resource;

    void Start()
    {
        SetRotation();
        coroutine = DisplayPossibilities();
        player = GameObject.FindWithTag("Player");
        descriptionTexts[0] = "Wild Game";
        descriptionTexts[1] = "Go on a hunt";
        descriptionTexts[2] = $"70% chance: The hunt goes well. You will gain {successFood} food for the tribe";
        descriptionTexts[3] = $"30% chance: The hunt goes poorly. You will gain {failFood} food for the tribe";
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!empty)
        {
        GenerateOutcome();
        }
    }

    void GenerateOutcome()
    {
        int rng = Random.Range(0, 10);
        if(rng <= 3)
        {
            resourceManager.UpdateFood(failFood);
        }
        else
        {
            resourceManager.UpdateFood(successFood);
        }
        resource.SetActive(false);
        empty = true;
    }

    void OnMouseEnter()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) <= 3f)
        {
            glowTile.SetActive(true);
        }
        if(!empty)
        {
            StartCoroutine(coroutine);
        }
    }
    void OnMouseExit()
    {
        glowTile.SetActive(false);
        StopCoroutine(coroutine);
        infoBox.SetActive(false);
    }

    public IEnumerator DisplayPossibilities()
    {
        float duration = 1f;
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
        void SetRotation()
    {
        float rotation = Random.Range(0, 6) * 60;
        this.transform.Rotate(0f, 0f, rotation, Space.Self);
    }

}
