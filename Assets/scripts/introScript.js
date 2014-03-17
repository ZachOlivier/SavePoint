#pragma strict

var timer												: int = 0;
var part												: int = 0;

var savePoint											: GameObject;
var episodeText											: GameObject;


function Start () {
	part = 0;
	
	timer = Time.time + 2;
}

function Update () {
	if (Time.time > timer && part == 0) {
		savePoint.transform.position.z = -4;
		
		part = 1;
		
		timer = Time.time + 4;
	}
	
	if (Time.time > timer && part == 1) {
		Destroy(savePoint.gameObject);
	
		part = 2;
		
		timer = Time.time + 2;
	}
	
	if (Time.time > timer && part == 2) {
		episodeText.transform.position.z = 4;
		
		part = 3;
		
		timer = Time.time + 6;
	}
	
	if (Time.time > timer && part == 3) {
		Destroy(episodeText.gameObject);
		
		part = 4;
		
		timer = Time.time + 2;
	}
	
	if (Time.time > timer && part == 4) {
		Application.LoadLevel(1);
	}
}