using UnityEngine;
using UnityEngine.EventSystems;

public class SJH_ExitGame : MonoBehaviour, IPointerClickHandler
{
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
		Debug.Log(eventData.pointerPress.tag);
		if (eventData.pointerPress.CompareTag("Exit"))
		{
			Application.Quit();
		}
	}
}
