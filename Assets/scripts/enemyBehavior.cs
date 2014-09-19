using UnityEngine;
using System.Collections;

public class enemyBehavior : MonoBehaviour {

	// Variable for holding which state the enemy is currently in
	public int state		= 0;

	// Variables for holding the different states the enemy can be in
	public int IDLE		= 0;
	public int WANDERING	= 1;
	public int AWARE		= 2;
	public int CHASING		= 3;
	public int LOST		= 4;

	// Variable for holding the time since last detection
	public float lastDetect	= 0.0f;

	// Variables for holding how long the enemy should be idle and wander
	public float timeIdle	= 0.0f;
	public int timeWander	= 0;
	public int timeAware	= 0;

	// Variables for holding which place the enemy is going to go
	public int direction	= 0;

	public int waypointTarget		= 0;

	public float SnapDist		= 0.1f;
	public int MinDist			= 1;
	public int zone1			= 2;
	public int zone2			= 8;
	public int zone3			= 15;
	public int MaxDist			= 15;

	public int Damping		= 0;
	public int MoveSpeed	= 0;

	public float lookAtTime	= 0.0f;
	public float lookAtTimer	= 0.0f;

	// Variables for holding where the enemy is when it detects someone
	public Transform detectedPosition;
	public Transform enemyPosition;

	public Quaternion rotation;

	// Variable for holding the player game object
	public GameObject PC;

	public Transform Player;

	// Variable for holding which waypopublic int is currently picked
	public Transform waypointTargeted;

	// Variables for holding the waypopublic int game objects
	public Transform waypointOne;
	public Transform waypointTwo;
	public Transform waypointThree;
	public Transform waypointFour;
	public Transform waypointFive;

	//private playerScript 	player;

	void Awake () {

		//player = PC.GetComponent <playerScript> ();
	}

	// Use this for initialization
	void Start () {
	
		// Set the first timer for how long the enemy should be idle to a random number between 3 and 6
		timeIdle = Time.time + Random.Range(2, 4);
		
		waypointTarget = 5;
		
		enemyPosition.position = transform.position;
		detectedPosition.position = transform.position;
		waypointTargeted.position = waypointFive.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (Vector3.Distance(transform.position, Player.position) <= zone3)
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
	}*/
		
		// If the current state is idle
		if (state == IDLE) {
			
			// Set the enemy's position variables to its current position
			enemyPosition.position = transform.position;
			
			// This makes sure the enemy isn't moving
			transform.position = enemyPosition.position;
			
			if (transform.position == waypointOne.position)
			{
				
			}
			
			// If the time set has passed by
			if (Time.time > timeIdle) {
				
				if (transform.position == waypointTargeted.position)
				{
					waypointTarget++;
				}
				
				// If the set waypopublic int is waypopublic int 1 and the last waypopublic int was not waypopublic int 1
				if (waypointTarget == 1) {
					// Set the waypopublic int to waypopublic int one
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
			
			// If the waypopublic int picked was waypopublic int 1
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
				timeIdle = Time.time + Random.Range(7, 10);
				
				state = IDLE;
			}
			
			else if (transform.position == waypointTwo.position) {
				timeIdle = Time.time + Random.Range(2, 4);
				
				state = IDLE;
			}
			
			else if (transform.position == waypointThree.position) {
				timeIdle = Time.time + Random.Range(2, 4);
				
				state = IDLE;
			}
			
			else if (transform.position == waypointFour.position) {
				timeIdle = Time.time + Random.Range(2, 4);
				
				state = IDLE;
			}
			
			else if (transform.position == waypointFive.position) {
				timeIdle = Time.time + Random.Range(2, 4);
				
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
				timeIdle = Time.time + Random.Range(2, 4);
				
				state = IDLE;
			}
		}
		
		// Else if the state isn't set to one of the above, just reset the enemy's state to idle
		else {
			timeIdle = Time.time + Random.Range(2, 4);
			
			state = IDLE;
		}
	}
}