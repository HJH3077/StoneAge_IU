using UnityEngine;
using UnityEngine.EventSystems;

public class SJH_MiniMapLoader : MonoBehaviour, IPointerClickHandler
{
	public GameObject miniMap;
	public GameObject setupMenu;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.pointerPress.CompareTag("MapButton"))
		{
			if (miniMap.activeSelf)
			{
				miniMap.SetActive(false);
				setupMenu.SetActive(true);
				Time.timeScale = 1f;

				if (eventData.pointerPress.CompareTag("Exit"))
				{
					Application.Quit();
				}
			}
			else
			{
				miniMap.SetActive(true);
				setupMenu.SetActive(false);
				Time.timeScale = 0.2f;
			}
		}
	}

}
