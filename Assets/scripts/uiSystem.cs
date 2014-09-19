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

	// Variables to hold the guiTexts so that we can access their scripts
	public GUIText decision1;
	public GUIText decision2;
	public GUIText decision3;
	public GUIText decision4;
	public GUIText info;
	public GUIText subtitle;
	public GUIText warning;

	public GUITexture decision1Box;
	public GUITexture decision2Box;
	public GUITexture decision3Box;
	public GUITexture decision4Box;
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
		
		if (!decision1.enabled)
		{
			decision1Box.enabled = false;
		}
		
		if (!decision2.enabled)
		{
			decision2Box.enabled = false;
		}
		
		if (!decision3.enabled)
		{
			decision3Box.enabled = false;
		}
		
		if (!decision4.enabled)
		{
			decision4Box.enabled = false;
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
		
		if (decision1.enabled && decisionTime != 0.0f) {
			decisionTimer += Time.deltaTime;
			
			if (decisionTimer > decisionTime) {
				decision1.enabled = false;
				decision2.enabled = false;
				decision3.enabled = false;
				decision4.enabled = false;
				
				decision1Box.enabled = false;
				decision2Box.enabled = false;
				decision3Box.enabled = false;
				decision4Box.enabled = false;
				
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
	public void displayDecision (string message1, string message2, string message3, string message4, float time) {
		decision1.text = message1;
		decision2.text = message2;
		decision3.text = message3;
		decision4.text = message4;
		
		decisionTime = time;
		
		decisionTimer = 0.0f;
		
		if (!decision1.enabled) {
			decision1.enabled = true;
			decision1Box.enabled = true;
		}
		
		if (!decision2.enabled) {
			decision2.enabled = true;
			decision2Box.enabled = true;
		}
		
		if (!decision3.enabled) {
			decision3.enabled = true;
			decision3Box.enabled = true;
		}
		
		if (!decision4.enabled) {
			decision4.enabled = true;
			decision4Box.enabled = true;
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

		float a = 70.0f;
		float b = 10.0f;

		subtitleBox.pixelInset = new Rect (-550, b, 1095, a);
		
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
				a += 30.0f;
				b -= 30.0f;
				subtitleBox.pixelInset = new Rect (-550, b, 1095, a);
			}
		}
	}
}