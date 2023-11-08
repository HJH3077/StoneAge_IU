using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoteSpawner : MonoBehaviour
{
	//public GameObject notePrefab;			// ������ ��Ʈ�� ������
	public Transform[] spawnPoints;			// ��Ʈ�� ������ ��ġ �迭
	public int numberOfNotes = 8;			// ������ ��Ʈ�� ����
	public RectTransform noteContainer;		// ��Ʈ�� ���� �����̳�

	public Sprite[] noteSprites;            // ��Ʈ�� ����� ��������Ʈ �迭
	int noteCnt = 0;                        // ��Ʈ ���� �� ����� ī��Ʈ
	public Text successText;				// ���� �ؽ�Ʈ
	public Text failText;                   // ���� �ؽ�Ʈ
	int successCnt = 0;						// ���� ī��Ʈ
	int failCnt = 0;                        // ���� ī��Ʈ
	int remainCnt = 0;						// �����ؾ� �� ��Ʈ ī��Ʈ

	public Text startText;					// ���� �޽����� ǥ���� Text ������Ʈ
	public bool isGameStart = false;        // ������ ���۵Ǿ����� ����

	public float totalTime = 10f;           // �� ���� �ð�
	private float remainingTime;            // ���� �ð�
	public Text timerText;                  // UI�� ǥ�õ� Ÿ�̸� �ؽ�Ʈ

	void Start()
	{
		noteCnt = 0;
		successCnt = 0;
		failCnt = 0;
		remainCnt = 0;

		remainingTime = totalTime;          // ���� �ð� �ʱ�ȭ

		for (int i = 0; i < numberOfNotes; i++)
		{
			SpawnNote(i);
		}

		StartCoroutine(GameStart());
	}

	void Update()
	{
		if (!isGameStart)
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			//RemoveNote("LEFT");
			RemoveNote("arrow_left__32X32");
			noteCnt++;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			//RemoveNote("RIGHT");
			RemoveNote("arrow_right__32X32");
			noteCnt++;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			//RemoveNote("UP");
			RemoveNote("arrow_up__32X32");
			noteCnt++;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			//RemoveNote("DOWN");
			RemoveNote("arrow_down__32X32");
			noteCnt++;
		}

		// Ÿ�̸� ����
		if (remainingTime > 0 && !(successCnt + failCnt == 8))
		{
			// �ð� ����
			remainingTime -= Time.deltaTime;

			// UI�� ���� �ð� ǥ��
			timerText.text = "�����ð� : " + Mathf.RoundToInt(remainingTime).ToString();
		}
		else if (successCnt + failCnt == 8)
		{
			// ���� �Ϸ� �� �۵�
			Debug.Log("���� ����!!");
			isGameStart = false;
		}
		else
		{
			// �ð� ���� �� �۵�
			if (!(successCnt + failCnt == 8))
			{
				remainCnt = successCnt + failCnt;
				failCnt += 8 - remainCnt;
				failText.text = "���� : " + failCnt;

				Image imageComponent = null;
				foreach (Transform child in noteContainer)
				{
					imageComponent = child.GetComponent<Image>();
					if (imageComponent != null && imageComponent.name == ("Note" + remainCnt))
					{
						Destroy(child.gameObject);
						remainCnt++;
					}
				}
			}

			isGameStart = false;
			Debug.Log("Ÿ�� ����!!");
		}
	}

	void SpawnNote(int spawnNumber)
	{
		int randomIndex = Random.Range(0, 4);
		Transform spawnPoint = spawnPoints[spawnNumber];

		// UI Image�� �����ϰ� noteContainer�� �߰�.
		GameObject noteObject = new GameObject("Note" + spawnNumber);
		Image noteImage = noteObject.AddComponent<Image>();
		noteImage.sprite = noteSprites[randomIndex];
		noteImage.rectTransform.sizeDelta = new Vector2(50, 80);
		noteObject.transform.SetParent(noteContainer, false);

		// ��Ʈ�� ��ġ�� ����.
		RectTransform noteTransform = noteObject.GetComponent<RectTransform>();
		noteTransform.position = spawnPoint.position;
	}

	void RemoveNote(string key)
	{
		Image imageComponent = null;
		foreach (Transform child in noteContainer)
		{
			imageComponent = child.GetComponent<Image>();
			if (imageComponent != null && imageComponent.name == ("Note" + noteCnt))
			{
				// Image ������Ʈ�� source image�� ���� ��������Ʈ �̹����� ���� �̸��� �����ɴϴ�.
				string spriteName = imageComponent.sprite.name;
				//Debug.Log("��������Ʈ ���� �̸�: " + spriteName);

				//if (key == spriteName.ToUpper())
				if (key == spriteName)
				{
					successCnt++;
					successText.text = "���� : " + successCnt;
				}
				else
				{
					failCnt++;
					failText.text = "���� : " + failCnt;
				}
				Destroy(child.gameObject);
				break;
			}
		}
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
