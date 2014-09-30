#pragma strict

var doorOpen											: AnimationClip;
var doorClose											: AnimationClip;

var reject												: AudioClip;
var confirm												: AudioClip;

var doorMoveTime										: float = 0.0;
var doorMoveTimer										: float = 0.0;

var canOpen												: boolean = false;
var ICopen												: boolean = false;

var atDoor												: boolean = false;

var text												: GameObject;
var npc													: GameObject;
var picture												: GameObject;
var door1												: GameObject;
var door2												: GameObject;
var gui													: GameObject;
var enemy												: GameObject;

function Start () {
	canOpen = false;
	ICopen = false;
	
	doorMoveTimer = 0;
}

function Update () {
	var key : securityBehavior = npc.gameObject.GetComponent(securityBehavior);
	//var badge : mariaBehavior = maria.gameObject.GetComponent(mariaBehavior);
	var badge : pictureScript = picture.gameObject.GetComponent(pictureScript);
	var taken : guiSystem = gui.gameObject.GetComponent(guiSystem);
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	var Enemy : enemyBehavior = enemy.gameObject.GetComponent(enemyBehavior);
	
	if (key.talkCount >= 2) {
		if (!canOpen)
		{
			canOpen = true;
		}
	}
	
	if (badge.tookPicture == true) {
		if (!ICopen)
		{
			ICopen = true;
		}
	}
	
	if (atDoor == true && taken.badgeTaken == true && Input.GetButtonDown("Action"))
	{
		if (!ICopen)
		{
			if (enemy.transform.position == Enemy.waypointOne.position)
			{
				message.displaySubtitle("That isn't your badge. I'll be taking that, you can get your own from Maria", 10);
				message.displayWarning("Badge confiscated", 10);
				message.displayInfo("Security Guard", 10);
				
				taken.badgeTaken = false;
			}
		
			else {
				ICopen = true;
				
				animation.Play(doorOpen.name);
				audio.PlayOneShot(confirm);
				message.displayWarning("Access Granted", 4);
			}
		}
	}
}

function OnTriggerEnter (other : Collider) {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	var taken : guiSystem = gui.gameObject.GetComponent(guiSystem);

	if (other.gameObject.tag == "Player" && this.gameObject.name == "SecurityDoor") {
		if (canOpen) {
			animation.Play(doorOpen.name);
			
			audio.PlayOneShot(confirm);
		}
		
		else {
			audio.PlayOneShot(reject);
			
			message.displaySubtitle("I need to update my security card first.. William might be able to help.", 10);
			message.displayInfo("Greg Clemens", 10);
			message.displayWarning("Door access denied", 10);
		}
	}
	
	if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor")
	{
		atDoor = true;
	
		if (ICopen) {
			animation.Play(doorOpen.name);
			
			audio.PlayOneShot(confirm);
		}
		
		else if (taken.badgeTaken == true && !ICopen)
		{
			audio.PlayOneShot(reject);
		
			message.displayWarning("Press T to Use Badge", 100);
		}
		
		else {
			audio.PlayOneShot(reject);
			
			message.displaySubtitle("I need to update my security badge first.. Maria is in charge of that.", 10);
			message.displayInfo("Greg Clemens", 10);
			message.displayWarning("Door access denied", 10);
		}
	}
}

function OnTriggerExit (other: Collider) {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (other.gameObject.tag == "Player" && this.gameObject.name == "SecurityDoor" && canOpen) {
		animation.Play(doorClose.name);
	}

	if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor" && ICopen) {
		animation.Play(doorClose.name);
	}
	
	if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor")
	{
		message.warning.enabled = false;
	
		atDoor = false;
	}
}

@script RequireComponent(AudioSource)