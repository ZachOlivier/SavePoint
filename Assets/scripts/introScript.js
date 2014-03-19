#pragma strict

// Variables for holding time and what part the intro scene is at in order to let player skip if desired
var timer												: int = 0;
var part												: int = 0;

// Variables for holding the text game objects, we want to be able to manipulate their position
var savePoint											: GameObject;
var episodeText											: GameObject;

// This function only fires once during the start of this script
function Start () {

	// Make sure that whenever the intro scene is played, it starts at the beginning
	part = 0;

	// This sets the first timer for the first part of the scene, this timer is currently 2 seconds long
	timer = Time.time + 2;
}

// This function fires over and over again throughout the life of this script
function Update () {

	// After the time set above passes by, if it was playing part 1
	if (Time.time > timer && part == 0) {
	
		// Move the Save Point text so that it can be seen on the camera
		savePoint.transform.position.z = -4;
		
		// Make sure the next scene is played
		part = 1;
		
		// Give the next scene a timer, currently set to 4 seconds
		timer = Time.time + 4;
	}
	
	if (Time.time > timer && part == 1) {
	
		// Destroy the Save Point text game object, we don't need it anymore
		Destroy(savePoint.gameObject);
	
		part = 2;
		
		timer = Time.time + 2;
	}
	
	if (Time.time > timer && part == 2) {
	
		// Move the Episode text so that it can be seen on the camera
		episodeText.transform.position.z = 8;
		
		part = 3;
		
		timer = Time.time + 6;
	}
	
	if (Time.time > timer && part == 3) {
	
		// Destroy the Episode text game object, we don't need it anymore
		Destroy(episodeText.gameObject);
		
		part = 4;
		
		timer = Time.time + 2;
	}
	
	// After the last scene has played
	if (Time.time > timer && part == 4) {
	
		// Load the next level, currently set to the game level 1 (Prototype)
		Application.LoadLevel(1);
	}
}