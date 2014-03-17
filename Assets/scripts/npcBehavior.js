#pragma strict

var canTalk												: boolean = false;


function Start () {

}

function Update () {
	if (Input.GetButtonDown("Talk") && canTalk) {
		canTalk = false;
		
		Time.timeScale = 0.0;
		
		TalkInitiated();
	}
	
	else if (Input.GetButtonDown("Talk") && !canTalk) {
		Time.timeScale = 1.0;
	
		print("Can't talk right now");
	}
}

function OnTriggerEnter (other : Collider) {
	//var player : playerScript = gameObject.GetComponent(playerScript);

	if (other.gameObject.tag == "Player") {
		canTalk = true;
	}
}

function OnTriggerExit (other : Collider) {
	//var player : playerScript = gameObject.GetComponent(playerScript);

	if (other.gameObject.tag == "Player") {
		canTalk = false;
	}
}

function TalkInitiated () {
	
}