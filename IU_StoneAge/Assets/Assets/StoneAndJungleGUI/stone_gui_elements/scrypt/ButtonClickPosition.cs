using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickPosition : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	[SerializeField] private Vector3 positionChange = new Vector3(0, -10, 0);
	public void OnPointerDown(PointerEventData eventData)
	{
		foreach (Transform child in transform)
		{
			child.localPosition = child.localPosition + positionChange;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{

		foreach (Transform child in transform)
		{
			child.localPosition = child.localPosition - positionChange;
		}
	}
}
