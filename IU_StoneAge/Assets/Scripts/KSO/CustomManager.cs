using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

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
        // �� �ƹ�Ÿ�� Ȱ��ȭ�Ǿ������� �� UI����
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

    public void SaveKey()
    {
        // ���� �� Ŀ���͸���¡ key ��
        string[] keys = new string[9] {
            "Hair", "Skin", "Beard", "Neck", "Torso", "ForeArm", "Hips", "Boot", "Shin_Wrap"
        };
        // Ŀ���͸���¡ ������ �ȵǾ��� �� ����� �⺻ value ��
        string[,] values = new string[9, 2]
        {
            {"Prehistoric_Male_Hair_1A", "Prehistoric_Female_Hair_1A" },
            {"Prehistoric_Male_Avatar_1A", "Prehistoric_Female_Avatar_1D"},
            {"Prehistoric_Male_Beard_1A", null},
            {"Prehistoric_Male_Torso_Necklace_1A", null},
            {"TorseA", "TorsoD"},
            {"ForeArmA1", "ForearmWrapD"},
            {"Prehistoric_Male_Hips_1A", null},
            {"BootA", "BootA"},
            {"ShinWrapA1", "Shin_WrapA"}
        };
        // ���õ� Ŀ���͸���¡ �����Ͱ� ������ �⺻������ ����
        for (int i = 0;  i < keys.Length; i++)
        {
            string key = keys[i];
            if (!PlayerPrefs.HasKey(key))
            {
                if (PlayerPrefs.GetString("Gender") == "Armature_Prehistoric_Male_Avatar")
                {
                    PlayerPrefs.SetString(key, values[i, 0]);
                }
                else
                {
                    if (values[i, 1] != null)
                    {
                        PlayerPrefs.SetString(key, values[i, 1]);
                    }
                }
            }
        }
    }


    public void OnclickSave()
    {
        Debug.Log("save the Avarta.");
        SaveKey();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Map");
    }
}
