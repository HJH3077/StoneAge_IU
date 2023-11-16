using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HJH_Result : MonoBehaviour
{
	public GameObject Success;                 // 성공 결과창
	public GameObject Failed;                  // 실패 결과창

	public GameObject inventoryUI;


	// Start is called before the first frame update
	void Start()
    {
		Success.SetActive(false);
		Failed.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("터치함!!!!!");

			Success.SetActive(false);
			Failed.SetActive(false);
		}
	}

	public void SetResult(string itemName, Sprite itemImage, bool res)
	{
		HJH_Inventory inventory = inventoryUI.GetComponent<HJH_Inventory>();

		if (res)
		{
			Image itemImg = Success.transform.Find("Pop/Middle/Item/ItemImage").GetComponent<Image>();
			Text itemTxt = Success.transform.Find("Pop/Bottom/ItemName").GetComponent<Text>();

			Success.SetActive(true);
			Failed.SetActive(false);

			itemImg.sprite = itemImage;
			itemTxt.text = itemName;

			inventory.CraftItem(itemName, itemImage, true, false);
			PlayerPrefs.SetInt("QuestClear", 1);
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

			inventory.CraftItem(itemName, itemImage, false, false);
		}
	}

	public void SetFishResult(string itemName, Sprite itemImage)
	{
		HJH_Inventory inventory = inventoryUI.GetComponent<HJH_Inventory>();

		Image itemImg = Success.transform.Find("Pop/Middle/Item/ItemImage").GetComponent<Image>();
		Text itemTxt = Success.transform.Find("Pop/Bottom/ItemName").GetComponent<Text>();

		Success.SetActive(true);
		Failed.SetActive(false);

		itemImg.sprite = itemImage;
		itemTxt.text = itemName;

		inventory.CraftItem(itemName, itemImage, true, true);
		PlayerPrefs.SetInt("QuestClear", 1);
	}
}


