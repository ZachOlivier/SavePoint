#pragma strict

var btnW												: int = 0;
var btnH												: int = 0;
var btnX												: int = 0;
var btnY												: int = 0;

// Variable to tell if the menu is open
var menuMode											: int = 0;

// Variable to tell if the menu can open or not
var canMenu												: boolean = true;

// Variables to hold the player and npc game objects so that we can access their scripts
var pc													: GameObject;
var npc													: GameObject;
var text												: GameObject;

// This function only fires once during the start of this script
function Start () {
	
}

// This function fires over and over again throughout the life of this script
function Update () {
	
	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);
	var cam : MouseLook = Camera.main.GetComponent(MouseLook);
	var talk : playerScript = pc.gameObject.GetComponent(playerScript);
	var inventory : cameraScript = this.gameObject.GetComponent(cameraScript);
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	// If the player pressed the escape key and the menu is currently not open and can change
	if (Input.GetButtonDown("Menu") && menuMode == 0 && canMenu) {
	
		// Pause the game then open the menu
		Time.timeScale = 0.0;
		menuMode = 1;
		
		//movement.enabled = false;
		
		// Make it so the player can't open the inventory or start a conversation
		inventory.canChange = false;
		talk.canTalk = false;
		
		// Make it so the camera won't move
		mouse.enabled = false;
		cam.enabled = false;
		
		// Display a message on the screen that will stay for 4 seconds
		message.displayWarning("Menu opened..", 4);
	}
	
	// Else if the player pressed the escape key and the menu is currently open and can change
	else if (Input.GetButtonDown("Menu") && menuMode == 1  && canMenu) {
		menuMode = 0;
		Time.timeScale = 1.0;
		
		//movement.enabled = true;
		
		inventory.canChange = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		message.displayWarning("Menu closed..", 4);
	}
	
	// Else if the player pressed the escape key and the menu isn't in either mode but can change
	else if (Input.GetButtonDown("Menu") && !menuMode == 0 && !menuMode == 1  && canMenu) {
		menuMode = 0;
		Time.timeScale = 1.0;
		
		//movement.enabled = true;
		
		inventory.canChange = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		message.displayWarning("Menu error!..", 4);
	}
}

function OnGUI ()
{
	if (menuMode == 1)
	{
		var inventory : cameraScript = this.gameObject.GetComponent(cameraScript);
		var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
		var cam : MouseLook = Camera.main.GetComponent(MouseLook);
	
		btnX = (Screen.width / 2) - (btnW / 2);
		btnY = (Screen.height / 2) - (btnH / 2);
		btnW = Screen.width / 5;
		btnH = Screen.height / 8;
	
		if (GUI.Button (Rect (btnX, btnY - 75, btnW, btnH), "Reset Level"))
		{
			menuMode = 0;
			Time.timeScale = 1.0;
			
			inventory.canChange = true;
			
			mouse.enabled = true;
			cam.enabled = true;
		
			Application.LoadLevel(1);
		}
		
		if (GUI.Button (Rect (btnX, btnY + 75, btnW, btnH), "Reset Game (Intro)"))
		{
			menuMode = 0;
			Time.timeScale = 1.0;
			
			inventory.canChange = true;
			
			mouse.enabled = true;
			cam.enabled = true;
		
			Application.LoadLevel(0);
		}
	}
	
	else
	{
	
	}
}