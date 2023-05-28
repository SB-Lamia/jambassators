using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DangerTile : MonoBehaviour
{
    public ResourceManager resourceManager;
    public AudioManager audioManager;
    public GameObject player; 
    private IEnumerator coroutine;
    private int successFood = 5;
    private int successCivilians = -1;
    private int failCivilians = -3;
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
        descriptionTexts[0] = "BEAR";
        descriptionTexts[1] = "Fight the bear";
        descriptionTexts[2] = $"30% chance: The fight goes well. You will gain {successFood} food, but you will lose {successCivilians} people";
        descriptionTexts[3] = $"70% chance: The fight goes poorly. You will lose {failCivilians} people";
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
        if(rng <= 7)
        {
            resourceManager.UpdateCivilians(failCivilians);
        }
        else
        {
            resourceManager.UpdateCivilians(successCivilians);
            resourceManager.UpdateFood(successFood);
        }
        audioManager.GetWound();
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
