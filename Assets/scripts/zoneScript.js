#pragma strict

var IDLE												: int = 0;
var WANDERING											: int = 1;
var AWARE												: int = 2;
var CHASING												: int = 4;
var LOST												: int = 5;

var timeAware											: int = 0;

var Enemy												: GameObject;
var PC													: GameObject;


function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
			}
		}
	}
}

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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
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
		
			print(enemy.state + "  " + enemy.lastDetect);
			}
		}
	}
}