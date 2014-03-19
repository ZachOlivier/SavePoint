#pragma strict

// Variables for holding the different states the enemy can be in
var IDLE												: int = 0;
var WANDERING											: int = 1;
var AWARE												: int = 2;
var CHASING												: int = 4;
var LOST												: int = 5;

// Variable for holding the enemy's time for being aware
var timeAware											: int = 0;

// Variables for holding the enemy and player game objects, we need these to access their scripts
var Enemy												: GameObject;
var PC													: GameObject;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {

}

// This function tells whether another collider has collided with a game object's collider attached to this script
function OnTriggerEnter (other : Collider) {

	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var enemy  : enemyBehavior = Enemy.gameObject.GetComponent(enemyBehavior);
	var player : playerScript = PC.gameObject.GetComponent(playerScript);

	// If the collider was the player, and it entered zone 1
	if (this.gameObject.name == "zone1" && other.gameObject.tag == "Player") {
	
		// If the player is currently running
		if (player.isRunning == true) {
		
			// If the enemy's state is currently chasing
			if (enemy.state == CHASING) {
				// We need this in here to have the enemy not change states if it is already chasing
			}
		
			// If the enemy's state is not currently chasing
			else {
			
			// Set the timer for how long the enemy will remain aware, currently set to 4 seconds
			timeAware = 4;
			enemy.lastDetect = timeAware + Time.time;
			
			// Keep track of the enemy's current x, y and z coordinates
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			// Set the enemy's state to aware
			enemy.state = AWARE;
			}
		}
		
		// If the player is currently jumping, do the same as above
		else if (player.isJump == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 4;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = AWARE;
			}
		}
	}

	else if (this.gameObject.name == "zone2" && other.gameObject.tag == "Player") {
	
		// If the player is currently walking, do the same as above
		if (player.isWalking == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 4;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = AWARE;
			}
		}
		
		else if (player.isRunning == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 6;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			// Set the enemy's state to chasing
			enemy.state = CHASING;
			}
		}
		
		else if (player.isJump == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 6;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
	}
	
	else if (this.gameObject.name == "zone3" && other.gameObject.tag == "Player") {
	
		if (player.isWalking == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 8;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
		
		else if (player.isRunning == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 8;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
		
		else if (player.isJump == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 8;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
	}
}

// This function tells whether another collider has exited a game object's collider attached to this script
function OnTriggerExit (other : Collider) {

	var enemy  : enemyBehavior = Enemy.gameObject.GetComponent(enemyBehavior);
	var player : playerScript = PC.gameObject.GetComponent(playerScript);

	if (this.gameObject.name == "zone1" && other.gameObject.tag == "Player") {
	
		if (player.isRunning == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 4;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = AWARE;
			}
		}
		
		else if (player.isJump == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 4;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = AWARE;
			}
		}
	}

	else if (this.gameObject.name == "zone2" && other.gameObject.tag == "Player") {
	
		if (player.isWalking == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 4;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = AWARE;
			}
		}
		
		else if (player.isRunning == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 6;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
		
		else if (player.isJump == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 6;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
	}
	
	else if (this.gameObject.name == "zone3" && other.gameObject.tag == "Player") {
	
		if (player.isWalking == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 8;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
		
		else if (player.isRunning == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 8;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
		
		else if (player.isJump == true) {
		
			if (enemy.state == CHASING) {
				
			}
		
			else {
			timeAware = 8;
			enemy.lastDetect = timeAware + Time.time;
			
			enemy.detectedPosition.x = Enemy.transform.position.x;
			enemy.detectedPosition.y = Enemy.transform.position.y;
			enemy.detectedPosition.z = Enemy.transform.position.z;
			
			enemy.state = CHASING;
			}
		}
	}
}