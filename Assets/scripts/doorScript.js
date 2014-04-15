#pragma strict

var doorOpen											: AnimationClip;
var doorClose											: AnimationClip;

var reject												: AudioClip;
var confirm												: AudioClip;

var doorMoveTime										: float = 0.0;
var doorMoveTimer										: float = 0.0;

var canOpen												: boolean = false;
var ICopen												: boolean = false;

var text												: GameObject;
var npc													: GameObject;
var maria												: GameObject;
var door1												: GameObject;
var door2												: GameObject;

function Start () {
	canOpen = false;
	ICopen = false;
	
	doorMoveTimer = 0;
}

function Update () {
	var key : securityBehavior = npc.gameObject.GetComponent(securityBehavior);
	var badge : mariaBehavior = maria.gameObject.GetComponent(mariaBehavior);
	
	if (key.talkCount >= 1) {
		if (!canOpen)
		{
			canOpen = true;
		}
	}
	
	if (badge.talkCount >= 1) {
		if (!ICopen)
		{
			ICopen = true;
		}
	}
}

function OnTriggerEnter (other : Collider) {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (other.gameObject.tag == "Player" && this.gameObject.name == "SecurityDoor") {
		if (canOpen) {
			animation.Play(doorOpen.name);
			
			audio.PlayOneShot(confirm);
		}
		
		else {
			audio.PlayOneShot(reject);
			
			message.displaySubtitle("I need to update my security card first..", 10);
			message.displayInfo("Greg Clemens", 10);
			message.displayWarning("Door access denied", 10);
		}
	}
	
	if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor")
	{
		if (ICopen) {
			animation.Play(doorOpen.name);
			
			audio.PlayOneShot(confirm);
		}
		
		else {
			audio.PlayOneShot(reject);
			
			message.displaySubtitle("I need to update my security badge first..", 10);
			message.displayInfo("Greg Clemens", 10);
			message.displayWarning("Door access denied", 10);
		}
	}
}

function OnTriggerExit (other: Collider) {
	if (other.gameObject.tag == "Player" && this.gameObject.name == "SecurityDoor" && canOpen) {
		animation.Play(doorClose.name);
	}

	if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor" && ICopen) {
		animation.Play(doorClose.name);
	}
}

@script RequireComponent(AudioSource)