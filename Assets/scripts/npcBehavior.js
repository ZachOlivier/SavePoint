#pragma strict

// Variables to tell if the NPC can talk, or is talking
var canTalk												: boolean = false;
var isTalking											: boolean = false;

// Variable to hold the current part of the conversation
var talkSection											: int = 0;

// Variables to hold the decisions the player can make
var path1												: int = 0;
var path2												: int = 1;
var path3												: int = 2;

// Variable to hold which path the player is on from the decisions they've made
var path												: int = 0;

// Variable to hold how much time has gone by in a conversation
var timer												: float = 0.0;

// Variable to hold how much time is allowed before moving on in conversation
var time												: float = 0.0;

// Variable to hold the holder and text game objects so that we can access its scripts
var holder												: GameObject;
var text												: GameObject;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {
	
	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var cam : cameraMode = holder.gameObject.GetComponent(cameraMode);
	var chosen : timeChanger = holder.gameObject.GetComponent(timeChanger);
	var menu : menuScript = holder.gameObject.GetComponent(menuScript);
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	// If the player pressed the E key and the NPC can talk, and the game isn't paused
	if (Input.GetButtonDown("Talk") && canTalk && cam.cameraMode == 0) {
	
		// Make it so the NPC can't talk again and the game can't pause
		canTalk = false;
		cam.canChange = false;
		menu.canMenu = false;
		
		// Make sure the conversation starts at the beginning
		talkSection = 0;
		
		// Set the first allowed amount of time for that section of the conversation
		time = .3;
		
		// Set the NPC to currently talking
		isTalking = true;
		
		// Display a message on the screen that will stay for 4 seconds
		message.displayWarning("Conversation started..", 4);
		
		//Time.timeScale = 0.0;
	}
	
	// Else if the player pressed the E key and the NPC can't talk, and the game isn't paused
	else if (Input.GetButtonDown("Talk") && !canTalk && cam.cameraMode == 0) {
		//Time.timeScale = 1.0;
		
		// Let the player know they can't talk right now and let the game be able to pause
		cam.canChange = true;
		menu.canMenu = true;
		
		message.displayWarning("Can't talk right now..", 4);
	}
	
	if (isTalking) {
		timer += Time.deltaTime;
	
		if (timer > time && talkSection == 0) {
			TalkInitiated("Hello there, Greg (Example)", 10);
			
			message.displayDecision("Hello Security Guard", "Who are you?", "Who am I?", "*Ignore*", 10);
		}
		
		else if (timer > time && talkSection == 1) {
			
		}
		
		else if (timer > time && talkSection == 2) {
			
		}
		
		/*else if (timer > time && talkSection == 3) {
			
		}
		
		else if (timer > time && talkSection == 4) {
			
		}
		
		else if (talkSection == 5) {
			//TalkInitiated();
			
			//chosen.pathChosen = path1;
		}*/
		
		else if (talkSection == 1 && path == path1) {
			
		}
	}
}

// This function tells whether another collider has entered a game object's collider attached to this script
function OnTriggerEnter (other : Collider) {

	//var player : playerScript = gameObject.GetComponent(playerScript);

	// If the player enters the talk zone
	if (other.gameObject.tag == "Player") {
	
		// Set can talk to true, this lets the player be able to use the E key to start a conversation
		canTalk = true;
	}
}

// This function tells whether another collider has exited a game object's collider attached to this script
function OnTriggerExit (other : Collider) {

	//var player : playerScript = gameObject.GetComponent(playerScript);
	var cam : cameraMode = holder.gameObject.GetComponent(cameraMode);
	var menu : menuScript = holder.gameObject.GetComponent(menuScript);

	// If the player exits the talk zone
	if (other.gameObject.tag == "Player") {
	
		// Set can talk to false and end the conversation
		canTalk = false;
		isTalking = false;
		
		cam.canChange = true;
		menu.canMenu = true;
	}
}

function TalkInitiated (subtitle : String, setTime : int) {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	
	talkSection++;
	timer = 0.0;
	time = setTime;
	message.displaySubtitle(subtitle, setTime);
}