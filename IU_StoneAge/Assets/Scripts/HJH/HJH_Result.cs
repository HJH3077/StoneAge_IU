using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HJH_Result : MonoBehaviour
{
	public GameObject Success;                 // 성공 결과창
	public GameObject Failed;                  // 실패 결과창
	//int randomIndex;

	public Sprite[] images; // 등록할 사진들을 저장할 배열

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
			Debug.Log("터치함!!!!!");

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
