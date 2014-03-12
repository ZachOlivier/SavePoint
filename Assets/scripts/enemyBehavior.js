#pragma strict

var state												: int = 0;

var IDLE												: int = 0;
var WANDERING											: int = 1;
var AWARE												: int = 2;
var WALKING												: int = 3;
var JOGGING												: int = 4;
var RUNNING												: int = 5;
var LOST												: int = 6;


function Start () {

}

function Update () {
	if (state == IDLE) {
		
	}
	
	else if (state == WANDERING) {
		
	}
	
	else if (state == AWARE) {
		
	}
	
	else if (state == WALKING) {
		
	}
	
	else if (state == JOGGING) {
		
	}
	
	else if (state == RUNNING) {
		
	}
	
	else if (state == LOST) {
		
	}
}

function OnTriggerEnter (other : Collider) {
	if (other.gameObject.tag == "Player") {
		state = AWARE;
	}
}

function OnTriggerExit (other : Collider) {
	if (other.gameObject.tag == "Player") {
		state = LOST;
	}
}