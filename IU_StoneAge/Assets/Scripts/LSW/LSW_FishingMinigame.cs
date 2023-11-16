using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LSW_FishingMinigame : MonoBehaviour
{
	/// <summary>
	/// This is the main fishing minigame code. It controls the states of fishing,
	/// then when in the minigame state it controls the movement of the catching
	/// bar and selects which fish we are catching.
	/// </summary>
	/// 
	
	
	//These bools are just for keeping track of the state of the minigame we are in
	private bool lineCast = false;
	private bool nibble = false;
	public bool reelingFish = false;

    private LSW_Fish currentFishOnLine; //Reference to the current fish we are catching (Fish class is in Fish.cs)

    //These are references for the gameobjects used in the UI
    [Header("Setup References")]
    //The catching bar is the green bar that you put ontop of the fish to catch it
    [SerializeField] private GameObject catchingbar;
    private Vector3 catchingBarLoc;
    private Rigidbody2D catchingBarRB;
    
    //This is the fish on the UI that you are chasing to catch
    [SerializeField] private GameObject fishBar;
	//public GameObject fishBar2;

    private LSW_FishingMinigame_FishTrigger fishTrigger; //Reference to this script on the fish
    private bool inTrigger = false; //Whether or not the fish is inside the "catchingbar"
    
    private float catchPercentage = 0f; //0-100 how much you have caught the fish
    [SerializeField] private Slider catchProgressBar; //The bar on the right that shows how much you have caught

	[SerializeField] private GameObject thoughtBubbles;
	[SerializeField] private GameObject minigameCanvas;

    [Header("Settings")]
    //[SerializeField] private KeyCode fishingKey = KeyCode.Space; //Key used to play
	//[SerializeField] private MouseButton touchKey = MouseButton.Left;
    [SerializeField] private float catchMultiplier = 10f; //Higher means catch fish faster x
    [SerializeField] private float catchingForce; //How much force to push the catchingbar up by

    private LSW_Result lsw_Result;

    /// // <summary>

    /// </summary>

    //[SerializeField] private GameObject canvas_Fishing;
    //public TextMeshPro textfishCount;
    public string fishName;
    public string fishSprite;
    public int fishCount;
	public int fishLevel;
	public bool IscheckFish = false;

	public AudioClip caughtfishSound;
	public AudioSource _caughtfishSound;
	Sprite tempSprite;


    private void Start() {
        lsw_Result = GetComponent<LSW_Result>();

        catchingBarRB = catchingbar.GetComponent<Rigidbody2D>(); //Get reference to the Rigidbody on the catchingbar
	    catchingBarLoc = catchingbar.GetComponent<RectTransform>().localPosition; //Use this to reset the catchingbars position to the bottom of the "water"
		//canvas_Fishing.SetActive(false);
		
	}

    private void Update() {
	    if (!reelingFish) { //If we arent currently in the reeling stage
                            //if ((Input.GetKeyDown(fishingKey) && !lineCast) || Input.GetMouseButtonDown(0)) 
            if (Input.GetMouseButtonDown(0) && !lineCast)
            { //This is if we are doing nothing and are ready to cast a line
              //lineCast = true;
                Debug.Log("낚시시작:캐스팅");
				CastLine();
		    }
			else if ((Input.GetMouseButtonDown(0) && lineCast && !nibble)) 
			{ //This is if the line has cast and we reel in before we get a nibble
			    StopAllCoroutines(); //Stops the WaitForNibble timer
			    lineCast = false; //Resets the line being cast
				Debug.Log("실패");
			    //Resets the thought bubbles
			    thoughtBubbles.GetComponent<Animator>().SetTrigger("Reset");
				thoughtBubbles.SetActive(false);
			    
		    }else if (Input.GetMouseButtonDown(0) && lineCast && nibble) { //This is if we reel in while there is a nibble
				Debug.Log("히트 미끼를 물었다!!");
				StopAllCoroutines(); //Stops the LineBreak timer
			    StartReeling();
		    }
	    } 

		else 
		{ //This is when we are in the stage where we are fighitng for the fish
		    if (Input.GetMouseButton(0)) { //If we press space
			    catchingBarRB.AddForce(Vector2.up * catchingForce * Time.deltaTime, ForceMode2D.Force); //Add force to lift the bar
		    }
	    }

	    //If the fish is in our trigger box
	    if (inTrigger && reelingFish) {
		    catchPercentage += catchMultiplier * Time.deltaTime;
	    } else {
		    catchPercentage -= catchMultiplier * Time.deltaTime;
	    }
	    
	    //Changes fish from silhoutte to colour over time
	    var fishColor = Color.Lerp(Color.black, Color.white, Map(0, 100, 0, 1, catchPercentage));
		
		fishBar.GetComponent<Image>().color = fishColor;
	    
	    //Clamps our percentage between 0 and 100
	    catchPercentage = Mathf.Clamp(catchPercentage, 0, 100);
	    catchProgressBar.value = catchPercentage;
	    if (catchPercentage >= 100) { //Fish is caught if percentage is full
		    catchPercentage = 0;
		    FishCaught();
			
			
            
            var tempSprite = Resources.Load<Sprite>($"FishSprites/{currentFishOnLine.spriteID}"); //Get fish sprite from our resources file

            //fishBar2.GetComponent<Image>().sprite = tempSprite;
         		
        }

        if (IscheckFish == true)
        {
            //caughtfishSound = GetComponentInChildren<AudioClip>();
            //_caughtfishSound.Play();
        }
		IscheckFish = false;
    }
    
    //Called to cast our line
    private void CastLine() {
	    lineCast = true;
	    thoughtBubbles.SetActive(true);
	    StartCoroutine(WaitForNibble(10));
    }
    
    //Wait a random time to get a nibble
    private IEnumerator WaitForNibble(float maxWaitTime) {
	    yield return new WaitForSeconds(Random.Range(maxWaitTime * 0.25f, maxWaitTime)); //Wait between 25% of maxWaitTime and the maxWaitTime
	    thoughtBubbles.GetComponent<Animator>().SetTrigger("Alert"); //Show the alert thoughtbubble
	    nibble = true; 
	    StartCoroutine(LineBreak(2)); //If we dont respond in 2 seconds break the line
    }
    
    //Used to start the minigame
    public void StartReeling() {
	    reelingFish = true;
	    
	    nibble = false;
	    lineCast = false;
	    
	    //Set up the fish we are catching
	    currentFishOnLine = LSW_FishManager.GetRandomFishWeighted();
	    tempSprite = Resources.Load<Sprite>($"FishSprites/{currentFishOnLine.spriteID}"); //Get fish sprite from our resources file
		
		fishBar.GetComponent<Image>().sprite = tempSprite;
        

        //���� ������ �̹����� catchedsprite�� ����
        //var catchedSprite = tempSprite;
		
		

        //Changes the width and height of the fishBar to accomodate for wider sprites
        var w = Map(0, 32, 0, 100, tempSprite.texture.width);
	    var h = Map(0, 32, 0, 100, tempSprite.texture.height);
	    fishBar.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
        //fishBar2.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);


        minigameCanvas.SetActive(true);
    }
    
    //This breaks the line if we are waiting for a response too long
    private IEnumerator LineBreak(float lineBreakTime) {
	    yield return new WaitForSeconds(lineBreakTime);
	    Debug.Log("Line Broke!");
        Debug.Log("줄이 끊겼다.");

        //Disable thought bubbles
        thoughtBubbles.GetComponent<Animator>().SetTrigger("Reset");
	    thoughtBubbles.SetActive(false);
	    
	    lineCast = false;
	    nibble = false;
    }

	//Called from the FishingMinigame_FishTrigger script
	public void FishInBar()
	{
		inTrigger = true;
	}

	//Called from the FishingMinigame_FishTrigger script
	public void FishOutOfBar()
	{
		inTrigger = false;
	}

    //Called when the catchpercentage hits 100
    public void FishCaught() {
		
		IscheckFish = true;

	    if (currentFishOnLine == null) { //This picks a new fish if the old one is lost by chance
		    currentFishOnLine = LSW_FishManager.GetRandomFish();
	    }
	    Debug.Log($"Caught a: {currentFishOnLine.name}");
	    reelingFish = false; //No longer reeling in a fish
	    //Reset the thought bubbles
	    thoughtBubbles.SetActive(false);
	    thoughtBubbles.GetComponent<Animator>().SetTrigger("Reset");
	    minigameCanvas.SetActive(false); //Disable the fishing canvas
	    catchingbar.transform.localPosition = catchingBarLoc; //Reset the catching bars position

		if (IscheckFish)
		{
			switch (currentFishOnLine.name)
			{
				case "Crucian":
					lsw_Result.SetFishResult("붕어", tempSprite);
					break;
				case "Salmon":
					lsw_Result.SetFishResult("연어", tempSprite);
					break;
				case "Yelloperch":
					lsw_Result.SetFishResult("농어", tempSprite);
					break;
			}
		}


        //canvas_Fishing.SetActive(true);

        //textfishCount.text = fishCount.ToString();
        //textfishCount.GetComponent<TextMeshPro>().text = "sdfsdf" + fishCount.ToString();
        //Fishnamecount(currentFishOnLine.name, currentFishOnLine.spriteID, currentFishOnLine.baseCost, currentFishOnLine.spokeWeight);
    }

    //  public void Fishnamecount(string _name, string _fishSprite, int _count,int _level)
    //  {
    //      this.fishName = _name;
    //this.fishSprite = _fishSprite;
    //this.fishCount = _count;
    //this.fishLevel = _level;


    //  }

    //Classic mapping script x
    private float Map(float a, float b, float c, float d, float x)
	{
		return (x - a) / (b - a) * (d - c) + c;
	}

}
