using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    public GameObject LavaPrefab;
    public const int xMovementTile = 1;
    public const float yMoveMentTile = 1.7f;
    public const int StartLine = 0;
    public const int EndLine = 6;
    public bool lavaStarted = true;
    public int lavaRowPosition = 0;
    public int lavaCountDown = 0;

    public void StartLava()
    {
        lavaStarted = true;
        lavaRowPosition = 0;
    }

    public void IncreaseLava()
    {
        lavaStarted = true;
        Debug.Log(lavaCountDown);
        Debug.Log(lavaCountDown % 3);
        if (lavaStarted && lavaCountDown % 3 == 2)
        {
            for (int k = StartLine; k < EndLine; k++)
            {
                Vector3 temptpos = WorldGeneration.Instance.worldTiles[lavaRowPosition, k].transform.position;
                Destroy(WorldGeneration.Instance.worldTiles[lavaRowPosition, k].gameObject);
                Instantiate(LavaPrefab, temptpos, LavaPrefab.transform.rotation);
            }
            lavaRowPosition += 1;
        }
        lavaCountDown++;
    }
}

