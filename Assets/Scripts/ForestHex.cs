using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestHex : MonoBehaviour
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
            Debug.Log("Bad chop");
            resourceManager.UpdateWood(3);
        }
        else
        {
            Debug.Log("Good chop");
            resourceManager.UpdateWood(5);
        }
    }

}
