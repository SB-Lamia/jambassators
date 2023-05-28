using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player; 
    private bool isMoving = false;
    private Vector3 targetPos;
    public float speed = 2f;
    public ResourceManager resourceManager;
    public LavaMovement lavaMovement;

    void Awake(){
        lavaMovement = GameObject.Find("LavaMovement").GetComponent<LavaMovement>();
    }

    public void Moving(Vector3 pos)
    {
        if(Vector3.Distance(player.transform.position, pos) <= 3f && !isMoving)
        {
            targetPos = pos;
            isMoving = true;
            resourceManager.UpdateFood(-1);
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
                lavaMovement.IncreaseLava();
            }
        }
    }

    public void Move()
    {
        isMoving = false;
    }
}
