using UnityEngine;
using UnityEngine.UI;

public class StarCatch : MonoBehaviour
{
	public Slider slider; // �����̴� ����
	public float speed = 2f; // �����̴� �����̴� �ӵ�
	private bool isMovingRight = false; // �����̴� �����̴� ����
	//public float catchRange = 0.1f; // 'ĳġ' ������ ����
	public float minCatchRange = 0.36f; // 'ĳġ' ������ ����
	public float maxCatchRange = 0.66f; // 'ĳġ' ������ ����
	public Toggle[] checkBoxs;  // ���� ���� üũ �ڽ� �迭

	int checkCount = 0;			// üũ�ڽ� ī��Ʈ

	void Update()
	{
		// �����̴� �����̱�
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

		// 'ĳġ' Ȯ��
		if (Input.GetKeyDown(KeyCode.Space)) // �����̽��� ������ 'ĳġ' �õ�
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
					// ���� ����
					background.color = Color.red;
				}

				checkBoxs[checkCount].isOn = false;
				checkCount++;
				Debug.Log("Catch Fail �Ф�.");
			}
		}

		if (checkCount == 3)
		{
			Time.timeScale = 0;
			Debug.Log("���� ����!!!");
		}
	}
}
