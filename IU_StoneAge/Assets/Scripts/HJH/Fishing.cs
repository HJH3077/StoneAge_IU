using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
	public float maxGauge = 100f;       // �ִ� ������ ��
	public float decreaseSpeed = 10f;   // ������ ���� �ӵ�
	public float increaseAmount = 20f;  // ��ư�� ��Ÿ�Ͽ� ������ ������

	public Slider gaugeSlider;          // �������� ǥ���� UI Slider
	public Button tapButton;            // ��Ÿ�� ��ư

	private float currentGauge;         // ���� ������ ��

	public Text startText;                  // ���� �޽����� ǥ���� Text ������Ʈ
	public bool isGameStart = false;        // ������ ���۵Ǿ����� ����

	public float totalTime = 10f;           // �� ���� �ð�
	private float remainingTime;            // ���� �ð�
	public Text timerText;                  // UI�� ǥ�õ� Ÿ�̸� �ؽ�Ʈ

	private void Start()
	{
		currentGauge = 0;
		remainingTime = totalTime;          // ���� �ð� �ʱ�ȭ
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
			Debug.Log("�̼� ����!!");
			isGameStart = false;
		}
		else
		{
			// ������ ����
			currentGauge -= decreaseSpeed * Time.deltaTime;
			currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
			UpdateGaugeUI();

			// Ÿ�̸� ����
			if (remainingTime > 0)
			{
				// �ð� ����
				remainingTime -= Time.deltaTime;

				// UI�� ���� �ð� ǥ��
				timerText.text = "�����ð� : " + Mathf.RoundToInt(remainingTime).ToString();
			}
			else
			{
				// �ð� ���� �� �۵�
				isGameStart = false;
				Debug.Log("Ÿ�� ����!!");
			}
		}
	}

	public void OnTapButtonClicked()
	{
		if (!isGameStart)   // �̰� ������ ������ �߻��ϴ°� ���⵵? 
		{
			return;
		}

		// ��ư�� ��Ÿ�Ͽ� ������ ����
		currentGauge += increaseAmount;
		currentGauge = Mathf.Clamp(currentGauge, 0f, maxGauge);
		Debug.Log(currentGauge);
		UpdateGaugeUI();
	}

	private void UpdateGaugeUI()
	{
		// ������ UI ������Ʈ
		gaugeSlider.value = currentGauge / maxGauge;
	}

	private IEnumerator GameStart()
	{
		yield return new WaitForSeconds(0.5f);
		startText.gameObject.SetActive(true);

		yield return new WaitForSeconds(1.5f);
		startText.gameObject.SetActive(false);

		// ���� ����
		isGameStart = true;
	}
}
