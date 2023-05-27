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
        resourceManager.UpdateWood(1);
    }
}
