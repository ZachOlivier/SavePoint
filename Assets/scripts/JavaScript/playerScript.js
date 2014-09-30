#pragma strict

var walkSound											: AudioClip;
var runSound											: AudioClip;

var health												: int = 5;

// Variables to tell what the player is currently doing
var isIdle												: boolean = false;
var isWalking											: boolean = false;
var isRunning											: boolean = false;
var isStealth											: boolean = false;
var isJump												: boolean = false;

var canTalk												: boolean = false;

var canSound											: boolean = true;

// This function only fires once during the start of this script
function Start () {
	audio.clip = walkSound;
	audio.loop = true;
	
	health = 5;
}

// This function fires over and over again throughout the life of this script
function Update () {

	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var movement : CharacterMotor = gameObject.GetComponent(CharacterMotor);
	
	if (!movement.enabled && audio.isPlaying) {
		audio.Stop();
	}
	
	if (Input.GetKey (KeyCode.W) && canSound) {
		if (!audio.isPlaying) {
			audio.Play();
		}
	}
	
	if (Input.GetKey (KeyCode.D) && canSound) {
		if (!audio.isPlaying) {
			audio.Play();
		}
	}
		
	if (Input.GetKey (KeyCode.A) && canSound) {
		if (!audio.isPlaying) {
			audio.Play();
		}
	}
	
	if (Input.GetKey (KeyCode.S) && canSound) {
		if (!audio.isPlaying) {
			audio.Play();
		}
	}
	
	if (Input.GetKeyUp (KeyCode.W)) {
		audio.Stop();
	}
	
	if (Input.GetKeyUp (KeyCode.D)) {
		audio.Stop();
	}
	
	if (Input.GetKeyUp (KeyCode.A)) {
		audio.Stop();
	}
	
	if (Input.GetKeyUp (KeyCode.S)) {
		audio.Stop();
	}
	
	else if (!canSound) {
		audio.Stop();
	}

	// If the player isn't moving
	if (movement.movement.velocity.magnitude == 0.0 && movement.grounded != false) {
	
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
		
		canSound = true;
	}
	
	// Else if the player is moving fast and isn't jumping
	else if (movement.movement.velocity.magnitude > 9.0 && movement.grounded != false) {
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= true;
		isJump 		= false;
		isStealth	= false;
		
		canSound = true;
	}
	
	// Else if the player is jumping and isn't stealthed
	else if (movement.grounded == false) {
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= false;
		isJump 		= true;
		isStealth	= false;
		
		canSound = false;
	}
	
	// If the player is holding the shift key
	if (Input.GetButton("Sprint")) {
		movement.movement.maxForwardSpeed 		= 15.0;
		movement.movement.maxSidewaysSpeed 		= 12.0;
		movement.movement.maxBackwardsSpeed		= 5.0;
		
		audio.clip = runSound;
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
		
		canSound = false;
	}
	
	// Else if the player let go of the shift key
	else if (Input.GetButtonUp("Sprint")) {
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
		
		audio.clip = walkSound;
	}
	
	// Else if the player pressed the stealth key and he was currently stealthed
	else if (Input.GetButtonDown("Stealth") && isStealth) {
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
	
		isStealth = false;
		
		canSound = true;
	}
	
	if (isJump) {
		movement.movement.maxForwardSpeed 		= 0.0;
		movement.movement.maxSidewaysSpeed 		= 0.0;
		movement.movement.maxBackwardsSpeed		= 0.0;
	}
	
	if (movement.grounded != false && movement.movement.maxForwardSpeed == 0.0) {
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
	}
}

@script RequireComponent(AudioSource)