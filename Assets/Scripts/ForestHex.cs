using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForestHex : MonoBehaviour
{
    public ResourceManager resourceManager;
    public AudioManager audioManager;
    public GameObject player; 
    private IEnumerator coroutine;
    private int successWood = 5;
    private int failWood = 3;
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
        descriptionTexts[0] = "Big Trees";
        descriptionTexts[1] = "Chop some wood";
        descriptionTexts[2] = $"50% chance: Your woodsmen are strong. They gather {successWood} usable lumber";
        descriptionTexts[3] = $"50% chance: Your woodsmen are tired from the journey. They gather {failWood} usable lumber";
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
        if(rng <= 5)
        {
            resourceManager.UpdateWood(3);
        }
        else
        {
            resourceManager.UpdateWood(5);
        }
        audioManager.GetWood();
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
