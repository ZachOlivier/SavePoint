#pragma strict

// Variable to hold which path the player is on from the decisions they've made
var pathChosen											: int = 0;

// Variables to hold which decisions the player makes
var path1												: int = 0;
var path2												: int = 1;
var path3												: int = 2;

// Variables to hold the npc game object so that we can access its scripts
var npc													: GameObject;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {
	
	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var path : npcBehavior = npc.gameObject.GetComponent(npcBehavior);
	
	// If the player chose path 1
	if (pathChosen == path1) {
		
		// Switch the level to update the time based on the path chosen
		//Application.LoadLevel(2);
	}
	
	else if (pathChosen == path2) {
		//Application.LoadLevel(2);
	}
	
	else if (pathChosen == path3) {
		//Application.LoadLevel(2);
	}
}