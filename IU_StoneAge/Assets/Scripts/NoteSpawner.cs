using UnityEngine;
using UnityEngine.UI;

public class NoteSpawner : MonoBehaviour
{
	public GameObject notePrefab;			// ������ ��Ʈ�� ������
	public Transform[] spawnPoints;			// ��Ʈ�� ������ ��ġ �迭
	public int numberOfNotes = 8;			// ������ ��Ʈ�� ����
	public RectTransform noteContainer;		// ��Ʈ�� ���� �����̳�

	public Sprite[] noteSprites;            // ��Ʈ�� ����� ��������Ʈ �迭
	int noteCnt = 0;                        // ��Ʈ ���� �� ����� ī��Ʈ
	public Text successText;				// ���� �ؽ�Ʈ
	public Text failText;                   // ���� �ؽ�Ʈ
	int successCnt = 0;						// ���� ī��Ʈ
	int failCnt = 0;						// ���� ī��Ʈ

	void Start()
	{
		noteCnt = 0;
		successCnt = 0;
		failCnt = 0;

		for (int i = 0; i < numberOfNotes; i++)
		{
			SpawnNote(i);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			RemoveNote("LEFT");
			noteCnt++;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			RemoveNote("RIGHT");
			noteCnt++;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			RemoveNote("UP");
			noteCnt++;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			RemoveNote("DOWN");
			noteCnt++;
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

				if (key == spriteName.ToUpper())
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
}
