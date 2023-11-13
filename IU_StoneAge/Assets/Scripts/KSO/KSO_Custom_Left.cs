using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KSO_Custom_Left : MonoBehaviour
{
    public GameObject[] gameObjects;
    private int count = 0;

    private void Start()
    {
        
    }
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
            case "TorsoTxt":
                PlayerPrefs.SetString("Torso", gameObjects[count].name);
                break;
            case "ForeArmTxt":
                PlayerPrefs.SetString("ForeArm", gameObjects[count].name);
                break;
            case "HipsTxt":
                PlayerPrefs.SetString("Hips", gameObjects[count].name);
                break;
            case "BootTxt":
                PlayerPrefs.SetString("Boot", gameObjects[count].name);
                break;
            case "Shin_WrapTxt":
                PlayerPrefs.SetString("Shin_Wrap", gameObjects[count].name);
                break;
            default:
                break;
        }

    }
}
