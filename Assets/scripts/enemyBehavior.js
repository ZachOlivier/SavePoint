#pragma strict

// Variable for holding which state the enemy is currently in
var state												: int = 0;

// Variables for holding the different states the enemy can be in
var IDLE												: int = 0;
var WANDERING											: int = 1;
var AWARE												: int = 2;
var CHASING												: int = 3;
var LOST												: int = 4;

// Variable for holding the time since last detection
var lastDetect											: int = 0;

// Variables for holding how long the enemy should be idle and wander
var timeIdle											: int = 0;
var timeWander											: int = 0;
var timeAware											: int = 0;

// Variables for holding which place the enemy is going to go
var direction											: int = 0;
var waypointTarget										: int = 0;

var SnapDist											: float = 0.1;
var MinDist												: int = 1;
var zone1												: int = 2;
var zone2												: int = 8;
var zone3												: int = 15;
var MaxDist												: int = 15;

var Damping												: int = 0;

var MoveSpeed											: int = 0;

var lookAtTime											: float = 0.0;
var lookAtTimer											: float = 0.0;

// Variables for holding where the enemy is when it detects someone
var detectedPosition									: Transform;
var enemyPosition										: Transform;

var rotation											: Quaternion;

// Variable for holding the player game object
var PC													: GameObject;

var Player												: Transform;

// Variable for holding which waypoint is currently picked
var waypointTargeted									: Transform;

// Variables for holding the waypoint game objects
var waypointOne											: Transform;
var waypointTwo											: Transform;
var waypointThree										: Transform;
var waypointFour										: Transform;
var waypointFive										: Transform;

// This function only fires once during the start of this script
function Start () {

	// Set the first timer for how long the enemy should be idle to a random number between 3 and 6
	timeIdle = Time.time + Random.Range(3, 6);
	
	waypointTarget = 0;
	
	enemyPosition.position = transform.position;
	detectedPosition.position = transform.position;
	waypointTargeted.position = waypointFive.position;
}

// This function fires over and over again throughout the life of this script
function Update () {

	var player : playerScript = PC.gameObject.GetComponent(playerScript);

	if (Vector3.Distance(transform.position, Player.position) <= zone3)
	{
		if (player.isRunning || player.isJump) {
		
			// If the enemy's state is currently chasing
			if (state == CHASING) {
				// We need this in here to have the enemy not change states if it is already chasing
			}
		
			// If the enemy's state is not currently chasing
			else {
			
			// Set the timer for how long the enemy will remain aware, currently set to 4 seconds
			timeAware = 4;
			lastDetect = timeAware + Time.time;
			
			// Keep track of the enemy's current x, y and z coordinates
			detectedPosition.position = transform.position;
			
			// Set the enemy's state to aware
			state = AWARE;
			}
		}
		
		if (Vector3.Distance(transform.position, Player.position) <= zone2)
		{
			// If the player is currently walking, do the same as above
			if (player.isWalking) {
		
				if (state == CHASING) {
				
				}
		
				else {
				timeAware = 4;
				lastDetect = timeAware + Time.time;
			
				detectedPosition.position = transform.position;
			
				state = AWARE;
				}
			}
		
			else if (player.isRunning || player.isJump) {
		
				if (state == CHASING) {
				
				}
		
				else {
				timeAware = 6;
				lastDetect = timeAware + Time.time;
			
				detectedPosition.position = transform.position;
			
				// Set the enemy's state to chasing
				state = CHASING;
				}
			}
			
			if (Vector3.Distance(transform.position, Player.position) <= zone1)
			{
				if (player.isWalking || player.isRunning || player.isJump) {
		
					if (state == CHASING) {
				
					}
		
					else {
					timeAware = 8;
					lastDetect = timeAware + Time.time;
			
					detectedPosition.position = transform.position;
			
					state = CHASING;
					}
				}	
			}
		}
	}

	// If the current state is idle
	if (state == IDLE) {
		
		// Set the enemy's position variables to its current position
		enemyPosition.position = transform.position;
		
		// This makes sure the enemy isn't moving
		transform.position = enemyPosition.position;
		
		// If the time set has passed by
		if (Time.time > timeIdle) {
			
			if (transform.position == waypointTargeted.position)
			{
				waypointTarget++;
			}
			
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
			
			// Set the current state to wandering
			state = WANDERING;
		}
	}
	
	else if (state == WANDERING) {
	
		// If the waypoint picked was waypoint 1
		if (waypointTargeted == waypointOne) {
		
			rotation = Quaternion.LookRotation(waypointOne.position - transform.position);
   			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);

			if (Vector3.Distance(transform.position, waypointOne.position) > SnapDist)
			{
		 		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		 		
		 		//animation.CrossFade(animal_walk.name);
			}
				
			if (Vector3.Distance(transform.position, waypointOne.position) <= SnapDist)
			{
				transform.position = waypointOne.position;
			}
		}
		
		else if (waypointTargeted == waypointTwo) {
		
			rotation = Quaternion.LookRotation(waypointTwo.position - transform.position);
   			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);

			if (Vector3.Distance(transform.position, waypointTwo.position) > SnapDist)
			{
		 		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		 		
		 		//animation.CrossFade(animal_walk.name);
			}
				
			if (Vector3.Distance(transform.position, waypointTwo.position) <= SnapDist)
			{
				transform.position = waypointTwo.position;
			}
		}
		
		else if (waypointTargeted == waypointThree) {
		
			rotation = Quaternion.LookRotation(waypointThree.position - transform.position);
   			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);

			if (Vector3.Distance(transform.position, waypointThree.position) > SnapDist)
			{
		 		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		 		
		 		//animation.CrossFade(animal_walk.name);
			}
				
			if (Vector3.Distance(transform.position, waypointThree.position) <= SnapDist)
			{
				transform.position = waypointThree.position;
			}
		}
		
		else if (waypointTargeted == waypointFour) {
		
			rotation = Quaternion.LookRotation(waypointFour.position - transform.position);
   			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		
			if (Vector3.Distance(transform.position, waypointFour.position) > SnapDist)
			{
		 		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		 		
		 		//animation.CrossFade(animal_walk.name);
			}
				
			if (Vector3.Distance(transform.position, waypointFour.position) <= SnapDist)
			{
				transform.position = waypointFour.position;
			}
		}
		
		else if (waypointTargeted == waypointFive) {
		
			rotation = Quaternion.LookRotation(waypointFive.position - transform.position);
   			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		
			if (Vector3.Distance(transform.position, waypointFive.position) > SnapDist)
			{
		 		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		 		
		 		//animation.CrossFade(animal_walk.name);
			}
				
			if (Vector3.Distance(transform.position, waypointFive.position) <= SnapDist)
			{
				transform.position = waypointFive.position;
			}
		}
		
		if (transform.position == waypointOne.position) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 else if (transform.position == waypointTwo.position) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 else if (transform.position == waypointThree.position) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 else if (transform.position == waypointFour.position) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
		 
		 else if (transform.position == waypointFive.position) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
	}
	
	else if (state == AWARE) {
	
		// Set the enemy's position variables to its current position
		enemyPosition.position = transform.position;
		
		// This makes sure the enemy isn't moving
		transform.position = enemyPosition.position;
		
		// If too much time has passed by since last detection
		if (Time.time > lastDetect) {
		
			// Set current state to lost
			state = LOST;
		}
	}
	
	else if (state == CHASING) {
	
		rotation = Quaternion.LookRotation(Player.position - transform.position);
   		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
	
		if (Vector3.Distance(transform.position, Player.position) > MinDist)
		{
		 	transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		}
		
		if (Time.time > lastDetect) {
			lastDetect = Time.time + 3;
		
			state = AWARE;
		}
	}
	
	else if (state == LOST) {
	
		rotation = Quaternion.LookRotation(detectedPosition.position - transform.position);
   		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
	
		if (Vector3.Distance(transform.position, detectedPosition.position) > SnapDist)
		{
		 	transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		 		
		 	//animation.CrossFade(animal_walk.name);
		}
				
		if (Vector3.Distance(transform.position, detectedPosition.position) <= SnapDist)
		{
			transform.position = detectedPosition.position;
		}
		
		// If the enemy's current position is the detected object's current position
		if (transform.position == detectedPosition.position) {
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