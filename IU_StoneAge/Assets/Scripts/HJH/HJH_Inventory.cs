using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class HJH_Inventory : MonoBehaviour
{
	public List<Item> items = new List<Item>();     // �κ��丮 ������ ����Ʈ

	private string filePath; // ���� ���

	public Image[] slotItemImages;      // ���� ������ �̹����� �����ϴ� �迭
	public Text[] numTexts;             // ������ ������ �����ִ� �ؽ�Ʈ�� �����ϴ� �迭
	public Image[] itemInfo;            // ������ ������ �����ִ� �ؽ�Ʈ�� �����ϴ� �迭
	private int maxInventorySize = 8;   // �κ��丮 �ִ� ũ��
	private int equipItemID = 1;        // ��� ������ ID ����
	
	public GameObject inventory;     
	public GameObject information;
	public GameObject itemContent;

	private Item currentItem;           // Ŭ���� ��ư�� �ش��ϴ� ������ ����

	public Button[] infoButtons;        // Info ��ư �迭

	private void Awake()
	{
		filePath = Path.Combine(Application.dataPath, "inventory.json");
		//filePath = Path.Combine(Application.persistentDataPath, "inventory.json");
	}

	// �������� �κ��丮�� �߰��ϴ� �Լ�
	public void AddItem(Item item)
	{
		if (items.Count >= maxInventorySize)
		{
			Debug.Log("�κ��丮�� ���� á���ϴ�.");
			return;
		}

		items.Add(item);
		SaveInventoryData();// �κ��丮 ������ ����
		Debug.Log("�������� �κ��丮�� �߰��߽��ϴ�: " + item.itemName);
	}

	// �������� �κ��丮���� �����ϴ� �Լ�
	public void RemoveItem(Item item)
	{
		if (items.Contains(item))
		{
			items.Remove(item);
			SaveInventoryData();// �κ��丮 ������ ����
			Debug.Log("�������� �κ��丮���� �����߽��ϴ�: " + item.itemName);
		}
		else
		{
			Debug.Log("�κ��丮�� �ش� �������� �����ϴ�.");
		}
	}

	// �κ��丮 �����͸� JSON ���Ϸ� �����ϴ� �Լ�
	private void SaveInventoryData()
	{
		JArray itemsArray = new JArray();
		foreach (Item item in items)
		{
			JObject itemObject = new JObject();
			itemObject["itemName"] = item.itemName;
			itemObject["itemID"] = item.itemID;
			itemObject["itemImage"] = GetImagePath(item.itemImage); // �̹����� ��� ����
			itemObject["itemCount"] = item.itemCount;
			itemObject["isStackable"] = item.isStackable;

			itemsArray.Add(itemObject);
		}

		string jsonString = itemsArray.ToString();
		File.WriteAllText(filePath, jsonString);

		Debug.Log("�κ��丮 �����͸� �����߽��ϴ�.");
	}

	private string GetImagePath(Sprite sprite)
	{
		string imagePath = ""; // �̹��� ��� ����

		// �̹��� ������ Resources ������ ����� ���
		imagePath = "HJH_Sprites/" + sprite.name;

		return imagePath;
	}

	private Sprite LoadSpriteFromPath(string imagePath)
	{
		Sprite sprite = null; // �ε�� Sprite ��ü

		// Resources ������ ����� �̹����� �ε��ϴ� ���
		sprite = Resources.Load<Sprite>(imagePath);

		return sprite;
	}


	// JSON ���Ͽ��� �κ��丮 �����͸� �ε��ϴ� �Լ�
	private void LoadInventoryData()
	{
		if (File.Exists(filePath))
		{
			//string jsonData = File.ReadAllText(filePath); // ���Ͽ��� ������ �б�
			//InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(jsonData); // JSON �����͸� ��ü�� ������ȭ

			//items = inventoryData.items; // �ε��� �����ͷ� �κ��丮 ������ ����Ʈ ������Ʈ

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

				// �̹����� �ε��Ͽ� Sprite�� ��ȯ
				Sprite itemImage = LoadSpriteFromPath(imagePath);

				Item item = new Item(itemName, itemID, itemImage, itemCount, isStackable);
				items.Add(item);
			}

			// ���� ��� ������ ID ����
			int maxEquipmentItemID = 0;
			foreach (Item item in items)
			{
				if (item.itemID > maxEquipmentItemID && item.itemID != 0)
				{
					maxEquipmentItemID = item.itemID;
				}
			}
			equipItemID = maxEquipmentItemID + 1;

			Debug.Log("�κ��丮 �����͸� �ε��߽��ϴ�.");
		}
		else
		{
			Debug.Log("����� �κ��丮 �����Ͱ� �����ϴ�.");
		}
	}

	// �κ��丮�� ������Ʈ�ϴ� �Լ�
	public void UpdateInventory()
	{
		// ���� ������ �̹����� ������ ������ ������Ʈ
		for (int i = 0; i < slotItemImages.Length; i++)
		{
			if (i < items.Count)
			{
				// �������� ���� ������ ��� ������ ������
				if (items[i].isStackable)
				{
					numTexts[i].text = items[i].itemCount.ToString();
					numTexts[i].gameObject.SetActive(true);
				}
				else
				{
					numTexts[i].gameObject.SetActive(false);
				}

				// �κ��丮�� �������� �ִ� ��� �ش� �̹����� �Ҵ�
				slotItemImages[i].sprite = items[i].itemImage;
				slotItemImages[i].color = Color.white;

				itemInfo[i].gameObject.SetActive(true);
			}
			else
			{
				// �κ��丮�� �������� ���� ��� �̹����� ������ �ʱ�ȭ
				slotItemImages[i].sprite = null;
				slotItemImages[i].color = Color.clear;
				numTexts[i].gameObject.SetActive(false);
				itemInfo[i].gameObject.SetActive(false);
			}
		}
	}

	// �̴ϰ��� ���� �� ����� ���� �Լ�
	public void CraftItem(string itemName, Sprite itemImage, bool success)
	{
		if (success)
		{
			// ���� ���� �� ���� ��� ������ ID�� ���� ��� ������ �߰�
			Item equipmentItem = new Item(itemName, equipItemID, itemImage, 1, false);
			equipItemID++; // ���� ��� ������ ID ����
			AddItem(equipmentItem);
		}
		else
		{
			// ���� ���� �� �κ��丮�� �̹� �ִ� ���������� Ȯ�� �� ���� ����
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

	// ������ ���� ���� �Լ�
	private void IncrementItemCount(Item item)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i].itemID == item.itemID && items[i].isStackable)
			{
				items[i].itemCount++;
				SaveInventoryData(); // �κ��丮 ������ ����
				Debug.Log("������ ������ �����߽��ϴ�: " + item.itemName);
				return;
			}
		}

		// �κ��丮�� �ش� �������� ���� ��� �߰�
		AddItem(item);
	}

	private void Start()
	{
		// ���� ���� �� �κ��丮 ������ �ε�
		LoadInventoryData();

		// Info ��ư Ŭ�� �̺�Ʈ ����
		for (int i = 0; i < infoButtons.Length; i++)
		{
			int buttonIndex = i; // ��ư �ε����� �ӽ� ������ �����Ͽ� Ŭ���� ���� �ذ�
			infoButtons[i].onClick.AddListener(() => ShowInformation(buttonIndex));
		}

		// �κ��丮 UI ������Ʈ
		StartCoroutine(UpdateInventoryCoroutine());
	}

	private IEnumerator UpdateInventoryCoroutine()
	{
		while (true)
		{
			UpdateInventory();

			yield return new WaitForSeconds(1f); // 1�� ���
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

		// ��ư �ε����� �̿��Ͽ� Ŭ���� ��ư�� �ش��ϴ� ������ ������ ������
		if (buttonIndex >= 0)
		{
			Item currentItem = items[buttonIndex];

			Image itemImage = information.transform.Find("ItemImage").GetComponent<Image>();
			itemImage.sprite = currentItem.itemImage;

			Text itemNameText = information.GetComponentInChildren<Text>();
			Text itemInfo = itemContent.GetComponent<Text>();

			itemNameText.text = currentItem.itemName;

			if (currentItem.itemName == "���� ������")
			{
				itemInfo.text = "���ۿ� �����ϰ� ���� �������̴�.";
			}
			else if (currentItem.itemName.Trim() == "�ָԵ���")
			{
				itemInfo.text = "�ָԿ� ��� �� �� �ִ� ���� ������ ������. ���� ������ô��� ��ǥ���� �����̴�. �����ε��� �̰��� �տ� ��� �ٿ뵵 ������ ����ߴ�.";
			}
			
			Debug.Log("Ŭ���� ������ ����: " + currentItem.itemName);
		}
	}
}

[System.Serializable]
public class Item
{
	public string itemName;     // ������ �̸�
	public int itemID;          // ������ ���� ID
	public Sprite itemImage;    // �������� �̹���
	public int itemCount;       // ������ ����
	public bool isStackable;    // ���� ���� ����

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
	public List<Item> items; // �κ��丮 ������ ����Ʈ

	public InventoryData(List<Item> items)
	{
		this.items = items;
	}
}
