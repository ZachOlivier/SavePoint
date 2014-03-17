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

var detectedPosition									: Vector3;

var PC													: GameObject;


function Start () {
	timeIdle = Time.time + Random.Range(3, 6);
}

function Update () {
	if (state == IDLE) {
		this.transform.position.x = this.transform.position.x;
		this.transform.position.y = this.transform.position.y;
		this.transform.position.z = this.transform.position.z;
		
		if (Time.time > timeIdle) {
			timeWander = Time.time + Random.Range(4, 7);
			
			direction = Random.Range(1, 4);
			
			state = WANDERING;
		}
	}
	
	else if (state == WANDERING) {
		if (direction == 1) {
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
			
			print("direction error");
		}
		
		 if (Time.time > timeWander) {
		 	timeIdle = Time.time + Random.Range(3, 6);
		 	
		 	state = IDLE;
		 }
	}
	
	else if (state == AWARE) {
		this.transform.position.x = this.transform.position.x;
		this.transform.position.y = this.transform.position.y;
		this.transform.position.z = this.transform.position.z;
		
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
		
		if (this.transform.position.y > PC.transform.position.y) {
			this.transform.position.y -= 2 * Time.deltaTime;
		}
		
		else if (this.transform.position.y < PC.transform.position.y) {
			this.transform.position.y += 2 * Time.deltaTime;
		}
		
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
			
			if (this.transform.position.x - detectedPosition.x < .5) {
				this.transform.position.x = detectedPosition.x;
			}
		}
		
		else if (this.transform.position.x < detectedPosition.x) {
			this.transform.position.x += 2 * Time.deltaTime;
			
			if (detectedPosition.x - this.transform.position.x < .5) {
				this.transform.position.x = detectedPosition.x;
			}
		}
		
		if (this.transform.position.y > detectedPosition.y) {
			this.transform.position.y -= 2 * Time.deltaTime;
			
			if (this.transform.position.y - detectedPosition.y < .5) {
				this.transform.position.y = detectedPosition.y;
			}
		}
		
		else if (this.transform.position.y < detectedPosition.y) {
			this.transform.position.y += 2 * Time.deltaTime;
			
			if (detectedPosition.y - this.transform.position.y < .5) {
				this.transform.position.y = detectedPosition.y;
			}
		}
		
		if (this.transform.position.z > detectedPosition.z) {
			this.transform.position.z -= 2 * Time.deltaTime;
			
			if (this.transform.position.z - detectedPosition.z < .5) {
				this.transform.position.z = detectedPosition.z;
			}
		}
		
		else if (this.transform.position.z < detectedPosition.z) {
			this.transform.position.z += 2 * Time.deltaTime;
			
			if (detectedPosition.z - this.transform.position.z < .5) {
				this.transform.position.z = detectedPosition.z;
			}
		}
		
		if (this.transform.position.x == detectedPosition.x && this.transform.position.y == detectedPosition.y && this.transform.position.z == detectedPosition.z) {
			timeIdle = Time.time + Random.Range(3, 6);
		
			state = IDLE;
		}
	}
	
	else {
		timeIdle = Time.time + Random.Range(3, 6);
	
		state = IDLE;
	}
}