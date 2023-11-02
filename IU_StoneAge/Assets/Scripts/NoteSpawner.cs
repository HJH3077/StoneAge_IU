using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoteSpawner : MonoBehaviour
{
	//public GameObject notePrefab;			// 생성할 노트의 프리팹
	public Transform[] spawnPoints;			// 노트가 생성될 위치 배열
	public int numberOfNotes = 8;			// 생성할 노트의 개수
	public RectTransform noteContainer;		// 노트를 담을 컨테이너

	public Sprite[] noteSprites;            // 노트에 사용할 스프라이트 배열
	int noteCnt = 0;                        // 노트 제거 시 사용할 카운트
	public Text successText;				// 성공 텍스트
	public Text failText;                   // 실패 텍스트
	int successCnt = 0;						// 성공 카운트
	int failCnt = 0;                        // 실패 카운트
	int remainCnt = 0;						// 제거해야 할 노트 카운트

	public Text startText;					// 시작 메시지를 표시할 Text 컴포넌트
	public bool isGameStart = false;        // 게임이 시작되었는지 여부

	public float totalTime = 10f;           // 총 제한 시간
	private float remainingTime;            // 남은 시간
	public Text timerText;                  // UI에 표시될 타이머 텍스트

	void Start()
	{
		noteCnt = 0;
		successCnt = 0;
		failCnt = 0;
		remainCnt = 0;

		remainingTime = totalTime;          // 남은 시간 초기화

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

		// 타이머 감소
		if (remainingTime > 0 && !(successCnt + failCnt == 8))
		{
			// 시간 감소
			remainingTime -= Time.deltaTime;

			// UI에 남은 시간 표시
			timerText.text = "남은시간 : " + Mathf.RoundToInt(remainingTime).ToString();
		}
		else if (successCnt + failCnt == 8)
		{
			// 게임 완료 시 작동
			Debug.Log("게임 종료!!");
			isGameStart = false;
		}
		else
		{
			// 시간 종료 시 작동
			if (!(successCnt + failCnt == 8))
			{
				remainCnt = successCnt + failCnt;
				failCnt += 8 - remainCnt;
				failText.text = "실패 : " + failCnt;

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
			Debug.Log("타임 오버!!");
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

				//if (key == spriteName.ToUpper())
				if (key == spriteName)
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
