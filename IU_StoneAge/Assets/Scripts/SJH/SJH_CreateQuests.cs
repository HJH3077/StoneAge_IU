using UnityEngine;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class SJH_CreateQuests : MonoBehaviour
{
	public GameObject player;
	public GameObject mark;
	public GameObject npc;
	public GameObject speakBtn;
	public GameObject questUi;
	public Text questScripts;
	public Text submit;

	private bool look = false;
    private void Start()
    {
        PlayerPrefs.SetInt("ScriptNum", 0);
        if (!PlayerPrefs.HasKey("QuestNum"))
		{
			submit.text = "Submit";
			questScripts.text = QuestManager.SetscriptingNPC() + ": " + QuestManager.SetQuestScript(false);
			questUi.SetActive(true);
		}
		else if (PlayerPrefs.GetInt("QuestNum") == 0)
		{
            submit.text = "Submit";
            questScripts.text = QuestManager.SetscriptingNPC() + ": " + QuestManager.SetQuestScript(false);
            questUi.SetActive(true);
        }

    }

    void Update()
	{
		if (look)
		{
			npc.transform.LookAt(player.transform);
		}
	}

	public void QuestUiOn()
	{
        PlayerPrefs.SetInt("ScriptNum", 0);
        if (PlayerPrefs.HasKey("QuestClear"))
		{
			if (PlayerPrefs.GetInt("QuestClear") == 0)
			{
				QuestStart();
			}
			else
			{
				QuestClear();
			}
		}
	}

	public void QuestStart()
	{
        questScripts.text = QuestManager.SetscriptingNPC() + ": "+ QuestManager.SetQuestScript(false);
        questUi.SetActive(true);
	}

	public void QuestClear()
	{
		questScripts.text = QuestManager.SetfinishNPC() + ": " + QuestManager.SetfinishScript(false);
		questUi.SetActive(true);
	}

	public void QuestOff()
	{
		questUi.SetActive(false);
        submit.text = "Next";
    }

    public void NextScript()
	{
		Debug.Log(submit.text);
		if (submit.text == "Submit")
		{
			QuestOff();
			int gameNum = QuestManager.SetGame();

            if (gameNum >= 0)
			{
				if (gameNum == 0)
				{
					SceneManager.LoadScene("QTE");
				}
                else if (gameNum == 1)
                {
                    SceneManager.LoadScene("QTE");
                }
                else if (gameNum == 2)
                {
                    SceneManager.LoadScene("Fishing");
                }
            }
			else if (PlayerPrefs.GetInt("QuestNum") != 0)
			{
				PlayerPrefs.SetInt("QuestClear", 1);
			}
			Debug.Log(PlayerPrefs.GetInt("QuestClear"));

			if (PlayerPrefs.GetInt("QuestClear") == 1)
			{
				PlayerPrefs.SetInt("QuestNum", PlayerPrefs.GetInt("QuestNum") + 1);
				PlayerPrefs.SetInt("QuestClear", 0);
			}
		}

		else if (PlayerPrefs.GetInt("QuestClear") == 0)
		{
			if (QuestManager.SetQuestScript(true) != null)
            {
                PlayerPrefs.SetInt("ScriptNum", PlayerPrefs.GetInt("ScriptNum") + 1);
                questScripts.text = QuestManager.SetscriptingNPC() + ": " + QuestManager.SetQuestScript(false);
            }
			else
			{
                submit.text = "Submit";
            }
        }
		
        else if (PlayerPrefs.GetInt("QuestClear") == 1)
		{
            if (QuestManager.SetfinishScript(true) != null)
            {
                PlayerPrefs.SetInt("FinishScriptNum", PlayerPrefs.GetInt("FinishScriptNum") + 1);
                questScripts.text = QuestManager.SetfinishNPC() + ": " + QuestManager.SetfinishScript(false);
            }
			else
			{
                submit.text = "Submit";
            }
        } 
		// PlayerPrefs.Save();
    }

	private void OnTriggerStay(Collider other)
	{
		Debug.Log(other.gameObject);
		Debug.Log(PlayerPrefs.GetInt("QuestClear"));
		Debug.Log(QuestManager.SetQuestNPC());
		Debug.Log(QuestManager.SetfinishNPC());
		Debug.Log(npc.gameObject.name);

        if (other.gameObject == player)
		{
			if (PlayerPrefs.GetInt("QuestClear") == 0 && QuestManager.SetQuestNPC() == npc.gameObject.name)
			{
				mark.SetActive(true);
				speakBtn.SetActive(true);
			}
			else if (PlayerPrefs.GetInt("QuestClear") == 1 && QuestManager.SetfinishNPC() == npc.gameObject.name){

                mark.SetActive(true);
                speakBtn.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("QuestNum") == 0 && npc.gameObject.name == "GrandFather")
            {
                PlayerPrefs.SetInt("QuestClear", 1);
                mark.SetActive(true);
                speakBtn.SetActive(true);
            }
            look = true;
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
	public void StartGame()
	{

	}
}
