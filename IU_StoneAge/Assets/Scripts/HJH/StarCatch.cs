using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StarCatch : MonoBehaviour
{
	public Slider slider; // �����̴� ����
	public float speed = 1.5f; // �����̴� �����̴� �ӵ�
	private bool isMovingRight = false; // �����̴� �����̴� ����
										//public float catchRange = 0.1f; // 'ĳġ' ������ ����
	public float minCatchRange = 0.36f; // 'ĳġ' ������ ����
	public float maxCatchRange = 0.66f; // 'ĳġ' ������ ����

	public Image[] checkResult;         // ���� ���� üũ �̹��� �迭
	public Sprite successImage;     // üũ ���� �� �̹���
	public Sprite failImage;        // üũ ���� �� �̹���
	int checkCount = 0;             // üũ�ڽ� ī��Ʈ

	public Text startText;              // ���� �޽����� ǥ���� Text ������Ʈ
										//public AudioClip readySound;		// Ready ���� Ŭ��
	public AudioClip startSound;        // Start ���� Ŭ��
	public AudioClip bgmSound;          // ��� ���� Ŭ��
	private AudioSource audioSource;    // ����� �ҽ� ������Ʈ

	public bool isGameStart = false;        // ������ ���۵Ǿ����� ����

	int resultCnt = 0;          // ��� ī��Ʈ
	public Sprite[] resultImages;   // ����� �̹���
	GameObject inventoryUI;

	private void Start()
	{
		inventoryUI = GameObject.Find("Inventory");

		checkCount = 0;
		resultCnt = 0;
		audioSource = GetComponent<AudioSource>();

		// ���� �޽����� ǥ���ϱ� ���� �ڷ�ƾ�� ����.
		StartCoroutine(GameStart());
	}

	void Update()
	{
		if (!isGameStart)
		{
			return;
		}

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
		if (Input.GetKeyDown(KeyCode.Space)) // �����̽��� ������ "ĳġ" �õ�
		{
			Image result = checkResult[checkCount].GetComponent<Image>();
			Color color = result.color;
			color.a = 1;
			if (slider.value >= minCatchRange && slider.value <= maxCatchRange)
			{
				result.sprite = successImage;
				result.color = color;
				resultCnt++;
				Debug.Log("Catch Success!");
			}
			else
			{
				result.sprite = failImage;
				result.color = color;
				Debug.Log("Catch Fail �Ф�.");
			}

			checkCount++;
		}

		if (checkCount == 3)
		{
			Debug.Log("���� ����!!!");
			isMovingRight = false;
			isGameStart = false;

			HJH_Inventory inventory = inventoryUI.GetComponent<HJH_Inventory>();
			if (resultCnt >= 2)
			{
				// inventory.CraftItem("��������", resultImages[0], true);
			}
			else
			{
				inventory.CraftItem("���а����", resultImages[1], false);
			}
		}
	}

	private IEnumerator GameStart()
	{
		//// Ready �ؽ�Ʈ�� Ready ���� ���
		//readyText.gameObject.SetActive(true);
		//audioSource.PlayOneShot(readySound);

		//yield return new WaitForSeconds(1f);

		// Start �ؽ�Ʈ�� Start ���� ���
		yield return new WaitForSeconds(0.3f);
		startText.gameObject.SetActive(true);
		audioSource.PlayOneShot(startSound);

		yield return new WaitForSeconds(3.5f);
		startText.gameObject.SetActive(false);

		// ���� ����
		audioSource.PlayOneShot(bgmSound);
		isGameStart = true;
	}
}
