using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class SJH_MiniMapLoader : MonoBehaviour, IPointerClickHandler
{
    public GameObject miniMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerPress.tag);
        if (eventData.pointerPress.CompareTag("MapButton")){
            miniMap.SetActive(true);
        }
        else if (eventData.pointerPress.CompareTag("MiniMap"))
        {
            miniMap.SetActive(false);
        }
    }

}
