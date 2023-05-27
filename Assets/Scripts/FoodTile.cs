using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTile : MonoBehaviour
{
    public ResourceManager resourceManager;

    void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        resourceManager.UpdateFood(5);
    }
}
