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

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        resourceManager.UpdateWood(100);
    }
}
