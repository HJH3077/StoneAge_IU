using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSW_Result : MonoBehaviour
{
    public GameObject Success;                 // 성공 결과창

    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        Success.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("터치함!!!!!");

            Success.SetActive(false);
        }
    }

    public void SetFishResult(string itemName, Sprite itemImage)
    {
        HJH_Inventory inventory = inventoryUI.GetComponent<HJH_Inventory>();

        Image fisgImg = Success.transform.Find("Pop/Middle/Item/ItemImage").GetComponent<Image>();
        Text fishTxt = Success.transform.Find("Pop/Bottom/ItemName").GetComponent<Text>();

        Success.SetActive(true);

        fisgImg.sprite = itemImage;
        fishTxt.text = itemName;

        inventory.CraftItem(itemName, itemImage, true, true);
        PlayerPrefs.SetInt("QuestClear", 1);
    }
}
