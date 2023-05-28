using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpTile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject IconHelp;
    public bool startGameHelp;

    void Awake()
    {
        IconHelp = GameObject.Find(this.gameObject.name + "IconHelp");
        startGameHelp = true;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && startGameHelp == true)
        {
            IconHelp.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (startGameHelp == false)
        {
            IconHelp.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (startGameHelp == false)
        {
            IconHelp.SetActive(false);
        }
    }

}
