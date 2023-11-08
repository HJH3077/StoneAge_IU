using UnityEngine;

public class SJH_MiniMapDot : MonoBehaviour
{
	public GameObject player;
	// Start is called before the first frame update
	void Start()
	{

	}

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
