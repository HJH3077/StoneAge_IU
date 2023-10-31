using UnityEngine;
using UnityEngine.UI;

public class NoteSpawner : MonoBehaviour
{
	public GameObject notePrefab;			// 생성할 노트의 프리팹
	public Transform[] spawnPoints;			// 노트가 생성될 위치 배열
	public int numberOfNotes = 8;			// 생성할 노트의 개수
	public RectTransform noteContainer;		// 노트를 담을 컨테이너

	public Sprite[] noteSprites;            // 노트에 사용할 스프라이트 배열
	int noteCnt = 0;                        // 노트 제거 시 사용할 카운트
	public Text successText;				// 성공 텍스트
	public Text failText;                   // 실패 텍스트
	int successCnt = 0;						// 성공 카운트
	int failCnt = 0;						// 실패 카운트

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

		// UI Image를 생성하고 noteContainer에 추가.
		GameObject noteObject = new GameObject("Note" + spawnNumber);
		Image noteImage = noteObject.AddComponent<Image>();
		noteImage.sprite = noteSprites[randomIndex];
		noteImage.rectTransform.sizeDelta = new Vector2(50, 80);
		noteObject.transform.SetParent(noteContainer, false);

		// 노트의 위치를 설정.
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
				// Image 컴포넌트의 source image로 사용된 스프라이트 이미지의 파일 이름을 가져옵니다.
				string spriteName = imageComponent.sprite.name;
				//Debug.Log("스프라이트 파일 이름: " + spriteName);

				if (key == spriteName.ToUpper())
				{
					successCnt++;
					successText.text = "성공 : " + successCnt;
				}
				else
				{
					failCnt++;
					failText.text = "실패 : " + failCnt;
				}
				Destroy(child.gameObject);
				break;
			}
		}

	}
}
