using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectGenderMan : MonoBehaviour
{
    public GameObject Camera;
    public GameObject ManDetail;
    public GameObject WomanDetail;
    public GameObject manAvarta;

    public void OnClickMan()
    {
        Camera.transform.localPosition = new Vector3(2, 1, 2);
        ManDetail.SetActive(true);
        this.gameObject.SetActive(false);
        PlayerPrefs.SetString("Gender", "Armature_Prehistoric_Male_Avatar");
    }

    public void OnClickWoman()
    {
        manAvarta.SetActive(false);
        WomanDetail.SetActive(true);
        this.gameObject.SetActive(false);
        PlayerPrefs.SetString("Gender", "Armature_Prehistoric_Female_Avatar");
    }
}
