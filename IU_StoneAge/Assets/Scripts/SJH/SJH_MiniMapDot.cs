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
}