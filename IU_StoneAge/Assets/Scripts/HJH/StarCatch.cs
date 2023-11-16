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
	public Sprite successImage;			// üũ ���� �� �̹���
	public Sprite failImage;			// üũ ���� �� �̹���
	int checkCount = 0;					// üũ�ڽ� ī��Ʈ

	public Text startComment;           // ���� �� ���� ��Ʈ�� ǥ���� Text ������Ʈ
	public Text startText;              // ���� �޽����� ǥ���� Text ������Ʈ
	//public AudioClip readySound;		// Ready ���� Ŭ��
	public AudioClip startSound;        // Start ���� Ŭ��
	public AudioClip bgmSound;          // ��� ���� Ŭ��
	private AudioSource audioSource;    // ����� �ҽ� ������Ʈ

	public bool isGameStart = false;    // ������ ���۵Ǿ����� ����

	int resultCnt = 0;					// ��� ī��Ʈ
	public Sprite[] resultImages;		// ����� �̹���

	private HJH_Result hjh_Result;

	private void Start()
	{
		hjh_Result = GetComponent<HJH_Result>();

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
		#region ### ��ġ �� ����
		// ### if (Input.GetKeyDown(KeyCode.Space)) ��� ���
		//	if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		//	{
		//		Vector3 touchPosition = Input.GetTouch(0).position;
		//		GraphicRaycaster raycaster = GetComponent<GraphicRaycaster>();
		//		PointerEventData eventData = new PointerEventData(EventSystem.current);
		//		eventData.position = touchPosition;
		//		List<RaycastResult> results = new List<RaycastResult>();
		//		raycaster.Raycast(eventData, results);
		#endregion
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
			audioSource.Stop();
			isMovingRight = false;
			isGameStart = false;

			if (resultCnt >= 2)
			{
				hjh_Result.SetResult("�ָԵ���", resultImages[0], true);
			}
			else
			{
				hjh_Result.SetResult("���� ������", resultImages[1], false);
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
		audioSource.PlayOneShot(startSound);
		startComment.gameObject.SetActive(true);
		startText.gameObject.SetActive(false);

		yield return new WaitForSeconds(2.1f);
		startComment.gameObject.SetActive(false);
		startText.gameObject.SetActive(true);

		yield return new WaitForSeconds(0.5f);
		startText.gameObject.SetActive(false);

		// ���� ����
		audioSource.PlayOneShot(bgmSound);
		isGameStart = true;
	}
}
