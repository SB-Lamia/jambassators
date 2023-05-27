using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToWin : MonoBehaviour
{
    private Movement movement;
    private Winning winning;
    private Vector3 newPos;

    void Start()
    {
        movement = GameObject.Find("MovementManager").GetComponent<Movement>();
        winning = GameObject.Find("WinningManager").GetComponent<Winning>();
    }

    private void OnMouseDown() 
    {
        newPos = new Vector3(transform.position.x, 1.5f,  transform.position.z);
        movement.Moving(newPos);
        winning.DisplayWins();
    }
}
