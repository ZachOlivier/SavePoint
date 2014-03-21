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
var path4												: int = 3;

// Variable to hold which path the player is on from the decisions they've made
var path												: int = 5;

// Variable to hold how much time has gone by in a conversation
var timer												: float = 0.0;

// Variable to hold how much time is allowed before moving on in conversation
var time												: float = 0.0;

// Variable to hold the holder and text game objects so that we can access its scripts
var holder												: GameObject;
var text												: GameObject;
var pc													: GameObject;
var decide1												: GameObject;
var decide2												: GameObject;
var decide3												: GameObject;
var decide4												: GameObject;

// This function only fires once during the start of this script
function Start () {
	path = 5;
}

// This function fires over and over again throughout the life of this script
function Update () {
	
	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var cam : cameraMode = holder.gameObject.GetComponent(cameraMode);
	var chosen : timeChanger = holder.gameObject.GetComponent(timeChanger);
	var menu : menuScript = holder.gameObject.GetComponent(menuScript);
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var look : MouseLook = Camera.main.GetComponent(MouseLook);
	var dec1 : decisionScript = decide1.gameObject.GetComponent(decisionScript);
	var dec2 : decisionScript = decide2.gameObject.GetComponent(decisionScript);
	var dec3 : decisionScript = decide3.gameObject.GetComponent(decisionScript);
	var dec4 : decisionScript = decide4.gameObject.GetComponent(decisionScript);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);

	// If the player pressed the E key and the NPC can talk, and the game isn't paused
	if (Input.GetButtonDown("Talk") && canTalk && cam.cameraMode == 0) {
	
		// Make it so the NPC can't talk again and the game can't pause
		canTalk = false;
		cam.canChange = false;
		menu.canMenu = false;
		
		look.enabled = false;
		mouse.enabled = false;
		
		movement.enabled = false;
		
		// Make sure the conversation starts at the beginning
		talkSection = 0;
		
		// Set the first allowed amount of time for that section of the conversation
		time = .5;
		
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
		
		look.enabled = true;
		mouse.enabled = true;
		
		movement.enabled = true;
		
		message.displayWarning("Can't talk right now..", 4);
	}
	
	if (isTalking) {
		timer += Time.deltaTime;
	
		if (timer > time && talkSection == 0) {
			TalkInitiated("Hello there, Greg (Example)", 10);
			
			message.displayDecision("Hello Security Guard", "Who are you?", "Who am I?", "*Ignore*", 10);
			dec1.canClick = true;
			dec2.canClick = true;
			dec3.canClick = true;
			dec4.canClick = true;
		}
		
		if (timer > time && talkSection == 1 && path == path1) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			TalkInitiated("You forgot my name?", 4);
		}
		
		else if (timer > time && talkSection == 1 && path == path2) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			TalkInitiated("You forgot who I am?", 4);
		}
		
		else if (timer > time && talkSection == 1 && path == path3) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			TalkInitiated("What? You're Greg!", 4);
		}
		
		else if (timer > time && talkSection == 1 && path == path4) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			TalkInitiated("Mmmmmmmmmkay..", 4);
		}
		
		if (timer > time && talkSection == 2 && path == path1) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			canTalk = true;
			isTalking = false;
		
			cam.canChange = true;
			menu.canMenu = true;
		
			look.enabled = true;
			mouse.enabled = true;
		
			movement.enabled = true;
			
			TalkInitiated("Whatever..", 4);
		}
		
		else if (timer > time && talkSection == 2 && path == path2) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			canTalk = true;
			isTalking = false;
		
			cam.canChange = true;
			menu.canMenu = true;
		
			look.enabled = true;
			mouse.enabled = true;
		
			movement.enabled = true;
			
			TalkInitiated("Screw you man..", 4);
		}
		
		else if (timer > time && talkSection == 2 && path == path3) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			canTalk = true;
			isTalking = false;
		
			cam.canChange = true;
			menu.canMenu = true;
		
			look.enabled = true;
			mouse.enabled = true;
		
			movement.enabled = true;
			
			TalkInitiated("You feeling okay?", 4);
		}
		
		else if (timer > time && talkSection == 2 && path == path4) {
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;
			
			canTalk = true;
			isTalking = false;
		
			cam.canChange = true;
			menu.canMenu = true;
		
			look.enabled = true;
			mouse.enabled = true;
		
			movement.enabled = true;
			
			TalkInitiated("... Bye", 4);
		}
		
		/*else if (timer > time && talkSection == 2) {
			print(path);
		
			if (path == path1) {
				TalkInitiated("Whatever..", 4);
			}
			
			if (path == path2) {
				TalkInitiated("Screw you man..", 4);
			}
			
			if (path == path3) {
				TalkInitiated("You feeling okay?", 4);
			}
			
			if (path == path4) {
				TalkInitiated("... Bye", 4);
			}
		}*/
	}
}

// This function tells whether another collider has entered a game object's collider attached to this script
function OnTriggerEnter (other : Collider) {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	//var player : playerScript = gameObject.GetComponent(playerScript);

	// If the player enters the talk zone
	if (other.gameObject.tag == "Player") {
	
		// Set can talk to true, this lets the player be able to use the E key to start a conversation
		canTalk = true;
		
		message.displayInfo("Security Guard", 4);
	}
}

// This function tells whether another collider has exited a game object's collider attached to this script
function OnTriggerExit (other : Collider) {

	//var player : playerScript = gameObject.GetComponent(playerScript);
	var cam : cameraMode = holder.gameObject.GetComponent(cameraMode);
	var menu : menuScript = holder.gameObject.GetComponent(menuScript);
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var look : MouseLook = Camera.main.GetComponent(MouseLook);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);

	// If the player exits the talk zone
	if (other.gameObject.tag == "Player") {
	
		// Set can talk to false and end the conversation
		canTalk = false;
		isTalking = false;
		
		cam.canChange = true;
		menu.canMenu = true;
		
		look.enabled = true;
		mouse.enabled = true;
		
		movement.enabled = true;
	}
}

function TalkInitiated (subtitle : String, setTime : int) {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	
	timer = 0.0;
	time = setTime;
	talkSection++;
	message.displaySubtitle(subtitle, setTime);
}