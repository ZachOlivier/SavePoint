#pragma strict

// Variable for holding which state the enemy is currently in
var state												: int = 0;

// Variables for holding the different states the enemy can be in
var IDLE												: int = 0;
var WANDERING											: int = 1;
var AWARE												: int = 2;
var CHASING												: int = 4;
var LOST												: int = 5;

// Variable for holding the time since last detection
var lastDetect											: int = 0;

// Variables for holding how long the enemy should be idle and wander
var timeIdle											: int = 0;
var timeWander											: int = 0;

// Variables for holding which place the enemy is going to go
var direction											: int = 0;
var waypointTarget										: int = 0;

// Variables for holding where the enemy is when it detects someone
var detectedPosition									: Vector3;
var enemyPosition										: Vector3;

// Variable for holding the player game object
var PC													: GameObject;

// Variable for holding which waypoint is currently picked
var waypointTargeted									: GameObject;

// Variables for holding the waypoint game objects
var waypointOne											: GameObject;
var waypointTwo											: GameObject;
var waypointThree										: GameObject;
var waypointFour										: GameObject;
var waypointFive										: GameObject;

// This function only fires once during the start of this script
function Start () {

	// Set the first timer for how long the enemy should be idle to a random number between 3 and 6
	timeIdle = Time.time + Random.Range(3, 6);
	
	waypointTarget = 0;
}

// This function fires over and over again throughout the life of this script
function Update () {

	// If the current state is idle
	if (state == IDLE) {
		
		// Set the enemy's position variables to its current position
		enemyPosition.x = this.transform.position.x;
		enemyPosition.y = this.transform.position.y;
		enemyPosition.z = this.transform.position.z;
		
		// This makes sure the enemy isn't moving
		this.transform.position.x = enemyPosition.x;
		this.transform.position.y = enemyPosition.y;
		this.transform.position.z = enemyPosition.z;
		
		// If the time set has passed by
		if (Time.time > timeIdle) {
		
			// Set a timer for how long the enemy will wander
			//timeWander = Time.time + Random.Range(4, 9);
			
			// Set the waypoint or direction for the enemy to go
			waypointTarget++;
			//waypointTarget = Random.Range(1, 5);
			//direction = Random.Range(1, 4);
			
			// If the set waypoint is waypoint 1 and the last waypoint was not waypoint 1
			if (waypointTarget == 1) {
			
				// Set the waypoint to waypoint one
				waypointTargeted = waypointOne;
			}
			
			else if (waypointTarget == 2) {
				waypointTargeted = waypointTwo;
			}
			
			else if (waypointTarget == 3) {
				waypointTargeted = waypointThree;
			}
			
			else if (waypointTarget == 4) {
				waypointTargeted = waypointFour;
			}
			
			else if (waypointTarget == 5) {
				waypointTargeted = waypointFive;
				
				waypointTarget = 0;
			}
		
			/*// Set a timer for how long the enemy will wander
			timeWander = Time.time + Random.Range(4, 9);
			
			// Set the waypoint or direction for the enemy to go
			waypointTarget = Random.Range(1, 5);
			//direction = Random.Range(1, 4);
			
			// If the set waypoint is waypoint 1 and the last waypoint was not waypoint 1
			if (waypointTarget == 1 && waypointTargeted != waypointOne) {
			
				// Set the waypoint to waypoint one
				waypointTargeted = waypointOne;
			}
			
			else if (waypointTarget == 2 && waypointTargeted != waypointTwo) {
				waypointTargeted = waypointTwo;
			}
			
			else if (waypointTarget == 3 && waypointTargeted != waypointThree) {
				waypointTargeted = waypointThree;
			}
			
			else if (waypointTarget == 4 && waypointTargeted != waypointFour) {
				waypointTargeted = waypointFour;
			}
			
			else if (waypointTarget == 5 && waypointTargeted != waypointFive) {
				waypointTargeted = waypointFive;
			}
			
			// If the waypoint that was picked was the last waypoint picked
			else {
				waypointTarget = Random.Range(1, 5);
			}*/
			
			// Set the current state to wandering
			state = WANDERING;
		}
	}
	
	else if (state == WANDERING) {
		/*if (direction == 1) {
			this.transform.position.x += 5 * Time.deltaTime;
		}
		
		else if (direction == 2) {
			this.transform.position.x -= 5 * Time.deltaTime;
		}
		
		else if (direction == 3) {
			this.transform.position.z += 5 * Time.deltaTime;
		}
		
		else if (direction == 4) {
			this.transform.position.z -= 5 * Time.deltaTime;
		}
		
		else {
			direction = Random.Range(1, 4);
		}*/
		
		// If the waypoint picked was waypoint 1
		if (waypointTargeted == waypointOne) {
		
			// If the enemy's current x position is greater than the waypoint's x position
			if (this.transform.position.x > waypointOne.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by decreasing it
				this.transform.position.x -= 4 * Time.deltaTime;
				
				if (this.transform.position.x - waypointOne.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointOne.transform.position.x;
				}
			}
		
			// Else if the enemy's current x position is less than the waypoint's x position
			else if (this.transform.position.x < waypointOne.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by increasing it
				this.transform.position.x += 4 * Time.deltaTime;
				
				if (waypointOne.transform.position.x - this.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointOne.transform.position.x;
				}
			}
		
			/*if (this.transform.position.y > waypointOne.transform.position.y) {
				this.transform.position.y -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointOne.transform.position.y) {
				this.transform.position.y += 2 * Time.deltaTime;
			}*/
		
			// Same as above only for the enemy's z position compared to the waypoint's z position
			if (this.transform.position.z > waypointOne.transform.position.z) {
				this.transform.position.z -= 4 * Time.deltaTime;
				
				if (this.transform.position.z - waypointOne.transform.position.z < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.z = waypointOne.transform.position.z;
				}
			}
		
			else if (this.transform.position.z < waypointOne.transform.position.z) {
				this.transform.position.z += 4 * Time.deltaTime;
				
				if (waypointOne.transform.position.z - this.transform.position.z < .1) {
			
					// Set the enemy's z position to the detected object's z position
					this.transform.position.z = waypointOne.transform.position.z;
				}
			}
		}
		
		else if (waypointTargeted == waypointTwo) {
		
			// If the enemy's current x position is greater than the waypoint's x position
			if (this.transform.position.x > waypointTwo.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by decreasing it
				this.transform.position.x -= 4 * Time.deltaTime;
				
				if (this.transform.position.x - waypointTwo.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointTwo.transform.position.x;
				}
			}
		
			// Else if the enemy's current x position is less than the waypoint's x position
			else if (this.transform.position.x < waypointTwo.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by increasing it
				this.transform.position.x += 4 * Time.deltaTime;
				
				if (waypointTwo.transform.position.x - this.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointTwo.transform.position.x;
				}
			}
		
			/*if (this.transform.position.y > waypointTwo.transform.position.y) {
				this.transform.position.y -= 4 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointTwo.transform.position.y) {
				this.transform.position.y += 4 * Time.deltaTime;
			}*/
		
			// Same as above only for the enemy's z position compared to the waypoint's z position
			if (this.transform.position.z > waypointTwo.transform.position.z) {
				this.transform.position.z -= 4 * Time.deltaTime;
				
				if (this.transform.position.z - waypointTwo.transform.position.z < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.z = waypointTwo.transform.position.z;
				}
			}
		
			else if (this.transform.position.z < waypointTwo.transform.position.z) {
				this.transform.position.z += 4 * Time.deltaTime;
				
				if (waypointTwo.transform.position.z - this.transform.position.z < .1) {
			
					// Set the enemy's z position to the detected object's z position
					this.transform.position.z = waypointTwo.transform.position.z;
				}
			}
		}
		
		if (waypointTargeted == waypointThree) {
		
			// If the enemy's current x position is greater than the waypoint's x position
			if (this.transform.position.x > waypointThree.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by decreasing it
				this.transform.position.x -= 4 * Time.deltaTime;
				
				if (this.transform.position.x - waypointThree.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointThree.transform.position.x;
				}
			}
		
			// Else if the enemy's current x position is less than the waypoint's x position
			else if (this.transform.position.x < waypointThree.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by increasing it
				this.transform.position.x += 4 * Time.deltaTime;
				
				if (waypointThree.transform.position.x - this.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointThree.transform.position.x;
				}
			}
		
			/*if (this.transform.position.y > waypointThree.transform.position.y) {
				this.transform.position.y -= 4 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointThree.transform.position.y) {
				this.transform.position.y += 4 * Time.deltaTime;
			}*/
		
			// Same as above only for the enemy's z position compared to the waypoint's z position
			if (this.transform.position.z > waypointThree.transform.position.z) {
				this.transform.position.z -= 4 * Time.deltaTime;
				
				if (this.transform.position.z - waypointThree.transform.position.z < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.z = waypointThree.transform.position.z;
				}
			}
		
			else if (this.transform.position.z < waypointThree.transform.position.z) {
				this.transform.position.z += 4 * Time.deltaTime;
				
				if (waypointThree.transform.position.z - this.transform.position.z < .1) {
			
					// Set the enemy's z position to the detected object's z position
					this.transform.position.z = waypointThree.transform.position.z;
				}
			}
		}
		
		if (waypointTargeted == waypointFour) {
		
			// If the enemy's current x position is greater than the waypoint's x position
			if (this.transform.position.x > waypointFour.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by decreasing it
				this.transform.position.x -= 4 * Time.deltaTime;
				
				if (this.transform.position.x - waypointFour.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointFour.transform.position.x;
				}
			}
		
			// Else if the enemy's current x position is less than the waypoint's x position
			else if (this.transform.position.x < waypointFour.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by increasing it
				this.transform.position.x += 4 * Time.deltaTime;
				
				if (waypointFour.transform.position.x - this.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointFour.transform.position.x;
				}
			}
		
			/*if (this.transform.position.y > waypointFour.transform.position.y) {
				this.transform.position.y -= 4 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointFour.transform.position.y) {
				this.transform.position.y += 4 * Time.deltaTime;
			}*/
		
			// Same as above only for the enemy's z position compared to the waypoint's z position
			if (this.transform.position.z > waypointFour.transform.position.z) {
				this.transform.position.z -= 4 * Time.deltaTime;
				
				if (this.transform.position.z - waypointFour.transform.position.z < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.z = waypointFour.transform.position.z;
				}
			}
		
			else if (this.transform.position.z < waypointFour.transform.position.z) {
				this.transform.position.z += 4 * Time.deltaTime;
				
				if (waypointFour.transform.position.z - this.transform.position.z < .1) {
			
					// Set the enemy's z position to the detected object's z position
					this.transform.position.z = waypointFour.transform.position.z;
				}
			}
		}
		
		if (waypointTargeted == waypointFive) {
		
			// If the enemy's current x position is greater than the waypoint's x position
			if (this.transform.position.x > waypointFive.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by decreasing it
				this.transform.position.x -= 4 * Time.deltaTime;
				
				if (this.transform.position.x - waypointFive.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointFive.transform.position.x;
				}
			}
		
			// Else if the enemy's current x position is less than the waypoint's x position
			else if (this.transform.position.x < waypointFive.transform.position.x) {
			
				// Move the enemy's x position towards the waypoint by increasing it
				this.transform.position.x += 4 * Time.deltaTime;
				
				if (waypointFive.transform.position.x - this.transform.position.x < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.x = waypointFive.transform.position.x;
				}
			}
		
			/*if (this.transform.position.y > waypointFive.transform.position.y) {
				this.transform.position.y -= 4 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointFive.transform.position.y) {
				this.transform.position.y += 4 * Time.deltaTime;
			}*/
		
			// Same as above only for the enemy's z position compared to the waypoint's z position
			if (this.transform.position.z > waypointFive.transform.position.z) {
				this.transform.position.z -= 4 * Time.deltaTime;
				
				if (this.transform.position.z - waypointFive.transform.position.z < .1) {
			
					// Set the enemy's x position to the detected object's x position
					this.transform.position.z = waypointFive.transform.position.z;
				}
			}
		
			else if (this.transform.position.z < waypointFive.transform.position.z) {
				this.transform.position.z += 4 * Time.deltaTime;
				
				if (waypointFive.transform.position.z - this.transform.position.z < .1) {
			
					// Set the enemy's z position to the detected object's z position
					this.transform.position.z = waypointFive.transform.position.z;
				}
			}
		}
		
		if (this.transform.position.x == waypointOne.transform.position.x && this.transform.position.z == waypointOne.transform.position.z) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 if (this.transform.position.x == waypointTwo.transform.position.x && this.transform.position.z == waypointTwo.transform.position.z) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 if (this.transform.position.x == waypointThree.transform.position.x && this.transform.position.z == waypointThree.transform.position.z) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 if (this.transform.position.x == waypointFour.transform.position.x && this.transform.position.z == waypointFour.transform.position.z) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 if (this.transform.position.x == waypointFive.transform.position.x && this.transform.position.z == waypointFive.transform.position.z) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		
		 /*if (Time.time > timeWander) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }*/
	}
	
	else if (state == AWARE) {
	
		enemyPosition.x = this.transform.position.x;
		enemyPosition.y = this.transform.position.y;
		enemyPosition.z = this.transform.position.z;
	
		this.transform.position.x = enemyPosition.x;
		this.transform.position.y = enemyPosition.y;
		this.transform.position.z = enemyPosition.z;
		
		// If too much time has passed by since last detection
		if (Time.time > lastDetect) {
		
			// Set current state to lost
			state = LOST;
		}
	}
	
	else if (state == CHASING) {
	
		if (this.transform.position.x > PC.transform.position.x) {
			this.transform.position.x -= 2 * Time.deltaTime;
		}
		
		else if (this.transform.position.x < PC.transform.position.x) {
			this.transform.position.x += 2 * Time.deltaTime;
		}
		
		/*if (this.transform.position.y > PC.transform.position.y) {
			this.transform.position.y -= 2 * Time.deltaTime;
		}
		
		else if (this.transform.position.y < PC.transform.position.y) {
			this.transform.position.y += 2 * Time.deltaTime;
		}*/
		
		if (this.transform.position.z > PC.transform.position.z) {
			this.transform.position.z -= 2 * Time.deltaTime;
		}
		
		else if (this.transform.position.z < PC.transform.position.z) {
			this.transform.position.z += 2 * Time.deltaTime;
		}
		
		if (Time.time > lastDetect) {
			lastDetect = Time.time + 3;
		
			state = AWARE;
		}
	}
	
	else if (state == LOST) {
	
		if (this.transform.position.x > detectedPosition.x) {
		
			this.transform.position.x -= 2 * Time.deltaTime;
			
			// If the enemy's x position is close to the detected object's x position
			if (this.transform.position.x - detectedPosition.x < .1) {
			
				// Set the enemy's x position to the detected object's x position
				this.transform.position.x = detectedPosition.x;
			}
		}
		
		else if (this.transform.position.x < detectedPosition.x) {
		
			this.transform.position.x += 2 * Time.deltaTime;
			
			if (detectedPosition.x - this.transform.position.x < .1) {
				this.transform.position.x = detectedPosition.x;
			}
		}
		
		/*if (this.transform.position.y > detectedPosition.y) {
			this.transform.position.y -= 2 * Time.deltaTime;
			
			if (this.transform.position.y - detectedPosition.y < .1) {
				this.transform.position.y = detectedPosition.y;
			}
		}
		
		else if (this.transform.position.y < detectedPosition.y) {
			this.transform.position.y += 2 * Time.deltaTime;
			
			if (detectedPosition.y - this.transform.position.y < .1) {
				this.transform.position.y = detectedPosition.y;
			}
		}*/
		
		if (this.transform.position.z > detectedPosition.z) {
		
			this.transform.position.z -= 2 * Time.deltaTime;
			
			// Do the same as above only for the enemy's z position
			if (this.transform.position.z - detectedPosition.z < .1) {
				this.transform.position.z = detectedPosition.z;
			}
		}
		
		else if (this.transform.position.z < detectedPosition.z) {
		
			this.transform.position.z += 2 * Time.deltaTime;
			
			if (detectedPosition.z - this.transform.position.z < .1) {
				this.transform.position.z = detectedPosition.z;
			}
		}
		
		// If the enemy's current position is the detected object's current position
		//if (this.transform.position.x == detectedPosition.x && this.transform.position.y == detectedPosition.y && this.transform.position.z == detectedPosition.z) {
		if (this.transform.position.x == detectedPosition.x && this.transform.position.z == detectedPosition.z) {
			timeIdle = Time.time + Random.Range(3, 6);
		
			state = IDLE;
		}
	}
	
	// Else if the state isn't set to one of the above, just reset the enemy's state to idle
	else {
		timeIdle = Time.time + Random.Range(3, 6);
	
		state = IDLE;
	}
}