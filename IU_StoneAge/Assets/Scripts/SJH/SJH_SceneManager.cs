using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class SJH_SceneManager : MonoBehaviour
{
    public GameObject malePlayer;
    public GameObject femalePlayer;
    public GameObject player;
    public Avatar maleAvatar;
    public Avatar femaleAvatar;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Gender")){
            SceneManager.LoadScene("PlayerCustomizing");
        }
        else
        {
            // �ҷ��� Ű ��
            string[] keys = new string[9] {
            "Hair", "Skin", "Beard", "Neck", "Torso", "ForeArm", "Hips", "Boot", "Shin_Wrap"
            };

            // ���ڸ�
            if (PlayerPrefs.GetString("Gender") == "Armature_Prehistoric_Male_Avatar")
            {
                // ���� ĳ���� Ȱ��ȭ
                malePlayer.SetActive(true);
                player.GetComponent<Animator>().avatar = maleAvatar;
                // Ŀ���͸���¡ �̸����� Ȱ��ȭ
                foreach (string key in keys)
                {
                    Debug.Log(PlayerPrefs.GetString(key));
                    malePlayer.transform.Find(PlayerPrefs.GetString(key)).gameObject.SetActive(true);
                }
            }
            // ���ڸ�
            else
            {
                // ���� ĳ���� Ȱ��ȭ
                femalePlayer.SetActive(true);
                player.GetComponent<Animator>().avatar = femaleAvatar;

                // Ŀ���͸���¡ �̸����� Ȱ��ȭ
                foreach (string key in keys)
                {
                    Debug.Log(PlayerPrefs.GetString(key));
                    femalePlayer.transform.Find(PlayerPrefs.GetString(key)).gameObject.SetActive(true);
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
