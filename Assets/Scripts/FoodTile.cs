using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTile : MonoBehaviour
{
    public ResourceManager resourceManager;
    public string name;

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
            Debug.Log("Bad hunt");
            resourceManager.UpdateFood(3);
        }
        else
        {
            Debug.Log("Good hunt");
            resourceManager.UpdateFood(5);
        }
    }
}
