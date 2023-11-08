using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SJH_SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Gender")){
            SceneManager.LoadScene("PlayerCustomizing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
