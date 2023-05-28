using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHexes : MonoBehaviour
{
    void Start()
    {
        SetRotation();
    }

    void SetRotation()
    {
        float rotation = Random.Range(0, 6) * 60;
        this.transform.Rotate(0f, 0f, rotation, Space.Self);
    }
}
