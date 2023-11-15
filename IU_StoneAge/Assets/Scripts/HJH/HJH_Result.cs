using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HJH_Result : MonoBehaviour
{
	public GameObject Success;                 // ���� ���â
	public GameObject Failed;                  // ���� ���â
	//int randomIndex;

	public Sprite[] images; // ����� �������� ������ �迭

	// Start is called before the first frame update
	void Start()
    {
		//Success = GameObject.Find("Success");
		//Failed = GameObject.Find("Failed");

		//randomIndex = Random.Range(0, images.Length);

		Success.SetActive(false);
		Failed.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("��ġ��!!!!!");

			Success.SetActive(false);
			Failed.SetActive(false);
		}
	}

	public void SetResult(bool res, string itemName, Sprite itemImage)
	{
		if (res)
		{
			Image itemImg = Success.transform.Find("Pop/Middle/Item/ItemImage").GetComponent<Image>();
			Text itemTxt = Success.transform.Find("Pop/Bottom/ItemName").GetComponent<Text>();

			Success.SetActive(true);
			Failed.SetActive(false);

			itemImg.sprite = itemImage;
			itemTxt.text = itemName;
		}
		else
		{
			Image itemImg = Failed.transform.Find("Pop/Middle/Item/ItemImage").GetComponent<Image>();
			Text itemTxt = Failed.transform.Find("Pop/Bottom/ItemName").GetComponent<Text>();

			Success.SetActive(false);
			Failed.SetActive(true);

			itemImg.sprite = itemImage;
			//itemImg.sprite = images[randomIndex];
			itemTxt.text = itemName;
		}
	}
}
