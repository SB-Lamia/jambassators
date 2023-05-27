using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed = 1f;
    private bool isMoving = false;
    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        startPos = new Vector2(player.transform.position.x, player.transform.position.z);
    }

    public void Moving(Vector3 pos)
    {
        targetPos = pos;
        // isMoving = true;
        //player.transform.position = Vector2.MoveTowards(player.transform.position, pos, playerSpeed * Time.deltaTime);
        player.transform.position = pos;
    }

    public void Move()
    {
        isMoving = false;
    }
}
