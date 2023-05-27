using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public List<GameObject> tileObjects;
    public int TileNum;
    public const int xMovementTile = 1;
    public const float yMoveMentTile = 1.7f;
    public int oddeven;
    public bool firstObject;
    public bool lastObject;

    private void Awake()
    {
        firstObject = true;
        lastObject = false;
        oddeven = 2;
        SetupWorld();
    }

    public void SetupWorld()
    {
        for (float i = 1.7f; i < yMoveMentTile * 100; i = i + yMoveMentTile)
        {
            for (int k = -3; k < 3; k++)
            {
                if(oddeven == 2)
                {
                    TileNum = Random.Range(0, 4);
                    Instantiate(tileObjects[TileNum], new Vector3(k * oddeven, 0, i), tileObjects[TileNum].transform.rotation);
                }
                else
                {
                    TileNum = Random.Range(0, 4);
                    Instantiate(tileObjects[TileNum], new Vector3(k * 2-oddeven, 0, i), tileObjects[TileNum].transform.rotation);
                }
            }
            if (oddeven == 2)
            {
                oddeven = 1;
            }
            else if (oddeven == 1)
            {
                oddeven = 2;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
