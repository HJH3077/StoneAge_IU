using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class HJH_Inventory : MonoBehaviour
{
	public List<Item> items = new List<Item>();     // 인벤토리 아이템 리스트

	private string filePath; // 파일 경로

	public Image[] slotItemImages;      // 슬롯 아이템 이미지를 저장하는 배열
	public Text[] numTexts;             // 아이템 개수를 보여주는 텍스트를 저장하는 배열
	public Image[] itemInfo;            // 아이템 개수를 보여주는 텍스트를 저장하는 배열
	private int maxInventorySize = 8;   // 인벤토리 최대 크기
	private int equipItemID = 1;        // 장비 아이템 ID 변수
	
	public GameObject inventory;     
	public GameObject information;
	public GameObject itemContent;

	private Item currentItem;           // 클릭한 버튼에 해당하는 아이템 정보

	public Button[] infoButtons;        // Info 버튼 배열

	private void Awake()
	{
		filePath = Path.Combine(Application.dataPath, "inventory.json");
		//filePath = Path.Combine(Application.persistentDataPath, "inventory.json");
	}

	// 아이템을 인벤토리에 추가하는 함수
	public void AddItem(Item item)
	{
		if (items.Count >= maxInventorySize)
		{
			Debug.Log("인벤토리가 가득 찼습니다.");
			return;
		}

		items.Add(item);
		SaveInventoryData();// 인벤토리 데이터 저장
		Debug.Log("아이템을 인벤토리에 추가했습니다: " + item.itemName);
	}

	// 아이템을 인벤토리에서 제거하는 함수
	public void RemoveItem(Item item)
	{
		if (items.Contains(item))
		{
			items.Remove(item);
			SaveInventoryData();// 인벤토리 데이터 저장
			Debug.Log("아이템을 인벤토리에서 제거했습니다: " + item.itemName);
		}
		else
		{
			Debug.Log("인벤토리에 해당 아이템이 없습니다.");
		}
	}

	// 인벤토리 데이터를 JSON 파일로 저장하는 함수
	private void SaveInventoryData()
	{
		JArray itemsArray = new JArray();
		foreach (Item item in items)
		{
			JObject itemObject = new JObject();
			itemObject["itemName"] = item.itemName;
			itemObject["itemID"] = item.itemID;
			itemObject["itemImage"] = GetImagePath(item.itemImage); // 이미지의 경로 저장
			itemObject["itemCount"] = item.itemCount;
			itemObject["isStackable"] = item.isStackable;

			itemsArray.Add(itemObject);
		}

		string jsonString = itemsArray.ToString();
		File.WriteAllText(filePath, jsonString);

		Debug.Log("인벤토리 데이터를 저장했습니다.");
	}

	private string GetImagePath(Sprite sprite)
	{
		string imagePath = ""; // 이미지 경로 변수

		// 이미지 파일이 Resources 폴더에 저장된 경우
		imagePath = "HJH_Sprites/" + sprite.name;

		return imagePath;
	}

	private Sprite LoadSpriteFromPath(string imagePath)
	{
		Sprite sprite = null; // 로드된 Sprite 객체

		// Resources 폴더에 저장된 이미지를 로드하는 경우
		sprite = Resources.Load<Sprite>(imagePath);

		return sprite;
	}


	// JSON 파일에서 인벤토리 데이터를 로드하는 함수
	private void LoadInventoryData()
	{
		if (File.Exists(filePath))
		{
			//string jsonData = File.ReadAllText(filePath); // 파일에서 데이터 읽기
			//InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(jsonData); // JSON 데이터를 객체로 역직렬화

			//items = inventoryData.items; // 로드한 데이터로 인벤토리 아이템 리스트 업데이트

			string jsonData = File.ReadAllText(filePath);
			JArray itemsArray = JArray.Parse(jsonData);

			items.Clear();

			foreach (JObject itemObject in itemsArray)
			{
				string itemName = itemObject["itemName"].ToString();
				int itemID = int.Parse(itemObject["itemID"].ToString());
				string imagePath = itemObject["itemImage"].ToString();
				int itemCount = int.Parse(itemObject["itemCount"].ToString());
				bool isStackable = bool.Parse(itemObject["isStackable"].ToString());

				// 이미지를 로드하여 Sprite로 변환
				Sprite itemImage = LoadSpriteFromPath(imagePath);

				Item item = new Item(itemName, itemID, itemImage, itemCount, isStackable);
				items.Add(item);
			}

			// 다음 장비 아이템 ID 설정
			int maxEquipmentItemID = 0;
			foreach (Item item in items)
			{
				if (item.itemID > maxEquipmentItemID && item.itemID != 0)
				{
					maxEquipmentItemID = item.itemID;
				}
			}
			equipItemID = maxEquipmentItemID + 1;

			Debug.Log("인벤토리 데이터를 로드했습니다.");
		}
		else
		{
			Debug.Log("저장된 인벤토리 데이터가 없습니다.");
		}
	}

	// 인벤토리를 업데이트하는 함수
	public void UpdateInventory()
	{
		// 슬롯 아이템 이미지와 아이템 개수를 업데이트
		for (int i = 0; i < slotItemImages.Length; i++)
		{
			if (i < items.Count)
			{
				// 아이템이 스택 가능한 경우 개수를 보여줌
				if (items[i].isStackable)
				{
					numTexts[i].text = items[i].itemCount.ToString();
					numTexts[i].gameObject.SetActive(true);
				}
				else
				{
					numTexts[i].gameObject.SetActive(false);
				}

				// 인벤토리에 아이템이 있는 경우 해당 이미지를 할당
				slotItemImages[i].sprite = items[i].itemImage;
				slotItemImages[i].color = Color.white;

				itemInfo[i].gameObject.SetActive(true);
			}
			else
			{
				// 인벤토리에 아이템이 없는 경우 이미지와 개수를 초기화
				slotItemImages[i].sprite = null;
				slotItemImages[i].color = Color.clear;
				numTexts[i].gameObject.SetActive(false);
				itemInfo[i].gameObject.SetActive(false);
			}
		}
	}

	// 미니게임 종료 시 결과물 제작 함수
	public void CraftItem(string itemName, Sprite itemImage, bool success)
	{
		if (success)
		{
			// 제작 성공 시 다음 장비 아이템 ID를 가진 장비 아이템 추가
			Item equipmentItem = new Item(itemName, equipItemID, itemImage, 1, false);
			equipItemID++; // 다음 장비 아이템 ID 증가
			AddItem(equipmentItem);
		}
		else
		{
			// 제작 실패 시 인벤토리에 이미 있는 아이템인지 확인 후 개수 증가
			Item consumableItem = new Item(itemName, 0, itemImage, 1, true);
			bool itemExists = false;

			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].itemID == 0 && items[i].isStackable)
				{
					IncrementItemCount(consumableItem);
					itemExists = true;
					break;
				}
			}

			if (!itemExists)
			{
				AddItem(consumableItem);
			}
		}
	}

	// 아이템 개수 증가 함수
	private void IncrementItemCount(Item item)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i].itemID == item.itemID && items[i].isStackable)
			{
				items[i].itemCount++;
				SaveInventoryData(); // 인벤토리 데이터 저장
				Debug.Log("아이템 개수를 증가했습니다: " + item.itemName);
				return;
			}
		}

		// 인벤토리에 해당 아이템이 없는 경우 추가
		AddItem(item);
	}

	private void Start()
	{
		// 게임 시작 시 인벤토리 데이터 로드
		LoadInventoryData();

		// Info 버튼 클릭 이벤트 설정
		for (int i = 0; i < infoButtons.Length; i++)
		{
			int buttonIndex = i; // 버튼 인덱스를 임시 변수에 저장하여 클로저 문제 해결
			infoButtons[i].onClick.AddListener(() => ShowInformation(buttonIndex));
		}

		// 인벤토리 UI 업데이트
		StartCoroutine(UpdateInventoryCoroutine());
	}

	private IEnumerator UpdateInventoryCoroutine()
	{
		while (true)
		{
			UpdateInventory();

			yield return new WaitForSeconds(1f); // 1초 대기
		}
	}

	public void CloseInventory()
	{
		inventory.SetActive(false);
	}

	public void Closeinformation()
	{
		information.SetActive(false);
	}

	public void ShowInformation(int buttonIndex)
	{
		information.SetActive(true);

		// 버튼 인덱스를 이용하여 클릭한 버튼에 해당하는 아이템 정보를 가져옴
		if (buttonIndex >= 0)
		{
			Item currentItem = items[buttonIndex];

			Image itemImage = information.transform.Find("ItemImage").GetComponent<Image>();
			itemImage.sprite = currentItem.itemImage;

			Text itemNameText = information.GetComponentInChildren<Text>();
			Text itemInfo = itemContent.GetComponent<Text>();

			itemNameText.text = currentItem.itemName;

			if (currentItem.itemName == "깨진 돌조각")
			{
				itemInfo.text = "제작에 실패하고 남은 돌조각이다.";
			}
			else if (currentItem.itemName.Trim() == "주먹도끼")
			{
				itemInfo.text = "주먹에 쥐고 쓸 수 있는 도끼 형태의 뗀석기. 전기 구석기시대의 대표적인 석기이다. 원시인들은 이것을 손에 들고 다용도 도구로 사용했다.";
			}
			
			Debug.Log("클릭한 아이템 정보: " + currentItem.itemName);
		}
	}
}

[System.Serializable]
public class Item
{
	public string itemName;     // 아이템 이름
	public int itemID;          // 아이템 고유 ID
	public Sprite itemImage;    // 아이템의 이미지
	public int itemCount;       // 아이템 개수
	public bool isStackable;    // 스택 가능 여부

	public Item(string name, int id, Sprite image, int count, bool stackable)
	{
		itemName = name;
		itemID = id;
		itemImage = image;
		itemCount = count;
		isStackable = stackable;
	}
}

[System.Serializable]
public class InventoryData
{
	public List<Item> items; // 인벤토리 아이템 리스트

	public InventoryData(List<Item> items)
	{
		this.items = items;
	}
}
