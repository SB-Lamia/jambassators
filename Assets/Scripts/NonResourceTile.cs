using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonResourceTile : MonoBehaviour
{
    public GameObject glowTile;
    public GameObject player; 

    void Start()
    {
        SetRotation();
        player = GameObject.FindWithTag("Player");
    }

    void SetRotation()
    {
        float rotation = Random.Range(0, 6) * 60;
        this.transform.Rotate(0f, 0f, rotation, Space.Self);
    }
        void OnMouseEnter()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) <= 3f)
        {
            glowTile.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        glowTile.SetActive(false);
    }
}
