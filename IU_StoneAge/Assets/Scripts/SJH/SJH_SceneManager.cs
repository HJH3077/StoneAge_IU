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
            // 불러올 키 값
            string[] keys = new string[9] {
            "Hair", "Skin", "Beard", "Neck", "Torso", "ForeArm", "Hips", "Boot", "Shin_Wrap"
            };

            // 남자면
            if (PlayerPrefs.GetString("Gender") == "Armature_Prehistoric_Male_Avatar")
            {
                // 남자 캐릭터 활성화
                malePlayer.SetActive(true);
                player.GetComponent<Animator>().avatar = maleAvatar;
                // 커스터마이징 이름으로 활성화
                foreach (string key in keys)
                {
                    Debug.Log(PlayerPrefs.GetString(key));
                    malePlayer.transform.Find(PlayerPrefs.GetString(key)).gameObject.SetActive(true);
                }
            }
            // 여자면
            else
            {
                // 여자 캐릭터 활성화
                femalePlayer.SetActive(true);
                player.GetComponent<Animator>().avatar = femaleAvatar;

                // 커스터마이징 이름으로 활성화
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
