using UnityEngine;
using System.Collections;

public class uiSystem : MonoBehaviour {

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

	public GameObject decide1Box;
	public GameObject decide2Box;
	public GameObject decide3Box;
	public GameObject decide4Box;

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
	public GUITexture fourDecision1Box;
	public GUITexture fourDecision2Box;
	public GUITexture fourDecision3Box;
	public GUITexture fourDecision4Box;
	public GUITexture infoBox;
	public GUITexture subtitleBox;
	public GUITexture warningBox;

	public int lineLength		= 400;
	public int numberOfLines;
	public GUIText block;
	public string[] words;
	public string result;
	public Rect TextSize;

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

		if (!fourDecision1.enabled)
		{
			fourDecision1Box.enabled = false;
		}

		if (!fourDecision2.enabled)
		{
			fourDecision2Box.enabled = false;
		}

		if (!fourDecision3.enabled)
		{
			fourDecision3Box.enabled = false;
		}

		if (!fourDecision4.enabled)
		{
			fourDecision4Box.enabled = false;
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
				fourDecision1Box.enabled = false;

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
				fourDecision1Box.enabled = false;
				fourDecision2Box.enabled = false;
				
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
				fourDecision1Box.enabled = false;
				fourDecision2Box.enabled = false;
				fourDecision3Box.enabled = false;
				
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
				fourDecision1Box.enabled = false;
				fourDecision2Box.enabled = false;
				fourDecision3Box.enabled = false;
				fourDecision4Box.enabled = false;
				
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
	public void display1Decision (string message1, float time) {

		fourDecision1.text = message1;

		Vector3 position1 = fourDecision1.transform.localPosition;
		position1.x = .5f;
		position1.y = .22f;
		fourDecision1.transform.localPosition = position1;

		Vector3 _position1 = decide1Box.transform.localPosition;
		_position1.x = 0f;
		_position1.y = -.34f;
		decide1Box.transform.localPosition = _position1;

		fourDecision1Box.pixelInset = new Rect (-185, fourDecision1Box.pixelInset.y, fourDecision1Box.pixelInset.width, fourDecision1Box.pixelInset.height);
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingOne) {
			fourDecision1.enabled = true;
			fourDecision1Box.enabled = true;
			oneDecisionBox.enabled = true;

			displayingOne = true;
		}
	}

	// This void displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
	public void display2Decision (string message1, string message2, float time) {
		fourDecision1.text = message1;
		fourDecision2.text = message2;

		Vector3 position1 = fourDecision1.transform.localPosition;
		position1.x = .44f;
		position1.y = .15f;
		fourDecision1.transform.localPosition = position1;

		Vector3 position2 = fourDecision2.transform.localPosition;
		position2.x = .56f;
		position2.y = .15f;
		fourDecision2.transform.localPosition = position2;

		Vector3 _position1 = decide1Box.transform.localPosition;
		_position1.x = -.36f;
		_position1.y = -.42f;
		decide1Box.transform.localPosition = _position1;

		Vector3 _position2 = decide2Box.transform.localPosition;
		_position2.x = .36f;
		_position2.y = -.42f;
		decide2Box.transform.localPosition = _position2;

		fourDecision1Box.pixelInset = new Rect (-365, fourDecision1Box.pixelInset.y, fourDecision1Box.pixelInset.width, fourDecision1Box.pixelInset.height);
		fourDecision2Box.pixelInset = new Rect (-5, fourDecision2Box.pixelInset.y, fourDecision2Box.pixelInset.width, fourDecision2Box.pixelInset.height);
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingTwo) {
			fourDecision1.enabled = true;
			fourDecision2.enabled = true;
			fourDecision1Box.enabled = true;
			fourDecision2Box.enabled = true;
			twoDecisionBox.enabled = true;

			displayingTwo = true;
		}
	}

	// This void displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
	public void display3Decision (string message1, string message2, string message3, float time) {
		fourDecision1.text = message1;
		fourDecision2.text = message2;
		fourDecision3.text = message3;

		Vector3 position1 = fourDecision1.transform.localPosition;
		position1.x = .5f;
		position1.y = .22f;
		fourDecision1.transform.localPosition = position1;

		Vector2 position2 = fourDecision2.transform.localPosition;
		position2.x = .44f;
		position2.y = .15f;
		fourDecision2.transform.localPosition = position2;
		
		Vector3 position3 = fourDecision3.transform.localPosition;
		position3.x = .56f;
		position3.y = .15f;
		fourDecision3.transform.localPosition = position3;

		Vector3 _position1 = decide1Box.transform.localPosition;
		_position1.x = 0f;
		_position1.y = -.34f;
		decide1Box.transform.localPosition = _position1;

		Vector3 _position2 = decide2Box.transform.localPosition;
		_position2.x = -.36f;
		_position2.y = -.42f;
		decide2Box.transform.localPosition = _position2;
		
		Vector3 _position3 = decide3Box.transform.localPosition;
		_position3.x = .36f;
		_position3.y = -.42f;
		decide3Box.transform.localPosition = _position3;
		
		fourDecision1Box.pixelInset = new Rect (-185, fourDecision1Box.pixelInset.y, fourDecision1Box.pixelInset.width, fourDecision1Box.pixelInset.height);
		fourDecision2Box.pixelInset = new Rect (-365, fourDecision2Box.pixelInset.y, fourDecision2Box.pixelInset.width, fourDecision2Box.pixelInset.height);
		fourDecision3Box.pixelInset = new Rect (-5, fourDecision3Box.pixelInset.y, fourDecision3Box.pixelInset.width, fourDecision3Box.pixelInset.height);
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingThree) {
			fourDecision1.enabled = true;
			fourDecision2.enabled = true;
			fourDecision3.enabled = true;
			fourDecision1Box.enabled = true;
			fourDecision2Box.enabled = true;
			fourDecision3Box.enabled = true;
			threeDecisionBox.enabled = true;
			
			displayingThree = true;
		}
	}

	// This void displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
	public void display4Decision (string message1, string message2, string message3, string message4, float time) {
		fourDecision1.text = message1;
		fourDecision2.text = message2;
		fourDecision3.text = message3;
		fourDecision4.text = message4;

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

		Vector3 _position1 = decide1Box.transform.localPosition;
		_position1.x = -.31f;
		_position1.y = -.34f;
		decide1Box.transform.localPosition = _position1;

		Vector3 _position2 = decide2Box.transform.localPosition;
		_position2.x = -.4f;
		_position2.y = -.43f;
		decide2Box.transform.localPosition = _position2;

		Vector3 _position3 = decide3Box.transform.localPosition;
		_position3.x = .31f;
		_position3.y = -.34f;
		decide3Box.transform.localPosition = _position3;

		Vector3 _position4 = decide4Box.transform.localPosition;
		_position4.x = .4f;
		_position4.y = -.43f;
		decide4Box.transform.localPosition = _position4;
		
		fourDecision1Box.pixelInset = new Rect (-365, fourDecision1Box.pixelInset.y, fourDecision1Box.pixelInset.width, fourDecision1Box.pixelInset.height);
		fourDecision2Box.pixelInset = new Rect (-365, fourDecision2Box.pixelInset.y, fourDecision2Box.pixelInset.width, fourDecision2Box.pixelInset.height);
		fourDecision3Box.pixelInset = new Rect (-5, fourDecision3Box.pixelInset.y, fourDecision3Box.pixelInset.width, fourDecision3Box.pixelInset.height);
		fourDecision4Box.pixelInset = new Rect (-5, fourDecision4Box.pixelInset.y, fourDecision4Box.pixelInset.width, fourDecision4Box.pixelInset.height);
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!displayingFour) {
			fourDecision1.enabled = true;
			fourDecision2.enabled = true;
			fourDecision3.enabled = true;
			fourDecision4.enabled = true;
			fourDecision1Box.enabled = true;
			fourDecision2Box.enabled = true;
			fourDecision3Box.enabled = true;
			fourDecision4Box.enabled = true;
			fourDecisionBox.enabled = true;
			
			displayingFour = true;
		}
	}
	
	// This void displays a message to the player about what they currently have the mouse over
	public void displayInfo (string message, float time) {
		info.text = message;
		
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
		float b = -35.0f;

		subtitleBox.pixelInset = new Rect (-507, b, 1014, a);
		
		for( var index = 0; index < words.Length; index++)
		{
			var word = words[index].Trim();
			if (index == 0) {
				result = words[0];
				block.text = result;
			}
			
			if (index > 0 ) {
				result += " " + word;
				block.text = result;
			}
			TextSize = block.GetScreenRect();
			if (TextSize.width > lineLength)
			{
				//remover 
				result = result.Substring(0,result.Length-(word.Length));
				result += "\n" + word;
				numberOfLines += 1;
				block.text = result;
				a += 28.0f;
				b -= 28.0f;
				subtitleBox.pixelInset = new Rect (-507, b, 1014, a);
			}
		}
	}
}