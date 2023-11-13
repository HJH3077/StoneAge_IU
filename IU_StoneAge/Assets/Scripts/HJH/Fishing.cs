using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
	public float maxGauge = 100f;       // 최대 게이지 값
	public float decreaseSpeed = 10f;   // 게이지 감소 속도
	public float increaseAmount = 20f;  // 버튼을 연타하여 게이지 증가량

	public Slider gaugeSlider;          // 게이지를 표시할 UI Slider
	public Button tapButton;            // 연타할 버튼

	private float currentGauge;         // 현재 게이지 값

	public Text startText;                  // 시작 메시지를 표시할 Text 컴포넌트
	public bool isGameStart = false;        // 게임이 시작되었는지 여부

	public float totalTime = 10f;           // 총 제한 시간
	private float remainingTime;            // 남은 시간
	public Text timerText;                  // UI에 표시될 타이머 텍스트

	private void Start()
	{
		currentGauge = 0;
		remainingTime = totalTime;          // 남은 시간 초기화
		UpdateGaugeUI();

		StartCoroutine(GameStart());
	}

	private void Update()
	{
		if (!isGameStart)
		{
			return;
		}


		if (currentGauge == 100)
		{
			Debug.Log("미션 성공!!");
			isGameStart = false;
		}
		else
		{
			// 게이지 감소
			currentGauge -= decreaseSpeed * Time.deltaTime;
			currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
			UpdateGaugeUI();

			// 타이머 감소
			if (remainingTime > 0)
			{
				// 시간 감소
				remainingTime -= Time.deltaTime;

				// UI에 남은 시간 표시
				timerText.text = "남은시간 : " + Mathf.RoundToInt(remainingTime).ToString();
			}
			else
			{
				// 시간 종료 시 작동
				isGameStart = false;
				Debug.Log("타임 오버!!");
			}
		}
	}

	public void OnTapButtonClicked()
	{
		if (!isGameStart)   // 이거 때문에 오류가 발생하는거 같기도? 
		{
			return;
		}

		// 버튼을 연타하여 게이지 증가
		currentGauge += increaseAmount;
		currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
		Debug.Log(currentGauge);
		UpdateGaugeUI();
	}

	private void UpdateGaugeUI()
	{
		// 게이지 UI 업데이트
		gaugeSlider.value = currentGauge / maxGauge;
	}

	private IEnumerator GameStart()
	{
		yield return new WaitForSeconds(0.5f);
		startText.gameObject.SetActive(true);

		yield return new WaitForSeconds(1.5f);
		startText.gameObject.SetActive(false);

		// 게임 진행
		isGameStart = true;
	}
}
