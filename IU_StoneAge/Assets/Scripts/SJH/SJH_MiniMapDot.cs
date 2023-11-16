using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class SJH_MiniMapDot : MonoBehaviour
{
	public GameObject player;
	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector3(player.transform.position.x, 30f, player.transform.position.z);
		if (player.tag.Equals("Player"))
		{
			transform.rotation = player.transform.rotation;
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}

	public void dotUpdate()
	{
		if (PlayerPrefs.GetInt("QuestClear") == 0 && QuestManager.SetQuestNPC() == player.name)
		{
			SJH_MiniMapDot[] dots = player.GetComponentsInChildren<SJH_MiniMapDot>();
			foreach (var item in dots)
			{
				if (item.name == "NPC_dot_usable")
				{
					item.gameObject.SetActive(true);
				}
				else
				{
					item.gameObject.SetActive(false);
				}
			}
		}
		else if (PlayerPrefs.GetInt("QuestClear") == 1 && QuestManager.SetQuestNPC() == player.name)
		{

		}
    }
}
