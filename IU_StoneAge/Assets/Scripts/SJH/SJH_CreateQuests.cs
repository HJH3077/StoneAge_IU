using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SJH_CreateQuests : MonoBehaviour
{
    public GameObject player;
    public GameObject mark;
    public GameObject npc;
    public GameObject speakBtn;
    public GameObject questUi;

    private bool look = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (look)
        {
            npc.transform.LookAt(player.transform);
        }
    }

    public void QuestOn()
    {
        questUi.SetActive(true);
    }

    public void QuestOff()
    {
        questUi.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject == player)
        {
            mark.SetActive(true);
            look = true;
            speakBtn.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            mark.SetActive(false);
            look = false;
            speakBtn.SetActive(false);
            questUi.SetActive(false);
        }
    }
}
