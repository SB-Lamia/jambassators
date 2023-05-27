using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerTile : MonoBehaviour
{
    public ResourceManager resourceManager;

    void Start()
    {
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
            Debug.Log("Bad bear");
            resourceManager.UpdateCivilians(-5);
        }
        else
        {
            Debug.Log("Good bear");
            resourceManager.UpdateCivilians(-1);
            resourceManager.UpdateFood(5);
        }
    }
}
