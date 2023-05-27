using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int food;
    public int wood;
    public int civilians;

    public TextMeshProUGUI foodText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI civiliansText;


    void Start()
    {
        foodText.text = food.ToString();
        woodText.text = wood.ToString();
        civiliansText.text = civilians.ToString();
    }

    void Update()
    {
        
    }

    //Takes an amount from a foodtile script and updates foodvalues
    public void UpdateFood(int amount)
    {
        food += amount;
        foodText.text = food.ToString();
    }

    //Takes an amount from a woodtile script and updates woodvalues
    public void UpdateWood(int amount)
    {
        wood += amount;
        woodText.text = wood.ToString();
    }
    //Takes an amount from a civtile script and updates civvalues
    public void UpdateCivilians(int amount)
    {
        civilians += amount;
        civiliansText.text = civilians.ToString();
    }

}
