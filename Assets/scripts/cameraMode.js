#pragma strict

// Variable to tell which mode the camera is in
var cameraMode											: int = 0;

// Variable to tell whether the camera mode can switch or not
var canChange											: boolean = true;

// Variables to hold the player and npc game objects so that we can access their scripts
var pc													: GameObject;
var npc													: GameObject;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {
	
	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);
	var cam : MouseLook = Camera.main.GetComponent(MouseLook);
	var talk : npcBehavior = npc.gameObject.GetComponent(npcBehavior);
	var menu : menuScript = this.gameObject.GetComponent(menuScript);

	// If the player pressed the tab key and the camera is currently in normal mode and can change
	if (Input.GetButtonDown("Camera") && cameraMode == 0 && canChange) {
	
		// Switch the camera mode to inventory mode
		cameraMode = 1;
		//Time.timeScale = 0.0;
		
		// Make it so the player can't move
		movement.enabled = false;
		
		// Make it so the player can't open the menu or start a conversation
		menu.canMenu = false;
		talk.canTalk = false;
		
		// Make it so the camera won't move
		mouse.enabled = false;
		cam.enabled = false;
		
		print("Inventory Mode");
	}
	
	// Else if the player pressed the tab key and the camera is currently in inventory mode and can change
	else if (Input.GetButtonDown("Camera") && cameraMode == 1  && canChange) {
		cameraMode = 0;
		//Time.timeScale = 1.0;
		
		movement.enabled = true;
		
		menu.canMenu = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Normal Mode");
	}
	
	// Else if the player pressed the tab key and the camera isn't in either mode but can change
	else if (Input.GetButtonDown("Camera") && !cameraMode == 0 && !cameraMode == 1  && canChange) {
		cameraMode = 0;
		//Time.timeScale = 1.0;
		
		movement.enabled = true;
		
		menu.canMenu = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Camera Mode Error");
	}
}