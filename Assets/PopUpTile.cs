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
        Time.timeScale = 0f;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && startGameHelp == true)
        {
            IconHelp.SetActive(false);
            startGameHelp = false;
            Time.timeScale = 1.0f;
            LavaMovement lavaMovement = GameObject.Find("LavaMovement").GetComponent<LavaMovement>();
            lavaMovement.StartLava();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (startGameHelp == false)
        {
            IconHelp.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (startGameHelp == false)
        {
            IconHelp.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

}
