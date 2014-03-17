#pragma strict

var state												: int = 0;

var IDLE												: int = 0;
var WANDERING											: int = 1;
var AWARE												: int = 2;
var CHASING												: int = 4;
var LOST												: int = 5;

var lastDetect											: int = 0;

var timeIdle											: int = 0;
var timeWander											: int = 0;

var direction											: int = 0;
var waypointTarget										: int = 0;

var detectedPosition									: Vector3;
var enemyPosition										: Vector3;

var PC													: GameObject;

var waypointTargeted									: GameObject;

var waypointOne											: GameObject;
var waypointTwo											: GameObject;
var waypointThree										: GameObject;
var waypointFour										: GameObject;
var waypointFive										: GameObject;


function Start () {
	timeIdle = Time.time + Random.Range(3, 6);
}

function Update () {
	if (state == IDLE) {
		enemyPosition.x = this.transform.position.x;
		enemyPosition.y = this.transform.position.y;
		enemyPosition.z = this.transform.position.z;
	
		this.transform.position.x = enemyPosition.x;
		this.transform.position.y = enemyPosition.y;
		this.transform.position.z = enemyPosition.z;
		
		if (Time.time > timeIdle) {
			timeWander = Time.time + Random.Range(4, 9);
			
			//direction = Random.Range(1, 4);
			waypointTarget = Random.Range(1, 5);
			
			if (waypointTarget == 1 && waypointTargeted != waypointOne) {
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
			
			else {
				waypointTarget = Random.Range(1, 5);
			}
			
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
		
		if (waypointTargeted == waypointOne) {
			if (this.transform.position.x > waypointOne.transform.position.x) {
				this.transform.position.x -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.x < waypointOne.transform.position.x) {
				this.transform.position.x += 2 * Time.deltaTime;
			}
		
			/*if (this.transform.position.y > waypointOne.transform.position.y) {
				this.transform.position.y -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointOne.transform.position.y) {
				this.transform.position.y += 2 * Time.deltaTime;
			}*/
		
			if (this.transform.position.z > waypointOne.transform.position.z) {
				this.transform.position.z -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.z < waypointOne.transform.position.z) {
				this.transform.position.z += 2 * Time.deltaTime;
			}
		}
		
		else if (waypointTargeted == waypointTwo) {
			if (this.transform.position.x > waypointTwo.transform.position.x) {
				this.transform.position.x -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.x < waypointTwo.transform.position.x) {
				this.transform.position.x += 2 * Time.deltaTime;
			}
		
			/*if (this.transform.position.y > waypointTwo.transform.position.y) {
				this.transform.position.y -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointTwo.transform.position.y) {
				this.transform.position.y += 2 * Time.deltaTime;
			}*/
		
			if (this.transform.position.z > waypointTwo.transform.position.z) {
				this.transform.position.z -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.z < waypointTwo.transform.position.z) {
				this.transform.position.z += 2 * Time.deltaTime;
			}
		}
		
		else if (waypointTargeted == waypointThree) {
			if (this.transform.position.x > waypointThree.transform.position.x) {
				this.transform.position.x -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.x < waypointThree.transform.position.x) {
				this.transform.position.x += 2 * Time.deltaTime;
			}
		
			/*if (this.transform.position.y > waypointThree.transform.position.y) {
				this.transform.position.y -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointThree.transform.position.y) {
				this.transform.position.y += 2 * Time.deltaTime;
			}*/
		
			if (this.transform.position.z > waypointThree.transform.position.z) {
				this.transform.position.z -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.z < waypointThree.transform.position.z) {
				this.transform.position.z += 2 * Time.deltaTime;
			}
		}
		
		else if (waypointTargeted == waypointFour) {
			if (this.transform.position.x > waypointFour.transform.position.x) {
				this.transform.position.x -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.x < waypointFour.transform.position.x) {
				this.transform.position.x += 2 * Time.deltaTime;
			}
		
			/*if (this.transform.position.y > waypointFour.transform.position.y) {
				this.transform.position.y -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointFour.transform.position.y) {
				this.transform.position.y += 2 * Time.deltaTime;
			}*/
		
			if (this.transform.position.z > waypointFour.transform.position.z) {
				this.transform.position.z -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.z < waypointFour.transform.position.z) {
				this.transform.position.z += 2 * Time.deltaTime;
			}
		}
		
		else if (waypointTargeted == waypointFive) {
			if (this.transform.position.x > waypointFive.transform.position.x) {
				this.transform.position.x -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.x < waypointFive.transform.position.x) {
				this.transform.position.x += 2 * Time.deltaTime;
			}
		
			/*if (this.transform.position.y > waypointFive.transform.position.y) {
				this.transform.position.y -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.y < waypointFive.transform.position.y) {
				this.transform.position.y += 2 * Time.deltaTime;
			}*/
		
			if (this.transform.position.z > waypointFive.transform.position.z) {
				this.transform.position.z -= 2 * Time.deltaTime;
			}
		
			else if (this.transform.position.z < waypointFive.transform.position.z) {
				this.transform.position.z += 2 * Time.deltaTime;
			}
		}
		
		else {
			direction = Random.Range(1, 4);
		}
		
		 if (Time.time > timeWander) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
	}
	
	else if (state == AWARE) {
		enemyPosition.x = this.transform.position.x;
		enemyPosition.y = this.transform.position.y;
		enemyPosition.z = this.transform.position.z;
	
		this.transform.position.x = enemyPosition.x;
		this.transform.position.y = enemyPosition.y;
		this.transform.position.z = enemyPosition.z;
		
		if (Time.time > lastDetect) {
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
			
			if (this.transform.position.x - detectedPosition.x < .1) {
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
		
		//if (this.transform.position.x == detectedPosition.x && this.transform.position.y == detectedPosition.y && this.transform.position.z == detectedPosition.z) {
		if (this.transform.position.x == detectedPosition.x && this.transform.position.z == detectedPosition.z) {
			timeIdle = Time.time + Random.Range(3, 6);
		
			state = IDLE;
		}
	}
	
	else {
		timeIdle = Time.time + Random.Range(3, 6);
	
		state = IDLE;
	}
}