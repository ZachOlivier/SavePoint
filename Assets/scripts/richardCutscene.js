#pragma strict

// Variables to tell if the NPC can talk, or is talking
var canTalk												: boolean = false;
var isTalking											: boolean = false;

var canSkip												: boolean = false;

var hasDisplayed										: boolean = false;

// Variable to hold how much time has gone by in a conversation
var timer												: float = 0.0;

// Variable to hold how much time is allowed before moving on in conversation
var time												: float = 0.0;

// Variable to hold the current part of the conversation
var talkSection											: int = 0;
var talkCount											: int = 0;

// Variable to hold the holder and text game objects so that we can access its scripts
var text												: GameObject;

// This function only fires once during the start of this script
function Start () {
	talkSection = 0;

	isTalking = true;
}

// This function fires over and over again throughout the life of this script
function Update () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	
	if (isTalking) {
		
		if (canSkip) {
			if (Input.GetButtonDown("Fire2")) {
			
				talkSection++;
				hasDisplayed = false;
			}
		}
		
		if (talkCount == 0) {
			if (talkSection == 0 && !hasDisplayed) {
			
				canSkip = true;
			
				message.displaySubtitle("A few minutes later...", 10);
				message.displayWarning("Right click to continue", 10);
				
				hasDisplayed = true;
			}
			
			else if (talkSection == 1) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Okay, now just relax Greg. I’m going to turn it on now. \n Let me know if you feel any pain.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 2) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Okay. Right now I’m not feeling anything, except maybe a little-- (gasps)", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					talkCount = 1;
					
					hasDisplayed = true;
				}
			}
		}
				
		else if (talkCount == 1)
		{
			timer += Time.deltaTime;
			
			if (timer >= 4)
			{
				Camera.main.enabled = false;
				
				timer = 0;
				talkCount = 2;
			}
		}
	}
}