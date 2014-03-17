#pragma strict

var canTalk												: boolean = false;

var holder												: GameObject;


function Start () {

}

function Update () {
	var cam : cameraMode = holder.gameObject.GetComponent(cameraMode);

	if (Input.GetButtonDown("Talk") && canTalk && cam.cameraMode == 0) {
		canTalk = false;
		
		cam.canChange = false;
		
		//Time.timeScale = 0.0;
		
		TalkInitiated();
	}
	
	else if (Input.GetButtonDown("Talk") && !canTalk && cam.cameraMode == 0) {
		//Time.timeScale = 1.0;
		
		cam.canChange = true;
	
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