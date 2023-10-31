using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
	public float maxGauge = 100f;		// �ִ� ������ ��
	public float decreaseSpeed = 10f;	// ������ ���� �ӵ�
	public float increaseAmount = 20f;	// ��ư�� ��Ÿ�Ͽ� ������ ������

	public Slider gaugeSlider;			// �������� ǥ���� UI Slider
	public Button tapButton;			// ��Ÿ�� ��ư

	private float currentGauge;			// ���� ������ ��

	private void Start()
	{
		currentGauge = maxGauge;
		UpdateGaugeUI(); 
	}

	private void Update()
	{
		// ������ ����
		currentGauge -= decreaseSpeed * Time.deltaTime;
		currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
		UpdateGaugeUI();
	}

	public void OnTapButtonClicked()
	{
		// ��ư�� ��Ÿ�Ͽ� ������ ����
		currentGauge += increaseAmount;
		currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
		UpdateGaugeUI();
	}

	private void UpdateGaugeUI()
	{
		// ������ UI ������Ʈ
		gaugeSlider.value = currentGauge / maxGauge;
	}
}
