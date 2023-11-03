using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    public GameObject Camera;
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
        // �� �ƹ�Ÿ�� Ȱ��ȭ�Ǿ������� �� UI����
        if(man.activeSelf)
        {
            Camera.transform.localPosition = new Vector3(2, 1, 2);
            ManBody.SetActive(false);
            ManHead.SetActive(false);
            transform.Find("HeadOrBody").gameObject.SetActive(true);
        }
        else
        {
            Camera.transform.localPosition = new Vector3(0, 1, 2);
            WomanBody.SetActive(false);
            WomanHead.SetActive(false);
            transform.Find("HeadOrBody").gameObject.SetActive(true);
        }
    }

    public void OnclickSave()
    {
        Debug.Log("save the Avarta.");
    }
}
