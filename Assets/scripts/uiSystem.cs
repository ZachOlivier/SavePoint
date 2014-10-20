using UnityEngine;
using System.Collections;

public class uiSystem : MonoBehaviour {

	public int btnW	= 0;
	public int btnH	= 0;
	public int btnX	= 0;
	public int btnY	= 0;

	// Variables to hold the amount of time that has passed by since the text started being visible
	public float warningTimer		= 0.0f;
	public float subtitleTimer		= 0.0f;
	public float decisionTimer		= 0.0f;
	public float infoTimer			= 0.0f;
	
	// Variables to hold how long the text should be shown for
	public float warningTime		= 0.0f;
	public float subtitleTime		= 0.0f;
	public float decisionTime		= 0.0f;
	public float infoTime			= 0.0f;

	public bool displayingOne	= false;
	public bool displayingTwo	= false;
	public bool displayingThree = false;
	public bool displayingFour	= false;
	public bool displayingSubtitle 	= false;
	public bool displayingInfo		= false;
	public bool displayingWarning	= false;

	public bool williamTalk		= false;
	public bool mariaTalk		= false;
	public bool richardTalk		= false;
	public bool irmaTalk		= false;

	public string message1		= "";
	public string message2		= "";
	public string message3		= "";
	public string message4		= "";
	public string subtitleMessage	= "";
	public string warningMessage	= "";
	public string infoMessage		= "";

	public GUISkin mySkin;

	public Texture2D boxTexture;

	public GameObject William;
	public GameObject Maria;
	public GameObject Richard;
	public GameObject IRMA;

	// Variables to hold the guiTexts so that we can access their scripts
	public GUIText fourDecision1;
	public GUIText fourDecision2;
	public GUIText fourDecision3;
	public GUIText fourDecision4;
	public GUIText info;
	public GUIText subtitle;
	public GUIText warning;

	public GUITexture oneDecisionBox;
	public GUITexture twoDecisionBox;
	public GUITexture threeDecisionBox;
	public GUITexture fourDecisionBox;
	public GUITexture infoBox;
	public GUITexture subtitleBox;
	public GUITexture warningBox;

	public int lineLength		= 400;
	public int numberOfLines;
	public GUIText block;
	public string[] words;
	public string result;
	public Rect TextSize;

	// Variables to hold the decisions the player can make
	private int path1												= 1;
	private int path11												= 11;
	private int path12												= 12;
	private int path13												= 13;
	private int path14												= 14;
	private int path111												= 111;
	private int path112												= 112;
	private int path113												= 113;
	private int path114												= 114;
	private int path121												= 121;
	private int path122												= 122;
	private int path123												= 123;
	private int path124												= 124;
	private int path131												= 131;
	private int path132												= 132;
	private int path133												= 133;
	private int path134												= 134;
	private int path141												= 141;
	private int path142												= 142;
	private int path143												= 143;
	private int path144												= 144;
	
	private int path2												= 2;
	private int path21												= 21;
	private int path22												= 22;
	private int path23												= 23;
	private int path24												= 24;
	private int path211												= 211;
	private int path212												= 212;
	private int path213												= 213;
	private int path214												= 214;
	private int path221												= 221;
	private int path222												= 222;
	private int path223												= 223;
	private int path224												= 224;
	private int path231												= 231;
	private int path232												= 232;
	private int path233												= 233;
	private int path234												= 234;
	private int path241												= 241;
	private int path242												= 242;
	private int path243												= 243;
	private int path244												= 244;
	
	private int path3												= 3;
	private int path31												= 31;
	private int path32												= 32;
	private int path33												= 33;
	private int path34												= 34;
	private int path311												= 311;
	private int path312												= 312;
	private int path313												= 313;
	private int path314												= 314;
	private int path321												= 321;
	private int path322												= 322;
	private int path323												= 323;
	private int path324												= 324;
	private int path331												= 331;
	private int path332												= 332;
	private int path333												= 333;
	private int path334												= 334;
	private int path341												= 341;
	private int path342												= 342;
	private int path343												= 343;
	private int path344												= 344;
	
	private int path4												= 4;
	private int path41												= 41;
	private int path42												= 42;
	private int path43												= 43;
	private int path44												= 44;
	private int path411												= 411;
	private int path412												= 412;
	private int path413												= 413;
	private int path414												= 414;
	private int path421												= 421;
	private int path422												= 422;
	private int path423												= 423;
	private int path424												= 424;
	private int path431												= 431;
	private int path432												= 432;
	private int path433												= 433;
	private int path434												= 434;
	private int path441												= 441;
	private int path442												= 442;
	public int path443												= 443;
	public int path444												= 444;
	
	private securityBehavior talk;
	private mariaBehavior talk2;
	private richardBehavior talk3;
	private irmaScript talk4;

	void Awake ()
	{
		if (Application.loadedLevel == 1)
		{
			talk = William.GetComponent <securityBehavior>();
			talk2 = Maria.GetComponent <mariaBehavior>();
			talk3 = Richard.GetComponent <richardBehavior>();
		}

		else if (Application.loadedLevel == 3)
		{
			talk4 = IRMA.GetComponent <irmaScript>();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!info.enabled)
		{
			infoBox.enabled = false;
		}
		
		if (!warning.enabled)
		{
			warningBox.enabled = false;
		}
		
		if (!subtitle.enabled)
		{
			subtitleBox.enabled = false;
		}

		if (!displayingOne)
		{
			oneDecisionBox.enabled = false;
		}

		if (!displayingTwo)
		{
			twoDecisionBox.enabled = false;
		}

		if (!displayingThree)
		{
			threeDecisionBox.enabled = false;
		}

		if (!displayingFour)
		{
			fourDecisionBox.enabled = false;
		}
		
		// If warning text is enabled and the amount of time that the text should be shown for is set
		if (warning.enabled && warningTime != 0.0f) {
			
			// Start the timer for how long the text will be shown
			warningTimer += Time.deltaTime;
			
			// If the set time has passed
			if (warningTimer > warningTime) {
				
				// Disable the text, clearing it from the screen
				warning.enabled = false;
				warningBox.enabled = false;
				
				// Reset the timer
				warningTimer = 0.0f;
			}
		}
		
		if (subtitle.enabled && subtitleTime != 0.0f) {
			subtitleTimer += Time.deltaTime;
			
			if (subtitleTimer > subtitleTime) {
				subtitle.enabled = false;
				subtitleBox.enabled = false;
				
				subtitleTimer = 0.0f;
			}
		}
		
		if (displayingOne && decisionTime != 0.0f) {
			decisionTimer += Time.deltaTime;
			
			if (decisionTimer > decisionTime) {
				fourDecision1.enabled = false;
				oneDecisionBox.enabled = false;

				displayingOne = false;
				
				decisionTimer = 0.0f;
			}
		}

		else if (displayingTwo && decisionTime != 0.0f) {
			decisionTimer += Time.deltaTime;
			
			if (decisionTimer > decisionTime) {
				fourDecision1.enabled = false;
				fourDecision2.enabled = false;
				twoDecisionBox.enabled = false;
				
				displayingTwo = false;
				
				decisionTimer = 0.0f;
			}
		}

		else if (displayingThree && decisionTime != 0.0f) {
			decisionTimer += Time.deltaTime;
			
			if (decisionTimer > decisionTime) {
				fourDecision1.enabled = false;
				fourDecision2.enabled = false;
				fourDecision3.enabled = false;
				threeDecisionBox.enabled = false;
				
				displayingThree = false;
				
				decisionTimer = 0.0f;
			}
		}

		else if (displayingFour && decisionTime != 0.0f) {
			decisionTimer += Time.deltaTime;
			
			if (decisionTimer > decisionTime) {
				fourDecision1.enabled = false;
				fourDecision2.enabled = false;
				fourDecision3.enabled = false;
				fourDecision4.enabled = false;
				fourDecisionBox.enabled = false;
				
				displayingFour = false;
				
				decisionTimer = 0.0f;
			}
		}
		
		if (info.enabled && infoTime != 0.0f) {
			infoTimer += Time.deltaTime;
			
			if (infoTimer > infoTime) {
				info.enabled = false;
				infoBox.enabled = false;
				
				infoTimer = 0.0f;
			}
		}
	}
	
	// This void displays error messages to the player in red text, it requires the text and a time to be called
	public void displayWarning (string message, float time) {
		
		// Set the text
		warning.text = message;

		warningMessage = message;
		
		// Set the amount of time that the text will be shown for
		warningTime = time;
		
		// Make sure the timer is reset
		warningTimer = 0.0f;
		
		// If the text isnt already enabled
		if (!warning.enabled) {
			warning.enabled = true;
			warningBox.enabled = true;
		}
	}
	
	// This void displays subtitles at the bottom of the screen in white text
	public void displaySubtitle (string message, float time) {
		FormatString ( message );
		//subtitle.text = message;
		
		subtitleTime = time;
		
		subtitleTimer = 0.0f;
		
		if (!subtitle.enabled) {
			subtitle.enabled = true;
			subtitleBox.enabled = true;
		}
	}
	
	// This void displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
	public void display1Decision (string msg1, float time) {
		fourDecision1.text = msg1;

		message1 = msg1;

		Vector3 position1 = fourDecision1.transform.localPosition;
		position1.x = .5f;
		position1.y = .22f;
		fourDecision1.transform.localPosition = position1;

		Vector2 position2 = fourDecision2.transform.localPosition;
		position2.x = 1f;
		position2.y = 1f;
		fourDecision2.transform.localPosition = position2;
		
		Vector3 position3 = fourDecision3.transform.localPosition;
		position3.x = 1f;
		position3.y = 1f;
		fourDecision3.transform.localPosition = position3;
		
		Vector4 position4 = fourDecision4.transform.localPosition;
		position4.x = 1f;
		position4.y = 1f;
		fourDecision4.transform.localPosition = position4;
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingOne) {
			fourDecision1.enabled = true;
			oneDecisionBox.enabled = true;

			displayingOne = true;
		}
	}

	// This void displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
	public void display2Decision (string msg1, string msg2, float time) {
		fourDecision1.text = msg1;
		fourDecision2.text = msg2;

		message1 = msg1;
		message2 = msg2;

		Vector3 position1 = fourDecision1.transform.localPosition;
		position1.x = .44f;
		position1.y = .15f;
		fourDecision1.transform.localPosition = position1;

		Vector3 position2 = fourDecision2.transform.localPosition;
		position2.x = .56f;
		position2.y = .15f;
		fourDecision2.transform.localPosition = position2;

		Vector3 position3 = fourDecision3.transform.localPosition;
		position3.x = 1f;
		position3.y = 1f;
		fourDecision3.transform.localPosition = position3;
		
		Vector4 position4 = fourDecision4.transform.localPosition;
		position4.x = 1f;
		position4.y = 1f;
		fourDecision4.transform.localPosition = position4;
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingTwo) {
			fourDecision1.enabled = true;
			fourDecision2.enabled = true;
			twoDecisionBox.enabled = true;

			displayingTwo = true;
		}
	}

	// This void displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
	public void display3Decision (string msg1, string msg2, string msg3, float time) {
		fourDecision1.text = msg1;
		fourDecision2.text = msg2;
		fourDecision3.text = msg3;

		message1 = msg1;
		message2 = msg2;
		message3 = msg3;

		Vector3 position1 = fourDecision1.transform.localPosition;
		position1.x = .515f;
		position1.y = .22f;
		fourDecision1.transform.localPosition = position1;

		Vector2 position2 = fourDecision2.transform.localPosition;
		position2.x = .43f;
		position2.y = .15f;
		fourDecision2.transform.localPosition = position2;
		
		Vector3 position3 = fourDecision3.transform.localPosition;
		position3.x = .57f;
		position3.y = .15f;
		fourDecision3.transform.localPosition = position3;
		
		Vector4 position4 = fourDecision4.transform.localPosition;
		position4.x = 1f;
		position4.y = 1f;
		fourDecision4.transform.localPosition = position4;
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingThree) {
			fourDecision1.enabled = true;
			fourDecision2.enabled = true;
			fourDecision3.enabled = true;
			threeDecisionBox.enabled = true;
			
			displayingThree = true;
		}
	}

	// This void displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
	public void display4Decision (string msg1, string msg2, string msg3, string msg4, float time) {
		fourDecision1.text = msg1;
		fourDecision2.text = msg2;
		fourDecision3.text = msg3;
		fourDecision4.text = msg4;

		message1 = msg1;
		message2 = msg2;
		message3 = msg3;
		message4 = msg4;

		Vector3 position1 = fourDecision1.transform.localPosition;
		position1.x = .47f;
		position1.y = .22f;
		fourDecision1.transform.localPosition = position1;
		
		Vector2 position2 = fourDecision2.transform.localPosition;
		position2.x = .41f;
		position2.y = .14f;
		fourDecision2.transform.localPosition = position2;
		
		Vector3 position3 = fourDecision3.transform.localPosition;
		position3.x = .53f;
		position3.y = .22f;
		fourDecision3.transform.localPosition = position3;

		Vector4 position4 = fourDecision4.transform.localPosition;
		position4.x = .59f;
		position4.y = .14f;
		fourDecision4.transform.localPosition = position4;
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingFour) {
			fourDecision1.enabled = true;
			fourDecision2.enabled = true;
			fourDecision3.enabled = true;
			fourDecision4.enabled = true;
			fourDecisionBox.enabled = true;
			
			displayingFour = true;
		}
	}
	
	// This void displays a message to the player about what they currently have the mouse over
	public void displayInfo (string message, float time) {
		info.text = message;

		infoMessage = message;
		
		infoTime = time;
		
		infoTimer = 0.0f;
		
		if (!info.enabled) {
			info.enabled = true;
			infoBox.enabled = true;
		}
	}
	
	public void FormatString ( string text ) { 
		words = text.Split(" "[0]); //Split the string into seperate words
		result = "";

		float a = 40.0f;
		float b = -30.0f;

		subtitleBox.pixelInset = new Rect (-507, b, 1014, a);
		
		for( var index = 0; index < words.Length; index++)
		{
			var word = words[index].Trim();
			if (index == 0) {
				result = words[0];
				block.text = result;
				subtitleMessage = result;
			}
			
			if (index > 0 ) {
				result += " " + word;
				block.text = result;
				subtitleMessage = result;
			}

			TextSize = block.GetScreenRect();

			if (TextSize.width > lineLength)
			{
				//remover 
				result = result.Substring(0,result.Length-(word.Length));
				result += "\n" + word;
				numberOfLines += 1;
				block.text = result;
				subtitleMessage = result;
				a += 28.0f;
				b -= 23.0f;
				subtitleBox.pixelInset = new Rect (-507, b, 1014, a);
			}
		}
	}

	void OnGUI()
	{
		if (Application.loadedLevel == 0)
		{

		}

		else
		{

			if (GUI.skin != mySkin)
			{
				GUI.skin = mySkin;
			}

			if (subtitle.enabled)
			{
				float subtitleAreaW = Screen.width / 1.5f;
				float subtitleAreaH = 900;
				float subtitleScreenX = (Screen.width / 2) - (subtitleAreaW / 2);
				float subtitleScreenY = 100;

				mySkin.box.normal.background = boxTexture;
				mySkin.box.fontSize = 18;

				if (mySkin.box.normal.textColor != Color.white)
				{
					mySkin.box.normal.textColor = Color.white;
				}

				GUILayout.BeginArea(new Rect (subtitleScreenX, subtitleScreenY, subtitleAreaW, subtitleAreaH));

				GUILayout.BeginVertical();
				
				GUILayout.FlexibleSpace();
				
				GUILayout.Box(subtitleMessage);
				
				GUILayout.FlexibleSpace();

				GUILayout.EndVertical();
				
				GUILayout.EndArea();
			}

			if (info.enabled)
			{
				float infoAreaW = Screen.width / 6;
				float infoAreaH = 200;
				float infoScreenX = Screen.width - (infoAreaW + 20);
				float infoScreenY = Screen.height - (infoAreaH / 1.5f);

				mySkin.box.normal.background = boxTexture;
				mySkin.box.fontSize = 18;

				if (mySkin.box.normal.textColor != Color.white)
				{
					mySkin.box.normal.textColor = Color.white;
				}
				
				GUILayout.BeginArea(new Rect (infoScreenX, infoScreenY, infoAreaW, infoAreaH));
				
				GUILayout.BeginVertical();
				
				GUILayout.FlexibleSpace();
				
				GUILayout.Box(infoMessage);
				
				GUILayout.FlexibleSpace();
				
				GUILayout.EndVertical();
				
				GUILayout.EndArea();
			}

			if (warning.enabled)
			{
				float warningAreaW = Screen.width / 6;
				float warningAreaH = 200;
				float warningScreenX = 20;
				float warningScreenY = Screen.height - (warningAreaH / 1.5f);

				mySkin.box.normal.background = boxTexture;
				mySkin.box.fontSize = 18;

				if (mySkin.box.normal.textColor != Color.red)
				{
					mySkin.box.normal.textColor = Color.red;
				}
				
				GUILayout.BeginArea(new Rect (warningScreenX, warningScreenY, warningAreaW, warningAreaH));
				
				GUILayout.BeginVertical();
				
				GUILayout.FlexibleSpace();
				
				GUILayout.Box(warningMessage);
				
				GUILayout.FlexibleSpace();
				
				GUILayout.EndVertical();
				
				GUILayout.EndArea();
			}

			if (displayingOne)
			{
				btnX = (Screen.width / 2) - (btnW / 2);
				btnY = (Screen.height / 2) - (btnH / 2);
				btnW = Screen.width / 4;
				btnH = Screen.height / 20;

				mySkin.button.normal.background = boxTexture;
				mySkin.button.normal.textColor = Color.white;

				if (message1 != "")
				{
					//One one
					if (GUI.Button (new Rect (btnX, btnY + 225, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path1;
							}
							
							else if (talk.path == 1) {
								talk.path = path11;
							}
							
							else if (talk.path == 2) {
								talk.path = path21;
							}
							
							else if (talk.path == 3) {
								talk.path = path31;
							}
							
							else if (talk.path == 4) {
								talk.path = path41;
							}
							
							else if (talk.path == 11) {
								talk.path = path111;
							}
							
							else if (talk.path == 12) {
								talk.path = path121;
							}
							
							else if (talk.path == 13) {
								talk.path = path131;
							}
							
							else if (talk.path == 14) {
								talk.path = path141;
							}
							
							else if (talk.path == 21) {
								talk.path = path211;
							}
							
							else if (talk.path == 22) {
								talk.path = path221;
							}
							
							else if (talk.path == 23) {
								talk.path = path231;
							}
							
							else if (talk.path == 24) {
								talk.path = path241;
							}
							
							else if (talk.path == 31) {
								talk.path = path311;
							}
							
							else if (talk.path == 32) {
								talk.path = path321;
							}
							
							else if (talk.path == 33) {
								talk.path = path331;
							}
							
							else if (talk.path == 34) {
								talk.path = path341;
							}
							
							else if (talk.path == 41) {
								talk.path = path411;
							}
							
							else if (talk.path == 42) {
								talk.path = path421;
							}
							
							else if (talk.path == 43) {
								talk.path = path431;
							}
							
							else if (talk.path == 44) {
								talk.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path1;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path11;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path21;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path31;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path41;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path111;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path121;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path131;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path141;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path211;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path221;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path231;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path241;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path311;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path321;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path331;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path341;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path411;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path421;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path431;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path1;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path11;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path21;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path31;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path41;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path111;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path121;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path131;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path141;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path211;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path221;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path231;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path241;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path311;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path321;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path331;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path341;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path411;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path421;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path431;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path1;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path11;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path21;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path31;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path41;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path111;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path121;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path131;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path141;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path211;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path221;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path231;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path241;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path311;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path321;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path331;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path341;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path411;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path421;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path431;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}
			}

			else if (displayingTwo)
			{
				btnX = (Screen.width / 2) - (btnW / 2);
				btnY = (Screen.height / 2) - (btnH / 2);
				btnW = Screen.width / 4;
				btnH = Screen.height / 20;

				mySkin.button.normal.background = boxTexture;
				mySkin.button.normal.textColor = Color.white;

				if (message1 != "")
				{
					if (Event.current.button == 1 || Event.current.button == 2)
					{
						
					}
					
					else

					//Two one
					if (GUI.Button (new Rect (btnX - 250, btnY + 250, btnW, btnH), ""))
					{
						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path1;
							}
							
							else if (talk.path == 1) {
								talk.path = path11;
							}
							
							else if (talk.path == 2) {
								talk.path = path21;
							}
							
							else if (talk.path == 3) {
								talk.path = path31;
							}
							
							else if (talk.path == 4) {
								talk.path = path41;
							}
							
							else if (talk.path == 11) {
								talk.path = path111;
							}
							
							else if (talk.path == 12) {
								talk.path = path121;
							}
							
							else if (talk.path == 13) {
								talk.path = path131;
							}
							
							else if (talk.path == 14) {
								talk.path = path141;
							}
							
							else if (talk.path == 21) {
								talk.path = path211;
							}
							
							else if (talk.path == 22) {
								talk.path = path221;
							}
							
							else if (talk.path == 23) {
								talk.path = path231;
							}
							
							else if (talk.path == 24) {
								talk.path = path241;
							}
							
							else if (talk.path == 31) {
								talk.path = path311;
							}
							
							else if (talk.path == 32) {
								talk.path = path321;
							}
							
							else if (talk.path == 33) {
								talk.path = path331;
							}
							
							else if (talk.path == 34) {
								talk.path = path341;
							}
							
							else if (talk.path == 41) {
								talk.path = path411;
							}
							
							else if (talk.path == 42) {
								talk.path = path421;
							}
							
							else if (talk.path == 43) {
								talk.path = path431;
							}
							
							else if (talk.path == 44) {
								talk.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path1;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path11;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path21;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path31;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path41;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path111;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path121;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path131;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path141;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path211;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path221;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path231;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path241;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path311;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path321;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path331;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path341;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path411;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path421;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path431;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path1;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path11;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path21;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path31;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path41;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path111;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path121;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path131;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path141;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path211;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path221;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path231;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path241;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path311;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path321;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path331;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path341;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path411;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path421;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path431;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path1;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path11;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path21;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path31;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path41;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path111;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path121;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path131;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path141;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path211;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path221;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path231;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path241;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path311;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path321;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path331;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path341;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path411;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path421;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path431;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}

				if (message2 != "")
				{
					//Two two
					if (GUI.Button (new Rect (btnX + 250, btnY + 250, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path2;
							}
							
							else if (talk.path == 1) {
								talk.path = path12;
							}
							
							else if (talk.path == 2) {
								talk.path = path22;
							}
							
							else if (talk.path == 3) {
								talk.path = path32;
							}
							
							else if (talk.path == 4) {
								talk.path = path42;
							}
							
							else if (talk.path == 11) {
								talk.path = path112;
							}
							
							else if (talk.path == 12) {
								talk.path = path122;
							}
							
							else if (talk.path == 13) {
								talk.path = path132;
							}
							
							else if (talk.path == 14) {
								talk.path = path142;
							}
							
							else if (talk.path == 21) {
								talk.path = path212;
							}
							
							else if (talk.path == 22) {
								talk.path = path222;
							}
							
							else if (talk.path == 23) {
								talk.path = path232;
							}
							
							else if (talk.path == 24) {
								talk.path = path242;
							}
							
							else if (talk.path == 31) {
								talk.path = path312;
							}
							
							else if (talk.path == 32) {
								talk.path = path322;
							}
							
							else if (talk.path == 33) {
								talk.path = path332;
							}
							
							else if (talk.path == 34) {
								talk.path = path342;
							}
							
							else if (talk.path == 41) {
								talk.path = path412;
							}
							
							else if (talk.path == 42) {
								talk.path = path422;
							}
							
							else if (talk.path == 43) {
								talk.path = path432;
							}
							
							else if (talk.path == 44) {
								talk.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path2;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path12;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path22;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path32;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path42;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path112;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path122;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path132;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path142;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path212;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path222;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path232;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path242;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path312;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path322;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path332;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path342;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path412;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path422;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path432;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path2;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path12;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path22;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path32;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path42;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path112;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path122;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path132;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path142;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path212;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path222;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path232;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path242;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path312;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path322;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path332;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path342;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path412;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path422;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path432;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path2;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path12;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path22;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path32;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path42;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path112;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path122;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path132;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path142;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path212;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path222;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path232;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path242;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path312;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path322;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path332;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path342;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path412;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path422;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path432;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}
			}

			else if (displayingThree)
			{
				btnX = (Screen.width / 2) - (btnW / 2);
				btnY = (Screen.height / 2) - (btnH / 2);
				btnW = Screen.width / 4;
				btnH = Screen.height / 20;

				mySkin.button.normal.background = boxTexture;
				mySkin.button.normal.textColor = Color.white;

				if (message1 != "")
				{
					//Three one
					if (GUI.Button (new Rect (btnX, btnY + 220, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path1;
							}
							
							else if (talk.path == 1) {
								talk.path = path11;
							}
							
							else if (talk.path == 2) {
								talk.path = path21;
							}
							
							else if (talk.path == 3) {
								talk.path = path31;
							}
							
							else if (talk.path == 4) {
								talk.path = path41;
							}
							
							else if (talk.path == 11) {
								talk.path = path111;
							}
							
							else if (talk.path == 12) {
								talk.path = path121;
							}
							
							else if (talk.path == 13) {
								talk.path = path131;
							}
							
							else if (talk.path == 14) {
								talk.path = path141;
							}
							
							else if (talk.path == 21) {
								talk.path = path211;
							}
							
							else if (talk.path == 22) {
								talk.path = path221;
							}
							
							else if (talk.path == 23) {
								talk.path = path231;
							}
							
							else if (talk.path == 24) {
								talk.path = path241;
							}
							
							else if (talk.path == 31) {
								talk.path = path311;
							}
							
							else if (talk.path == 32) {
								talk.path = path321;
							}
							
							else if (talk.path == 33) {
								talk.path = path331;
							}
							
							else if (talk.path == 34) {
								talk.path = path341;
							}
							
							else if (talk.path == 41) {
								talk.path = path411;
							}
							
							else if (talk.path == 42) {
								talk.path = path421;
							}
							
							else if (talk.path == 43) {
								talk.path = path431;
							}
							
							else if (talk.path == 44) {
								talk.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path1;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path11;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path21;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path31;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path41;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path111;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path121;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path131;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path141;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path211;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path221;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path231;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path241;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path311;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path321;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path331;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path341;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path411;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path421;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path431;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path1;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path11;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path21;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path31;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path41;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path111;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path121;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path131;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path141;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path211;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path221;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path231;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path241;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path311;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path321;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path331;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path341;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path411;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path421;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path431;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path1;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path11;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path21;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path31;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path41;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path111;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path121;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path131;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path141;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path211;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path221;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path231;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path241;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path311;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path321;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path331;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path341;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path411;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path421;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path431;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}

				if (message2 != "")
				{
					//Three two
					if (GUI.Button (new Rect (btnX - 250, btnY + 280, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path2;
							}
							
							else if (talk.path == 1) {
								talk.path = path12;
							}
							
							else if (talk.path == 2) {
								talk.path = path22;
							}
							
							else if (talk.path == 3) {
								talk.path = path32;
							}
							
							else if (talk.path == 4) {
								talk.path = path42;
							}
							
							else if (talk.path == 11) {
								talk.path = path112;
							}
							
							else if (talk.path == 12) {
								talk.path = path122;
							}
							
							else if (talk.path == 13) {
								talk.path = path132;
							}
							
							else if (talk.path == 14) {
								talk.path = path142;
							}
							
							else if (talk.path == 21) {
								talk.path = path212;
							}
							
							else if (talk.path == 22) {
								talk.path = path222;
							}
							
							else if (talk.path == 23) {
								talk.path = path232;
							}
							
							else if (talk.path == 24) {
								talk.path = path242;
							}
							
							else if (talk.path == 31) {
								talk.path = path312;
							}
							
							else if (talk.path == 32) {
								talk.path = path322;
							}
							
							else if (talk.path == 33) {
								talk.path = path332;
							}
							
							else if (talk.path == 34) {
								talk.path = path342;
							}
							
							else if (talk.path == 41) {
								talk.path = path412;
							}
							
							else if (talk.path == 42) {
								talk.path = path422;
							}
							
							else if (talk.path == 43) {
								talk.path = path432;
							}
							
							else if (talk.path == 44) {
								talk.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path2;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path12;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path22;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path32;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path42;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path112;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path122;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path132;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path142;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path212;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path222;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path232;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path242;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path312;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path322;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path332;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path342;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path412;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path422;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path432;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path2;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path12;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path22;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path32;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path42;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path112;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path122;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path132;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path142;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path212;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path222;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path232;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path242;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path312;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path322;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path332;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path342;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path412;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path422;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path432;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path2;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path12;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path22;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path32;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path42;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path112;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path122;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path132;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path142;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path212;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path222;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path232;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path242;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path312;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path322;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path332;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path342;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path412;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path422;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path432;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}

				if (message3 != "")
				{
					//Three three
					if (GUI.Button (new Rect (btnX + 250, btnY + 280, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path3;
							}
							
							else if (talk.path == 1) {
								talk.path = path13;
							}
							
							else if (talk.path == 2) {
								talk.path = path23;
							}
							
							else if (talk.path == 3) {
								talk.path = path33;
							}
							
							else if (talk.path == 4) {
								talk.path = path43;
							}
							
							else if (talk.path == 11) {
								talk.path = path113;
							}
							
							else if (talk.path == 12) {
								talk.path = path123;
							}
							
							else if (talk.path == 13) {
								talk.path = path133;
							}
							
							else if (talk.path == 14) {
								talk.path = path143;
							}
							
							else if (talk.path == 21) {
								talk.path = path213;
							}
							
							else if (talk.path == 22) {
								talk.path = path223;
							}
							
							else if (talk.path == 23) {
								talk.path = path233;
							}
							
							else if (talk.path == 24) {
								talk.path = path243;
							}
							
							else if (talk.path == 31) {
								talk.path = path313;
							}
							
							else if (talk.path == 32) {
								talk.path = path323;
							}
							
							else if (talk.path == 33) {
								talk.path = path333;
							}
							
							else if (talk.path == 34) {
								talk.path = path343;
							}
							
							else if (talk.path == 41) {
								talk.path = path413;
							}
							
							else if (talk.path == 42) {
								talk.path = path423;
							}
							
							else if (talk.path == 43) {
								talk.path = path433;
							}
							
							else if (talk.path == 44) {
								talk.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path3;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path13;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path23;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path33;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path43;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path113;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path123;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path133;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path143;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path213;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path223;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path233;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path243;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path313;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path323;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path333;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path343;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path413;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path423;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path433;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path3;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path13;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path23;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path33;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path43;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path113;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path123;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path133;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path143;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path213;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path223;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path233;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path243;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path313;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path323;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path333;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path343;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path413;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path423;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path433;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path3;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path13;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path23;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path33;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path43;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path113;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path123;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path133;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path143;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path213;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path223;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path233;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path243;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path313;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path323;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path333;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path343;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path413;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path423;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path433;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}
			}

			else if (displayingFour)
			{
				btnX = (Screen.width / 2) - (btnW / 2);
				btnY = (Screen.height / 2) - (btnH / 2);
				btnW = Screen.width / 4;
				btnH = Screen.height / 20;

				mySkin.button.normal.background = boxTexture;
				mySkin.button.normal.textColor = Color.white;

				if (message1 != "")
				{
					//Four one
					if (GUI.Button (new Rect (btnX - 200, btnY + 225, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{

						}

						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path1;
							}
							
							else if (talk.path == 1) {
								talk.path = path11;
							}
							
							else if (talk.path == 2) {
								talk.path = path21;
							}
							
							else if (talk.path == 3) {
								talk.path = path31;
							}
							
							else if (talk.path == 4) {
								talk.path = path41;
							}
							
							else if (talk.path == 11) {
								talk.path = path111;
							}
							
							else if (talk.path == 12) {
								talk.path = path121;
							}
							
							else if (talk.path == 13) {
								talk.path = path131;
							}
							
							else if (talk.path == 14) {
								talk.path = path141;
							}
							
							else if (talk.path == 21) {
								talk.path = path211;
							}
							
							else if (talk.path == 22) {
								talk.path = path221;
							}
							
							else if (talk.path == 23) {
								talk.path = path231;
							}
							
							else if (talk.path == 24) {
								talk.path = path241;
							}
							
							else if (talk.path == 31) {
								talk.path = path311;
							}
							
							else if (talk.path == 32) {
								talk.path = path321;
							}
							
							else if (talk.path == 33) {
								talk.path = path331;
							}
							
							else if (talk.path == 34) {
								talk.path = path341;
							}
							
							else if (talk.path == 41) {
								talk.path = path411;
							}
							
							else if (talk.path == 42) {
								talk.path = path421;
							}
							
							else if (talk.path == 43) {
								talk.path = path431;
							}
							
							else if (talk.path == 44) {
								talk.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path1;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path11;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path21;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path31;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path41;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path111;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path121;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path131;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path141;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path211;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path221;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path231;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path241;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path311;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path321;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path331;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path341;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path411;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path421;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path431;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path1;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path11;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path21;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path31;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path41;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path111;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path121;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path131;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path141;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path211;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path221;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path231;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path241;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path311;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path321;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path331;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path341;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path411;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path421;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path431;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path1;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path11;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path21;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path31;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path41;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path111;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path121;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path131;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path141;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path211;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path221;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path231;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path241;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path311;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path321;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path331;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path341;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path411;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path421;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path431;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path441;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}

				if (message2 != "")
				{
					//Four two
					if (GUI.Button (new Rect (btnX - 275, btnY + 285, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path2;
							}
							
							else if (talk.path == 1) {
								talk.path = path12;
							}
							
							else if (talk.path == 2) {
								talk.path = path22;
							}
							
							else if (talk.path == 3) {
								talk.path = path32;
							}
							
							else if (talk.path == 4) {
								talk.path = path42;
							}
							
							else if (talk.path == 11) {
								talk.path = path112;
							}
							
							else if (talk.path == 12) {
								talk.path = path122;
							}
							
							else if (talk.path == 13) {
								talk.path = path132;
							}
							
							else if (talk.path == 14) {
								talk.path = path142;
							}
							
							else if (talk.path == 21) {
								talk.path = path212;
							}
							
							else if (talk.path == 22) {
								talk.path = path222;
							}
							
							else if (talk.path == 23) {
								talk.path = path232;
							}
							
							else if (talk.path == 24) {
								talk.path = path242;
							}
							
							else if (talk.path == 31) {
								talk.path = path312;
							}
							
							else if (talk.path == 32) {
								talk.path = path322;
							}
							
							else if (talk.path == 33) {
								talk.path = path332;
							}
							
							else if (talk.path == 34) {
								talk.path = path342;
							}
							
							else if (talk.path == 41) {
								talk.path = path412;
							}
							
							else if (talk.path == 42) {
								talk.path = path422;
							}
							
							else if (talk.path == 43) {
								talk.path = path432;
							}
							
							else if (talk.path == 44) {
								talk.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path2;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path12;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path22;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path32;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path42;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path112;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path122;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path132;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path142;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path212;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path222;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path232;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path242;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path312;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path322;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path332;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path342;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path412;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path422;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path432;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path2;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path12;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path22;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path32;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path42;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path112;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path122;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path132;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path142;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path212;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path222;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path232;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path242;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path312;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path322;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path332;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path342;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path412;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path422;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path432;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path2;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path12;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path22;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path32;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path42;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path112;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path122;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path132;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path142;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path212;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path222;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path232;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path242;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path312;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path322;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path332;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path342;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path412;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path422;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path432;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path442;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}

				if (message3 != "")
				{
					//Four three
					if (GUI.Button (new Rect (btnX + 200, btnY + 225, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path3;
							}
							
							else if (talk.path == 1) {
								talk.path = path13;
							}
							
							else if (talk.path == 2) {
								talk.path = path23;
							}
							
							else if (talk.path == 3) {
								talk.path = path33;
							}
							
							else if (talk.path == 4) {
								talk.path = path43;
							}
							
							else if (talk.path == 11) {
								talk.path = path113;
							}
							
							else if (talk.path == 12) {
								talk.path = path123;
							}
							
							else if (talk.path == 13) {
								talk.path = path133;
							}
							
							else if (talk.path == 14) {
								talk.path = path143;
							}
							
							else if (talk.path == 21) {
								talk.path = path213;
							}
							
							else if (talk.path == 22) {
								talk.path = path223;
							}
							
							else if (talk.path == 23) {
								talk.path = path233;
							}
							
							else if (talk.path == 24) {
								talk.path = path243;
							}
							
							else if (talk.path == 31) {
								talk.path = path313;
							}
							
							else if (talk.path == 32) {
								talk.path = path323;
							}
							
							else if (talk.path == 33) {
								talk.path = path333;
							}
							
							else if (talk.path == 34) {
								talk.path = path343;
							}
							
							else if (talk.path == 41) {
								talk.path = path413;
							}
							
							else if (talk.path == 42) {
								talk.path = path423;
							}
							
							else if (talk.path == 43) {
								talk.path = path433;
							}
							
							else if (talk.path == 44) {
								talk.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path3;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path13;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path23;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path33;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path43;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path113;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path123;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path133;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path143;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path213;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path223;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path233;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path243;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path313;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path323;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path333;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path343;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path413;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path423;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path433;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path3;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path13;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path23;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path33;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path43;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path113;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path123;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path133;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path143;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path213;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path223;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path233;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path243;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path313;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path323;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path333;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path343;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path413;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path423;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path433;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path3;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path13;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path23;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path33;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path43;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path113;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path123;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path133;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path143;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path213;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path223;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path233;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path243;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path313;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path323;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path333;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path343;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path413;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path423;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path433;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path443;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}

				if (message4 != "")
				{
					//Four four
					if (GUI.Button (new Rect (btnX + 275, btnY + 285, btnW, btnH), ""))
					{
						if (Event.current.button == 1 || Event.current.button == 2)
						{
							
						}
						
						else

						if (williamTalk)
						{
							talk.hasDisplayed = false;
							talk.talkSection++;
							
							if (talk.path == 0) {
								talk.path = path4;
							}
							
							else if (talk.path == 1) {
								talk.path = path14;
							}
							
							else if (talk.path == 2) {
								talk.path = path24;
							}
							
							else if (talk.path == 3) {
								talk.path = path34;
							}
							
							else if (talk.path == 4) {
								talk.path = path44;
							}
							
							else if (talk.path == 11) {
								talk.path = path114;
							}
							
							else if (talk.path == 12) {
								talk.path = path124;
							}
							
							else if (talk.path == 13) {
								talk.path = path134;
							}
							
							else if (talk.path == 14) {
								talk.path = path144;
							}
							
							else if (talk.path == 21) {
								talk.path = path214;
							}
							
							else if (talk.path == 22) {
								talk.path = path224;
							}
							
							else if (talk.path == 23) {
								talk.path = path234;
							}
							
							else if (talk.path == 24) {
								talk.path = path244;
							}
							
							else if (talk.path == 31) {
								talk.path = path314;
							}
							
							else if (talk.path == 32) {
								talk.path = path324;
							}
							
							else if (talk.path == 33) {
								talk.path = path334;
							}
							
							else if (talk.path == 34) {
								talk.path = path344;
							}
							
							else if (talk.path == 41) {
								talk.path = path414;
							}
							
							else if (talk.path == 42) {
								talk.path = path424;
							}
							
							else if (talk.path == 43) {
								talk.path = path434;
							}
							
							else if (talk.path == 44) {
								talk.path = path444;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (mariaTalk)
						{
							talk2.hasDisplayed = false;
							talk2.talkSection++;
							
							if (talk2.path == 0) {
								talk2.path = path4;
							}
							
							else if (talk2.path == 1) {
								talk2.path = path14;
							}
							
							else if (talk2.path == 2) {
								talk2.path = path24;
							}
							
							else if (talk2.path == 3) {
								talk2.path = path34;
							}
							
							else if (talk2.path == 4) {
								talk2.path = path44;
							}
							
							else if (talk2.path == 11) {
								talk2.path = path114;
							}
							
							else if (talk2.path == 12) {
								talk2.path = path124;
							}
							
							else if (talk2.path == 13) {
								talk2.path = path134;
							}
							
							else if (talk2.path == 14) {
								talk2.path = path144;
							}
							
							else if (talk2.path == 21) {
								talk2.path = path214;
							}
							
							else if (talk2.path == 22) {
								talk2.path = path224;
							}
							
							else if (talk2.path == 23) {
								talk2.path = path234;
							}
							
							else if (talk2.path == 24) {
								talk2.path = path244;
							}
							
							else if (talk2.path == 31) {
								talk2.path = path314;
							}
							
							else if (talk2.path == 32) {
								talk2.path = path324;
							}
							
							else if (talk2.path == 33) {
								talk2.path = path334;
							}
							
							else if (talk2.path == 34) {
								talk2.path = path344;
							}
							
							else if (talk2.path == 41) {
								talk2.path = path414;
							}
							
							else if (talk2.path == 42) {
								talk2.path = path424;
							}
							
							else if (talk2.path == 43) {
								talk2.path = path434;
							}
							
							else if (talk2.path == 44) {
								talk2.path = path444;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (richardTalk)
						{
							talk3.hasDisplayed = false;
							talk3.talkSection++;
							
							if (talk3.path == 0) {
								talk3.path = path4;
							}
							
							else if (talk3.path == 1) {
								talk3.path = path14;
							}
							
							else if (talk3.path == 2) {
								talk3.path = path24;
							}
							
							else if (talk3.path == 3) {
								talk3.path = path34;
							}
							
							else if (talk3.path == 4) {
								talk3.path = path44;
							}
							
							else if (talk3.path == 11) {
								talk3.path = path114;
							}
							
							else if (talk3.path == 12) {
								talk3.path = path124;
							}
							
							else if (talk3.path == 13) {
								talk3.path = path134;
							}
							
							else if (talk3.path == 14) {
								talk3.path = path144;
							}
							
							else if (talk3.path == 21) {
								talk3.path = path214;
							}
							
							else if (talk3.path == 22) {
								talk3.path = path224;
							}
							
							else if (talk3.path == 23) {
								talk3.path = path234;
							}
							
							else if (talk3.path == 24) {
								talk3.path = path244;
							}
							
							else if (talk3.path == 31) {
								talk3.path = path314;
							}
							
							else if (talk3.path == 32) {
								talk3.path = path324;
							}
							
							else if (talk3.path == 33) {
								talk3.path = path334;
							}
							
							else if (talk3.path == 34) {
								talk3.path = path344;
							}
							
							else if (talk3.path == 41) {
								talk3.path = path414;
							}
							
							else if (talk3.path == 42) {
								talk3.path = path424;
							}
							
							else if (talk3.path == 43) {
								talk3.path = path434;
							}
							
							else if (talk3.path == 44) {
								talk3.path = path444;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
						
						else if (irmaTalk)
						{
							talk4.hasDisplayed = false;
							talk4.talkSection++;
							
							if (talk4.path == 0) {
								talk4.path = path4;
							}
							
							else if (talk4.path == 1) {
								talk4.path = path14;
							}
							
							else if (talk4.path == 2) {
								talk4.path = path24;
							}
							
							else if (talk4.path == 3) {
								talk4.path = path34;
							}
							
							else if (talk4.path == 4) {
								talk4.path = path44;
							}
							
							else if (talk4.path == 11) {
								talk4.path = path114;
							}
							
							else if (talk4.path == 12) {
								talk4.path = path124;
							}
							
							else if (talk4.path == 13) {
								talk4.path = path134;
							}
							
							else if (talk4.path == 14) {
								talk4.path = path144;
							}
							
							else if (talk4.path == 21) {
								talk4.path = path214;
							}
							
							else if (talk4.path == 22) {
								talk4.path = path224;
							}
							
							else if (talk4.path == 23) {
								talk4.path = path234;
							}
							
							else if (talk4.path == 24) {
								talk4.path = path244;
							}
							
							else if (talk4.path == 31) {
								talk4.path = path314;
							}
							
							else if (talk4.path == 32) {
								talk4.path = path324;
							}
							
							else if (talk4.path == 33) {
								talk4.path = path334;
							}
							
							else if (talk4.path == 34) {
								talk4.path = path344;
							}
							
							else if (talk4.path == 41) {
								talk4.path = path414;
							}
							
							else if (talk4.path == 42) {
								talk4.path = path424;
							}
							
							else if (talk4.path == 43) {
								talk4.path = path434;
							}
							
							else if (talk4.path == 44) {
								talk4.path = path444;
							}
							
							//canClick = false;
							
							fourDecision1.enabled = false;
							fourDecision2.enabled = false;
							fourDecision3.enabled = false;
							fourDecision4.enabled = false;
							
							displayingOne 	= false;
							displayingTwo 	= false;
							displayingThree = false;
							displayingFour 	= false;
						}
					}
				}
			}
		}
	}
}