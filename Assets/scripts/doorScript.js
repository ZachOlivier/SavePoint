#pragma strict

var reject												: AudioClip;
var confirm												: AudioClip;

var canOpen												: boolean = false;

var text												: GameObject;
var npc													: GameObject;
var door1												: GameObject;
var door2												: GameObject;

function Start () {
	canOpen = false;
	
	door1.transform.position.x = 12.5;
	door2.transform.position.x = 11.1;
}

function Update () {
	var key : npcBehavior = npc.gameObject.GetComponent(npcBehavior);
	
	if (key.talkCount == 1) {
		canOpen = true;
	}
}

function OnTriggerEnter (other : Collider) {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (other.gameObject.tag == "Player") {
		if (canOpen && door1.transform.position.x != 13.7 && door2.transform.position.x != 9.8) {
			door1.transform.position.x = 13.7;
			door2.transform.position.x = 9.8;
			
			audio.PlayOneShot(confirm);
		}
		
		else {
			audio.PlayOneShot(reject);
			
			message.displaySubtitle("I have a new key card for you sir", 10);
			message.displayInfo("Security Guard William Hobb", 10);
			message.displayWarning("Door access denied", 10);
		}
	}
}

function OnTriggerExit (other: Collider) {
	if (other.gameObject.tag == "Player") {
		door1.transform.position.x = 12.5;
		door2.transform.position.x = 11.1;
	}
}

@script RequireComponent(AudioSource)