using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KSO_Custom_Left : MonoBehaviour
{
    public GameObject[] gameObjects;
    private int count = 0;
    public void OnClick()
    {
        foreach (var obj in gameObjects)
        {
            obj.gameObject.SetActive(false);
        }
        if (count == 0)
        {
            count = gameObjects.Length - 1;
            gameObjects[count].SetActive(true);
        }
        else
        {
            count = count - 1;
            gameObjects[count].SetActive(true);
        }
    }
}
