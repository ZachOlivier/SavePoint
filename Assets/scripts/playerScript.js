#pragma strict

// Variables to tell what the player is currently doing
var isIdle												: boolean = false;
var isWalking											: boolean = false;
var isRunning											: boolean = false;
var isStealth											: boolean = false;
var isJump												: boolean = false;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {

	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var movement : CharacterMotor = gameObject.GetComponent(CharacterMotor);

	// If the player isn't moving
	if (movement.movement.velocity.magnitude == 0.0) {
	
		// Set idle to true, and everything else to false
		isIdle 		= true;
		isWalking	= false;
		isRunning 	= false;
		isJump 		= false;
		isStealth	= false;
	}

	// Else if the player is moving slow and isn't jumping or stealthed
	else if (movement.movement.velocity.magnitude > 1.0 && movement.movement.velocity.magnitude <= 9.0 && movement.grounded != false && !isStealth) {
		isIdle 		= false;
		isWalking 	= true;
		isRunning 	= false;
		isJump 		= false;
		isStealth	= false;
	}
	
	// Else if the player is moving fast and isn't jumping
	else if (movement.movement.velocity.magnitude > 9.0 && movement.grounded != false) {
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= true;
		isJump 		= false;
		isStealth	= false;
	}
	
	// Else if the player is jumping and isn't stealthed
	else if (movement.grounded == false && !isStealth) {
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= false;
		isJump 		= true;
		isStealth	= false;
	}
	
	// Else if the player is jumping and is stealthed
	else if (movement.grounded == false && isStealth) {
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= false;
		isJump 		= true;
		isStealth	= false;
		
		// Set the player's movement speed to normal speed
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
	}
	
	// If the player is holding the shift key
	if (Input.GetButton("Sprint")) {
		movement.movement.maxForwardSpeed 		= 15.0;
		movement.movement.maxSidewaysSpeed 		= 12.0;
		movement.movement.maxBackwardsSpeed		= 5.0;
	}
	
	// If the player pressed the stealth key and he wasn't currently stealthed
	if (Input.GetButtonDown("Stealth") && !isStealth) {
		movement.movement.maxForwardSpeed 		= 3.0;
		movement.movement.maxSidewaysSpeed 		= 3.0;
		movement.movement.maxBackwardsSpeed 	= 2.0;
		
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= false;
		isJump 		= false;
		isStealth	= true;
	}
	
	// Else if the player let go of the shift key
	else if (Input.GetButtonUp("Sprint")) {
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
	}
	
	// Else if the player pressed the stealth key and he was currently stealthed
	else if (Input.GetButtonDown("Stealth") && isStealth) {
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
	
		isStealth = false;
	}
}