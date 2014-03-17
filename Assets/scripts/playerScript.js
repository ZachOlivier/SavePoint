#pragma strict

var isIdle												: boolean = false;
var isWalking											: boolean = false;
var isRunning											: boolean = false;
var isStealth											: boolean = false;
var isJump												: boolean = false;


function Start () {

}

function Update () {
	var movement : CharacterMotor = gameObject.GetComponent(CharacterMotor);

	if (movement.movement.velocity.magnitude == 0.0) {
		isIdle 		= true;
		isWalking	= false;
		isRunning 	= false;
		isJump 		= false;
		isStealth	= false;
	}

	else if (movement.movement.velocity.magnitude > 1.0 && movement.movement.velocity.magnitude <= 9.0 && movement.grounded != false && !isStealth) {
		isIdle 		= false;
		isWalking 	= true;
		isRunning 	= false;
		isJump 		= false;
		isStealth	= false;
	}
	
	else if (movement.movement.velocity.magnitude > 9.0 && movement.grounded != false) {
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= true;
		isJump 		= false;
		isStealth	= false;
	}
	
	else if (movement.grounded == false) {
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= false;
		isJump 		= true;
		isStealth	= false;
	}

	
	if (Input.GetButton("Sprint")) {
		movement.movement.maxForwardSpeed 		= 15.0;
		movement.movement.maxSidewaysSpeed 		= 15.0;
		movement.movement.maxBackwardsSpeed		= 5.0;
	}
	
	if (Input.GetButton("Stealth")) {
		movement.movement.maxForwardSpeed 		= 3.0;
		movement.movement.maxSidewaysSpeed 		= 3.0;
		movement.movement.maxBackwardsSpeed 	= 2.0;
		
		isStealth	= true;
		isIdle 		= false;
		isWalking 	= false;
		isRunning 	= false;
		isJump 		= false;
	}
	
	else if (Input.GetButtonUp("Sprint")) {
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
	}
	
	else if (Input.GetButtonUp("Stealth")) {
		movement.movement.maxForwardSpeed 		= 6.0;
		movement.movement.maxSidewaysSpeed 		= 6.0;
		movement.movement.maxBackwardsSpeed		= 2.0;
	
		isStealth = false;
	}
}