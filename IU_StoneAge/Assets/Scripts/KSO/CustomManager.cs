using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    public GameObject WomanHead;
    public GameObject WomanBody;
    public GameObject ManHead;
    public GameObject ManBody;
    public GameObject man;


    public void OnClickHead()
    {
        if (man.activeSelf)
        {
            ManHead.SetActive(true);
            transform.Find("HeadOrBody").gameObject.SetActive(false);
        }
        else
        {
            WomanHead.SetActive(true);
            transform.Find("HeadOrBody").gameObject.SetActive(false);
        }
        Debug.Log("ClickHead");
    }

    public void OnclickBody()
    {
        if (man.activeSelf)
        {
            ManBody.SetActive(true);
            transform.Find("HeadOrBody").gameObject.SetActive(false);
        }
        else
        {
            WomanBody.SetActive(true);
            transform.Find("HeadOrBody").gameObject.SetActive(false);
        }
        Debug.Log("ClickBody");

    }

    public void OnClickBackToAvarta()
    {
        // 남 아바타가 활성화되어있으면 남 UI끄기
        if(man.activeSelf)
        {
            ManBody.SetActive(false);
            ManHead.SetActive(false);
            transform.Find("HeadOrBody").gameObject.SetActive(true);
        }
        else
        {
            WomanBody.SetActive(false);
            WomanHead.SetActive(false);
            transform.Find("HeadOrBody").gameObject.SetActive(true);
        }
    }

    public void OnclickSave()
    {
        Debug.Log("save the Avarta.");
        SaveNSceneload.SaveCustumizing();
    }
}
