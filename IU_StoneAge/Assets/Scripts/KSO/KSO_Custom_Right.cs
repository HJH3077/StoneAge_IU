using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSO_Custom_Right : MonoBehaviour
{
    public GameObject[] gameObjects;
    private int count = 0;
    public void OnClick()
    {
        foreach (var obj in gameObjects)
        {
            obj.gameObject.SetActive(false);
        }
        if (count == gameObjects.Length - 1)
        {
            count = 0 ;
            gameObjects[count].SetActive(true);
        }
        else
        {
            count = count + 1;
            gameObjects[count].SetActive(true);
        }

    }
}
