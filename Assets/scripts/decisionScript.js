#pragma strict

// Variables to tell whether the mouse is hovering over a decision box
var decisionOne											: boolean = false;
var decisionTwo											: boolean = false;
var decisionThree										: boolean = false;
var decisionFour										: boolean = false;

// Variable to tell whether the decisions can be clicked or not
var canClick											: boolean = false;

// Variables to hold the decisions the player can make
var path1												: int = 0;
var path2												: int = 1;
var path3												: int = 2;
var path4												: int = 3;

// Variable to hold the holder and npc game objects so that we can access its scripts
var npc													: GameObject;
var holder												: GameObject;
var text												: GameObject;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {
	var talk : npcBehavior = npc.gameObject.GetComponent(npcBehavior);
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (Input.GetButtonDown("Fire1") && decisionOne && this.gameObject.name == "decision1Box") {
		talk.path = path1;
		
		talk.time = 1;
		
		canClick = false;
		decisionOne = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
	
	if (Input.GetButtonDown("Fire1") && decisionTwo && this.gameObject.name == "decision2Box") {
		talk.path = path2;
		
		talk.time = 1;
		
		canClick = false;
		decisionTwo = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
	
	if (Input.GetButtonDown("Fire1") && decisionThree && this.gameObject.name == "decision3Box") {
		talk.path = path3;
		
		talk.time = 1;
		
		canClick = false;
		decisionThree = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
	
	if (Input.GetButtonDown("Fire1") && decisionFour && this.gameObject.name == "decision4Box") {
		talk.path = path4;
		
		talk.time = 1;
		
		canClick = false;
		decisionFour = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
}

function OnMouseEnter () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (this.gameObject.name == "decision1Box" && canClick) {
		message.displayInfo("Decision 1 Path", 3);
	
		decisionOne = true;
	}
	
	if (this.gameObject.name == "decision2Box" && canClick) {
		message.displayInfo("Decision 2 Path", 3);
	
		decisionTwo = true;
	}
	
	if (this.gameObject.name == "decision3Box" && canClick) {
		message.displayInfo("Decision 3 Path", 3);
	
		decisionThree = true;
	}
	
	if (this.gameObject.name == "decision4Box" && canClick) {
		message.displayInfo("Decision 4 Path", 3);
	
		decisionFour = true;
	}
}

function OnMouseExit () {
	if (this.gameObject.name == "decision1Box" && canClick) {
		decisionOne = false;
	}
	
	else if (this.gameObject.name == "decision2Box" && canClick) {
		decisionTwo = false;
	}
	
	else if (this.gameObject.name == "decision3Box" && canClick) {
		decisionThree = false;
	}
	
	else if (this.gameObject.name == "decision4Box" && canClick) {
		decisionFour = false;
	}
}