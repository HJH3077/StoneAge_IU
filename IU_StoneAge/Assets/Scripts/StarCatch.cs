using UnityEngine;
using UnityEngine.UI;

public class StarCatch : MonoBehaviour
{
	public Slider slider; // 슬라이더 참조
	public float speed = 2f; // 슬라이더 움직이는 속도
	private bool isMovingRight = false; // 슬라이더 움직이는 방향
	//public float catchRange = 0.1f; // '캐치' 가능한 범위
	public float minCatchRange = 0.36f; // '캐치' 가능한 범위
	public float maxCatchRange = 0.66f; // '캐치' 가능한 범위
	public Toggle[] checkBoxs;  // 성공 여부 체크 박스 배열

	int checkCount = 0;			// 체크박스 카운트

	void Update()
	{
		// 슬라이더 움직이기
		if (isMovingRight)
		{
			slider.value += speed * Time.deltaTime;
			if (slider.value >= slider.maxValue)
			{
				isMovingRight = false;
			}
		}
		else
		{
			slider.value -= speed * Time.deltaTime;
			if (slider.value <= slider.minValue)
			{
				isMovingRight = true;
			}
		}

		// '캐치' 확인
		if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바 누르면 '캐치' 시도
		{
			if (slider.value >= minCatchRange && slider.value <= maxCatchRange)
			{
				checkBoxs[checkCount].isOn = true;
				checkCount++;
				Debug.Log("Catch Success!");
			}
			else
			{
				Image background = checkBoxs[checkCount].GetComponentInChildren<Image>();

				if (background != null)
				{
					// 배경색 변경
					background.color = Color.red;
				}

				checkBoxs[checkCount].isOn = false;
				checkCount++;
				Debug.Log("Catch Fail ㅠㅠ.");
			}
		}

		if (checkCount == 3)
		{
			Time.timeScale = 0;
			Debug.Log("게임 종료!!!");
		}
	}
}
