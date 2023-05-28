using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LavaCounter : MonoBehaviour
{
    public int turnsTillLava;
    LavaMovement LavaMovement;
    private void Awake()
    {
        turnsTillLava = 2;
    }

    public void Counter()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = "Lava Will Move Forward\nin " + turnsTillLava + " Movements";
        turnsTillLava--;
        if (turnsTillLava == 0)
        {
            turnsTillLava = 3;
        }
    }
}
