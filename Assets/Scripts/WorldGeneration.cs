using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public static WorldGeneration Instance { get; private set; }

    public List<GameObject> tileObjects;
    //List<int> RandomWorld = new List<int>();
    public int TileNum;
    public const int xMovementTile = 1;
    public const float yMoveMentTile = 1.7f;
    public int oddeven;
    public bool firstObject;
    public bool lastObject;
    public List<GameObject> mountain;
    public bool didGoalSpawn;
    public GameObject[,] worldTiles;

    public GameObject endGoalPrefab;
    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
        worldTiles = new GameObject[21, 8];
        firstObject = true;
        lastObject = false;
        oddeven = 2;
        /*RandomWorld.Add(1);
        RandomWorld.Add(2);*/
        didGoalSpawn = false;
        SetupWorld();
    }

    public void SetupWorld()
    {
        DestroyWorld();
        int startNum = 0;
        int endNum = 0;
        oddeven = 2;
        for (int i = 0; i <= 20; i++)
        {
            float iCoord = i * 1.7f;
            //startNum = RandomWorld[Random.Range(0,2)];
            startNum = Random.Range(0, 2);
            endNum = startNum + 6;
            firstObject = true;
            int endGoal = Random.Range(startNum, endNum);
            for (int k = startNum; k < endNum; k++)
            {
                if(oddeven == 2)
                {
                    if (firstObject == true)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven - 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven - 2 - 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                        firstObject = false;
                    }
                    TileNum = Random.Range(0, tileObjects.Count);
                    if (i == 19 && (k == endGoal-1))
                    {
                        if (startNum == 0)
                        {
                            worldTiles[i, k] = Instantiate(endGoalPrefab, new Vector3(k * oddeven, 0, iCoord), endGoalPrefab.transform.rotation);
                        }
                        {
                            worldTiles[i, k-1] = Instantiate(endGoalPrefab, new Vector3(k * oddeven, 0, iCoord), endGoalPrefab.transform.rotation);
                        }
                        didGoalSpawn = true;
                    }
                    else
                    {
                        Debug.Log(i + " " + k);
                        if(startNum == 0) 
                        {
                            worldTiles[i, k] = Instantiate(tileObjects[TileNum], new Vector3(k * oddeven, 0, iCoord), tileObjects[TileNum].transform.rotation);
                        }
                        else
                        {
                            worldTiles[i, k-1] = Instantiate(tileObjects[TileNum], new Vector3(k * oddeven, 0, iCoord), tileObjects[TileNum].transform.rotation);
                        }
                        
                    }
                    if (k == endNum-1)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven + 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven + 2 + 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                    }
                }
                else
                {
                    if (firstObject == true)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven - 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven - 2 - 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                        firstObject = false;
                    }
                    TileNum = Random.Range(0, tileObjects.Count);

                    if ((i == 19) && (k == endGoal-1))
                    {
                        if (startNum == 0)
                        {
                            worldTiles[i, k] = Instantiate(endGoalPrefab, new Vector3(k * 2 - oddeven, 0, iCoord), endGoalPrefab.transform.rotation);
                        }
                        else
                        {
                            worldTiles[i, k-1] = Instantiate(endGoalPrefab, new Vector3(k * 2 - oddeven, 0, iCoord), endGoalPrefab.transform.rotation);
                        }
                        didGoalSpawn = true;
                    }
                    else{
                        if (startNum == 0)
                        {
                            worldTiles[i, k] = Instantiate(tileObjects[TileNum], new Vector3(k * 2 - oddeven, 0, iCoord), tileObjects[TileNum].transform.rotation);
                        }
                        else
                        {
                            worldTiles[i, k-1] = Instantiate(tileObjects[TileNum], new Vector3(k * 2 - oddeven, 0, iCoord), tileObjects[TileNum].transform.rotation);
                        }
                    }

                    if (k == endNum-1)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven + 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven + 2 + 2, 0, iCoord), mountain[Random.Range(0, 2)].transform.rotation);
                    }
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
        if(didGoalSpawn == false)
        {
            Debug.Log("Didnt load goal");
            SetupWorld();
        }
    }

    private void DestroyWorld()
    {;
        foreach (GameObject worldGenTile in GameObject.FindGameObjectsWithTag("WorldGen"))
        {
            Destroy(worldGenTile);
        }
    }
}
