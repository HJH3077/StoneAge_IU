using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSO_Custom_Right : MonoBehaviour
{
    public GameObject[] gameObjects;

    private int count = 0;

    private void Start()
    {
        switch (gameObject.name)
        {
            case "HairTxt":
                PlayerPrefs.SetString("Hair", gameObjects[count].name);
                break;
            case "SkinTxt":
                PlayerPrefs.SetString("Skin", gameObjects[count].name);
                break;
            case "BeardTxt":
                PlayerPrefs.SetString("Beard", gameObjects[count].name);
                break;
            case "NeckTxt":
                PlayerPrefs.SetString("Neck", gameObjects[count].name);
                break;
            default:
                break;
        }
    }

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
        switch (gameObject.name)
        {
            case "HairTxt":
                PlayerPrefs.SetString("Hair", gameObjects[count].name);
                break;
            case "SkinTxt":
                PlayerPrefs.SetString("Skin", gameObjects[count].name);
                break;
            case "BeardTxt":
                PlayerPrefs.SetString("Beard", gameObjects[count].name);
                break;
            case "NeckTxt":
                PlayerPrefs.SetString("Neck", gameObjects[count].name);
                break;
            default:
                break;
        }

        Debug.Log(gameObject.name);
    }
}
