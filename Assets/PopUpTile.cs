using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpTile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject IconHelp;
    public bool newGameHelp;

    void Awake()
    {
        IconHelp = GameObject.Find(this.gameObject.name + "IconHelp");
        newGameHelp = true;
    }

    void Update()
    {
        if (newGameHelp && Input.GetMouseButton(0))
        {
            IconHelp.SetActive(false);
            newGameHelp = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(newGameHelp == false)
        {
            IconHelp.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (newGameHelp == false)
        {
            IconHelp.SetActive(false);
        }
    }
}
