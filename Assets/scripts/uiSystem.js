#pragma strict

// Variables to hold the amount of time that has passed by since the text started being visible
var warningTimer										: float = 0.0;
var subtitleTimer										: float = 0.0;
var decisionTimer										: float = 0.0;
var infoTimer											: float = 0.0;

// Variables to hold how long the text should be shown for
var warningTime											: float = 0.0;
var subtitleTime										: float = 0.0;
var decisionTime										: float = 0.0;
var infoTime											: float = 0.0;

// Variables to hold the guiTexts so that we can access their scripts
var decision1											: GUIText;
var decision2											: GUIText;
var decision3											: GUIText;
var decision4											: GUIText;
var info												: GUIText;
var subtitle											: GUIText;
var warning												: GUIText;

var decision1Box										: GUITexture;
var decision2Box										: GUITexture;
var decision3Box										: GUITexture;
var decision4Box										: GUITexture;
var infoBox												: GUITexture;
var subtitleBox											: GUITexture;
var warningBox											: GUITexture;



// This function only fires once during the start of this script
function Start () {
	
}

// This function fires over and over again throughout the life of this script
function Update () {

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
	if (warning.enabled && warningTime != 0.0) {
	
		// Start the timer for how long the text will be shown
		warningTimer += Time.deltaTime;
		
		// If the set time has passed
		if (warningTimer > warningTime) {
		
			// Disable the text, clearing it from the screen
			warning.enabled = false;
			warningBox.enabled = false;
		
			// Reset the timer
			warningTimer = 0.0;
		}
	}
	
	if (subtitle.enabled && subtitleTime != 0.0) {
		subtitleTimer += Time.deltaTime;
		
		if (subtitleTimer > subtitleTime) {
			subtitle.enabled = false;
			//subtitleBox.enabled = false;
		
			subtitleTimer = 0.0;
		}
	}
	
	if (decision1.enabled && decisionTime != 0.0) {
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
		
			decisionTimer = 0.0;
		}
	}
	
	if (info.enabled && infoTime != 0.0) {
		infoTimer += Time.deltaTime;
		
		if (infoTimer > infoTime) {
			info.enabled = false;
			infoBox.enabled = false;
		
			infoTimer = 0.0;
		}
	}
}

// This function displays error messages to the player in red text, it requires the text and a time to be called
function displayWarning (message : String, time : float) {

	// Set the text
	warning.text = message;
	
	// Set the amount of time that the text will be shown for
	warningTime = time;
	
	// Make sure the timer is reset
	warningTimer = 0.0;
	
	// If the text isnt already enabled
	if (!warning.enabled) {
		warning.enabled = true;
		warningBox.enabled = true;
	}
}

// This function displays subtitles at the bottom of the screen in white text
function displaySubtitle (message : String, time : float) {
	subtitle.text = message;
	
	subtitleTime = time;
	
	subtitleTimer = 0.0;
	
	if (!subtitle.enabled) {
		subtitle.enabled = true;
		//subtitleBox.enabled = true;
	}
}

// This function displays the last subtitle in gray text at the bottom of the screen, and decisions the player can make in white text below the subtitle
function displayDecision (message1 : String, message2 : String, message3 : String, message4 : String, time : float) {
	decision1.text = message1;
	decision2.text = message2;
	decision3.text = message3;
	decision4.text = message4;
	
	decisionTime = time;
	
	decisionTimer = 0.0;
	
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

// This function displays a message to the player about what they currently have the mouse over
function displayInfo (message : String, time : float) {
	info.text = message;
	
	infoTime = time;
	
	infoTimer = 0.0;
	
	if (!info.enabled) {
		info.enabled = true;
		infoBox.enabled = true;
	}
}