using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public List<Vector2> positions;
    public GameObject player;
    public float playerSpeed = 1f;
    [HideInInspector]
    public bool isMoving = false;
    private Vector2 mousePos;

    void Start()
    {
        positions = new List<Vector2>();

    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void Move()
    {
        isMoving = false;
    }
}
