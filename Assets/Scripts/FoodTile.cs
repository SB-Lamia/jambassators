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

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        resourceManager.UpdateFood(100);
    }
}
