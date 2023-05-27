using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpTile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject IconHelp;

    void Awake()
    {
        IconHelp = GameObject.Find(this.gameObject.name + "IconHelp");
        IconHelp.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IconHelp.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IconHelp.SetActive(false);
    }

}
