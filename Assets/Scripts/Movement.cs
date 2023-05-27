using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player; 
    private bool isMoving = false;
    private Vector3 targetPos;
    public float speed = 2f;


    public void Moving(Vector3 pos)
    {
        if(Vector3.Distance(player.transform.position, pos) <= 2f)
        {
            targetPos = pos;
            isMoving = true;
        }
        else
        {
            Debug.Log("Too far");
        }
    }

    void Update() {
        if(isMoving)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed * Time.deltaTime);
            if(player.transform.position == targetPos)
            {
                isMoving = false;
            }
        }
    }

    public void Move()
    {
        isMoving = false;
    }
}
