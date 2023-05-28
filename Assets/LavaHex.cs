using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaHex : MonoBehaviour
{
    public ResourceManager resourceManager;
    public AudioManager audioManager;
    public GameObject player; 
    public int lavaDamage = -10;


    void Start()
    {
        SetRotation();
        player = GameObject.FindWithTag("Player");
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        DealDamage();
    }

    void DealDamage()
    {
        resourceManager.UpdateCivilians(lavaDamage);
    }
    
    void SetRotation()
    {
        float rotation = Random.Range(0, 6) * 60;
        this.transform.Rotate(0f, 0f, rotation, Space.Self);
    }
}
