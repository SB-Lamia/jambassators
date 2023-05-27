using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInHex : MonoBehaviour
{
    private Movement movement;
    private Vector3 newPos;

    void Start()
    {
        movement = GameObject.Find("MovementManager").GetComponent<Movement>();
    }

    private void OnMouseDown() 
    {
        newPos = new Vector3(transform.position.x, 1.5f,  transform.position.z);
        movement.Moving(newPos);
    }
}
