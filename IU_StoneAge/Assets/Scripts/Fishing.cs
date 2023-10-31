using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
	public float maxGauge = 100f;		// 최대 게이지 값
	public float decreaseSpeed = 10f;	// 게이지 감소 속도
	public float increaseAmount = 20f;	// 버튼을 연타하여 게이지 증가량

	public Slider gaugeSlider;			// 게이지를 표시할 UI Slider
	public Button tapButton;			// 연타할 버튼

	private float currentGauge;			// 현재 게이지 값

	private void Start()
	{
		currentGauge = maxGauge;
		UpdateGaugeUI(); 
	}

	private void Update()
	{
		// 게이지 감소
		currentGauge -= decreaseSpeed * Time.deltaTime;
		currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
		UpdateGaugeUI();
	}

	public void OnTapButtonClicked()
	{
		// 버튼을 연타하여 게이지 증가
		currentGauge += increaseAmount;
		currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
		UpdateGaugeUI();
	}

	private void UpdateGaugeUI()
	{
		// 게이지 UI 업데이트
		gaugeSlider.value = currentGauge / maxGauge;
	}
}
