using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static int SetQuestKey()
    {
        int questNum;

        if (PlayerPrefs.HasKey("QuestNum"))
        {
            questNum = PlayerPrefs.GetInt("QuestNum");
        }
        else
        {
            PlayerPrefs.SetInt("QuestNum", 0);
            questNum = PlayerPrefs.GetInt("QuestNum");
        }

        return questNum;
    }

    public static int SetScriptKey()
    {
        int scriptNum;

        if (PlayerPrefs.HasKey("ScriptNum"))
        {
            scriptNum = PlayerPrefs.GetInt("ScriptNum");
        }
        else
        {
            PlayerPrefs.SetInt("ScriptNum", 0);
            scriptNum = PlayerPrefs.GetInt("ScriptNum");
        }

        return scriptNum;
    }

    public static int SetFinishScriptKey()
    {
        int finishScriptNum;

        if (PlayerPrefs.HasKey("FinishScriptNum"))
        {
            finishScriptNum = PlayerPrefs.GetInt("FinishScriptNum");
        }
        else
        {
            PlayerPrefs.SetInt("FinishScriptNum", 0);
            finishScriptNum = PlayerPrefs.GetInt("FinishScriptNum");
        }

        return finishScriptNum;
    }

    public static string SetQuestNPC()
    {
        return QuestData.questNPCs[SetQuestKey()];
    }

    public static string SetQuestScript(bool next)
    {
        int questNum = SetQuestKey();
        int scriptNum = SetScriptKey();

        if (next)
        {
            return QuestData.questScripts[questNum, scriptNum+1];
        }
        else
        {
            return QuestData.questScripts[questNum, scriptNum];
        }

    }

    public static string SetscriptingNPC()
    {
        int questNum = SetQuestKey();
        int scriptNum = SetScriptKey();

        return QuestData.scriptingNPCs[questNum, scriptNum];
    }

    public static string SetfinishScript(bool next)
    {
        int questNum = SetQuestKey();
        int finishScriptNum = SetFinishScriptKey();

        if (next)
        {
            return QuestData.finishScripts[questNum, finishScriptNum+1];
        }
        else
        {
            return QuestData.finishScripts[questNum, finishScriptNum];
        }
    }

    public static string SetfinishNPC()
    {
        int questNum = SetQuestKey();
        int finishScriptNum = SetFinishScriptKey();

        return QuestData.finishNPCs[questNum, finishScriptNum];
    }

    public static int SetGame()
    {
        int questNum = SetQuestKey();
        return QuestData.game[questNum];
    }
}
