using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public List<GameObject> tileObjects;
    List<int> RandomWorld = new List<int>();
    public int TileNum;
    public const int xMovementTile = 1;
    public const float yMoveMentTile = 1.7f;
    public int oddeven;
    public bool firstObject;
    public bool lastObject;
    public List<GameObject> mountain;
    public bool didGoalSpawn;

    public GameObject endGoalPrefab;
    
    private void Awake()
    {
        firstObject = true;
        lastObject = false;
        oddeven = 2;
        RandomWorld.Add(-2);
        RandomWorld.Add(-3);
        didGoalSpawn = false;
        SetupWorld();
    }

    public void SetupWorld()
    {
        DestroyWorld();
        int startNum = 0;
        int endNum = 0;
        for (float i = 1.7f; i <= yMoveMentTile * 20; i = i + yMoveMentTile)
        {
            startNum = RandomWorld[Random.Range(0,2)];
            endNum = RandomWorld[Random.Range(0,2)] * -1;
            firstObject = true;
            int endGoal = Random.Range(startNum, endNum);
            for (int k = startNum; k < endNum; k++)
            {
                if(oddeven == 2)
                {
                    if (firstObject == true)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven - 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven - 2 - 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
                        firstObject = false;
                    }
                    TileNum = Random.Range(0, tileObjects.Count);
                    if ((i >= yMoveMentTile * 19) && (k == endGoal-1))
                    {
                        Instantiate(endGoalPrefab, new Vector3(k * oddeven, 0, i), endGoalPrefab.transform.rotation);
                        didGoalSpawn = true;
                    }
                    else{
                        Instantiate(tileObjects[TileNum], new Vector3(k * oddeven, 0, i), tileObjects[TileNum].transform.rotation);
                    }
                    if (k == endNum-1)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven + 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * oddeven + 2 + 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
                    }
                }
                else
                {
                    if (firstObject == true)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven - 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven - 2 - 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
                        firstObject = false;
                    }
                    TileNum = Random.Range(0, tileObjects.Count);

                    if ((i >= yMoveMentTile * 19) && (k == endGoal-1))
                    {
                        Instantiate(endGoalPrefab, new Vector3(k * 2-oddeven, 0, i), endGoalPrefab.transform.rotation);
                        didGoalSpawn = true;
                    }
                    else{
                        Instantiate(tileObjects[TileNum], new Vector3(k * 2-oddeven, 0, i), tileObjects[TileNum].transform.rotation);
                    }

                    if (k == endNum-1)
                    {
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven + 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
                        Instantiate(mountain[Random.Range(0, 2)], new Vector3(k * 2 - oddeven + 2 + 2, 0, i), mountain[Random.Range(0, 2)].transform.rotation);
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
