#pragma strict

// Variables to tell if the NPC can talk, or is talking
//var talk.canTalk												: boolean = false;
var isTalking											: boolean = false;

var canSkip												: boolean = false;

var hasDisplayed										: boolean = false;

var thisDisplayed										: boolean = false;

// Variable to hold how much time has gone by in a conversation
var timer												: float = 0.0;

// Variable to hold how much time is allowed before moving on in conversation
var time												: float = 0.0;

var SnapDist											: float = 0.1;
var Damping												: int = 0;
var MoveSpeed											: int = 0;

var talkDistance										: int = 0;
//var triggerDistance										: int = 0;

// Variable to hold the current part of the conversation
var talkSection											: int = 0;
var talkCount											: int = 0;

// Variable to hold which path the player is on from the decisions they've made
var path												: int = 0;

// Variables to hold the decisions the player can make
var path1												: int = 1;
var path11												: int = 11;
var path12												: int = 12;
var path13												: int = 13;
var path14												: int = 14;
var path111												: int = 111;
var path112												: int = 112;
var path113												: int = 113;
var path114												: int = 114;
var path121												: int = 121;
var path122												: int = 122;
var path123												: int = 123;
var path124												: int = 124;
var path131												: int = 131;
var path132												: int = 132;
var path133												: int = 133;
var path134												: int = 134;
var path141												: int = 141;
var path142												: int = 142;
var path143												: int = 143;
var path144												: int = 144;

var path2												: int = 2;
var path21												: int = 21;
var path22												: int = 22;
var path23												: int = 23;
var path24												: int = 24;
var path211												: int = 211;
var path212												: int = 212;
var path213												: int = 213;
var path214												: int = 214;
var path221												: int = 221;
var path222												: int = 222;
var path223												: int = 223;
var path224												: int = 224;
var path231												: int = 231;
var path232												: int = 232;
var path233												: int = 233;
var path234												: int = 234;
var path241												: int = 241;
var path242												: int = 242;
var path243												: int = 243;
var path244												: int = 244;

var path3												: int = 3;
var path31												: int = 31;
var path32												: int = 32;
var path33												: int = 33;
var path34												: int = 34;
var path311												: int = 311;
var path312												: int = 312;
var path313												: int = 313;
var path314												: int = 314;
var path321												: int = 321;
var path322												: int = 322;
var path323												: int = 323;
var path324												: int = 324;
var path331												: int = 331;
var path332												: int = 332;
var path333												: int = 333;
var path334												: int = 334;
var path341												: int = 341;
var path342												: int = 342;
var path343												: int = 343;
var path344												: int = 344;

var path4												: int = 4;
var path41												: int = 41;
var path42												: int = 42;
var path43												: int = 43;
var path44												: int = 44;
var path411												: int = 411;
var path412												: int = 412;
var path413												: int = 413;
var path414												: int = 414;
var path421												: int = 421;
var path422												: int = 422;
var path423												: int = 423;
var path424												: int = 424;
var path431												: int = 431;
var path432												: int = 432;
var path433												: int = 433;
var path434												: int = 434;
var path441												: int = 441;
var path442												: int = 442;
var path443												: int = 443;
var path444												: int = 444;

var Player												: Transform;
var waypoint											: Transform;

// Variable to hold the holder and text game objects so that we can access its scripts
var holder												: GameObject;
var text												: GameObject;
var pc													: GameObject;
var decide1												: GameObject;
var decide2												: GameObject;
var decide3												: GameObject;
var decide4												: GameObject;
var picture												: GameObject;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {
	
	// Variables to hold the scripts on other game objects so that we can manipulate them from this script
	var cam : cameraScript = holder.gameObject.GetComponent(cameraScript);
	var chosen : timeChanger = holder.gameObject.GetComponent(timeChanger);
	var menu : menuScript = holder.gameObject.GetComponent(menuScript);
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var look : MouseLook = Camera.main.GetComponent(MouseLook);
	var dec1 : decisionScript1 = decide1.gameObject.GetComponent(decisionScript1);
	var dec2 : decisionScript1 = decide2.gameObject.GetComponent(decisionScript1);
	var dec3 : decisionScript1 = decide3.gameObject.GetComponent(decisionScript1);
	var dec4 : decisionScript1 = decide4.gameObject.GetComponent(decisionScript1);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);
	var info : displayInfo = this.gameObject.GetComponent(displayInfo);
	var talk : playerScript = pc.gameObject.GetComponent(playerScript);
	var pic : pictureScript = picture.gameObject.GetComponent(pictureScript);
	
	if (Vector3.Distance(transform.position, Player.position) <= talkDistance && talkCount < 1)
	{
		var rotation = Quaternion.LookRotation(Player.position - transform.position);
   		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		
		// Set can talk to true, this lets the player be able to use the E key to start a conversation
		if (!talk.canTalk)
		{
			talk.canTalk = true;
		}
		
		if (!thisDisplayed)
		{
			thisDisplayed = true;
		}
		
		if (talkCount == 0 && !hasDisplayed && !isTalking) {
		
			message.displaySubtitle("Dr. Clemens, welcome back.", 10);
			message.displayInfo("Maria Figueroa - Press E To Talk", 10);
			
			hasDisplayed = true;
		}
		
		else if (talkCount >= 1 && !hasDisplayed && !isTalking) {
		
			message.displaySubtitle("You have access to the IC Room now.", 5);
			message.displayInfo("Maria Figueroa", 5);
			
			hasDisplayed = true;
		}
	}
	
	if (Vector3.Distance(transform.position, Player.position) > talkDistance)
	{
		// Set can talk to false and end the conversation
		if (talk.canTalk)
		{
			talk.canTalk = false;
		}
		
		if (isTalking)
		{
			isTalking = false;
		}
		
		if (hasDisplayed)
		{
			hasDisplayed = false;
		}
		
		if (!info.canDisplay)
		{
			info.canDisplay = true;
		}
		
		if (thisDisplayed)
		{
			if (message.subtitle.enabled == true)
			{
				message.subtitle.enabled = false;
			}
			
			if (message.info.enabled == true)
			{
				message.info.enabled = false;
			}
			
			thisDisplayed = false;
		}
	}

	// If the player pressed the E key and the NPC can talk, and the game isn't paused
	if (Input.GetButtonDown("Talk") && talk.canTalk && cam.cameraMode == 0 && menu.menuMode == 0) {
	
		if (talkCount != 1) {
		
			if (isTalking) {
				isTalking = false;
			
				// Let the player know they can't talk right now and let the game be able to pause
				cam.canChange = true;
				menu.canMenu = true;
		
				look.enabled = true;
				mouse.enabled = true;
		
				movement.enabled = true;
		
				info.canDisplay = true;
				
				hasDisplayed = false;
				
				message.subtitle.enabled = false;
				message.decision1.enabled = false;
				message.decision2.enabled = false;
				message.decision3.enabled = false;
				message.decision4.enabled = false;
				message.info.enabled = false;
				
				dec1.canClick = false;
				dec2.canClick = false;
				dec3.canClick = false;
				dec4.canClick = false;
			
				message.displayWarning("Conversation Ended..", 4);
			}
		
			else if (!isTalking) {
				// Set the NPC to currently talking
				isTalking = true;
			
				// Make it so the NPC can't talk again and the game can't pause
				cam.canChange = false;
				menu.canMenu = false;
		
				look.enabled = false;
				mouse.enabled = false;
		
				movement.enabled = false;
			
				info.canDisplay = false;
				
				hasDisplayed = false;
		
				// Make sure the conversation starts at the beginning
				talkSection = 0;
		
				// Set the first allowed amount of time for that section of the conversation
				time = .5;
		
				if (talkCount == 0) {
					path = 0;
				}
			}
		}
		
		else {
			message.displayWarning("Nothing more to say..", 4);
		}
	}
	
	// Else if the player pressed the E key and the NPC can't talk, and the game isn't paused
	else if (Input.GetButtonDown("Talk") && !talk.canTalk && cam.cameraMode == 0 && menu.menuMode == 0) {
		
		message.displayWarning("Can't talk right now..", 4);
	}
	
	if (isTalking) {
	
		//timer += Time.deltaTime;
		
		if (canSkip) {
			if (Input.GetButtonDown("Fire2")) {
			
				talkSection++;
				hasDisplayed = false;
			}
		}
		
		if (talkCount == 0) {
			if (talkSection == 0 && !hasDisplayed) {
			
				canSkip = false;
			
				message.displaySubtitle("Dr. Clemens, welcome back.", 10);
				message.displayWarning("Click a decision to continue", 10);
				message.displayInfo("Maria Figueroa", 10);
				
				message.displayDecision("Polite", "Direct", "Annoyed", "", 10);
			
				dec1.canClick = true;
				dec2.canClick = true;
				dec3.canClick = true;
				
				hasDisplayed = true;
			}
			
			else if (talkSection == 1) {
				if (path == path1 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Thank you, Maria. How are you?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path2 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I need to update my badge.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path3 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Yeah, maybe you can tell me why I get a call in the middle of the night telling me that I'm needed right away and yet when I get here I have to waste time updating a badge.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 2) {
				if (path == path1 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I'm well, doctor. And yourself?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Maria Figueroa", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path2 && !hasDisplayed) {
				
					message.displaySubtitle("I can help you with that right now.", 5);
					message.displayWarning("Conversation Ended..", 5);
					message.displayInfo("Maria Figueroa", 5);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
		
					cam.canChange = true;
					menu.canMenu = true;
		
					look.enabled = true;
					mouse.enabled = true;
		
					movement.enabled = true;
				
					info.canDisplay = true;

					talkCount = 1;
					
					talk.canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path3 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I can’t say as to why you were called in here, doctor. That’s outside my purview. As far as the badge, it’s expired. Furthermore, we updated our security system a few weeks ago. Now, I understand your time is important to you. If you’d like, we can upgrade your badge now and in a few minutes you’ll be on your way.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Maria Figueroa", 20);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 3) {
				if (path == path1 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I'm good. William told me I needed to update my badge?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path3 && !hasDisplayed) {
				
					message.displaySubtitle("Fine, what do I have to do?", 5);
					message.displayWarning("Conversation Ended..", 5);
					message.displayInfo("Greg Clemens", 5);
					
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
		
					cam.canChange = true;
					menu.canMenu = true;
		
					look.enabled = true;
					mouse.enabled = true;
		
					movement.enabled = true;
				
					info.canDisplay = true;

					talkCount = 1;
					
					talk.canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 4) {
				if (path == path1 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Yeah, we updated our security systems a few weeks ago and everyone needed new badges. If you’d like I can update your badge right now. It will only take a few minutes.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Maria Figueroa", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 5) {
				if (path == path1 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Sure. Thanks Maria.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 6) {
				if (path == path1 && !hasDisplayed) {
				
					message.displaySubtitle("Not a problem, doctor.", 5);
					message.displayWarning("Conversation Ended..", 5);
					message.displayInfo("Maria Figueroa", 5);
					
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
		
					cam.canChange = true;
					menu.canMenu = true;
		
					look.enabled = true;
					mouse.enabled = true;
		
					movement.enabled = true;
				
					info.canDisplay = true;

					talkCount = 1;
					
					talk.canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
			}
		}
	}
	
	else if (talkCount > 0)
	{
		if (Vector3.Distance(transform.position, waypoint.position) > SnapDist)
		{
			rotation = Quaternion.LookRotation(waypoint.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
			
	 		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
	 		
	 		//animation.CrossFade(animal_walk.name);
		}
			
		else if (Vector3.Distance(transform.position, waypoint.position) <= SnapDist)
		{
			if (transform.position != waypoint.position)
			{
				message.displaySubtitle("Please look towards me and at the camera.", 10);
				message.displayInfo("Maria Figueroa", 10);
				
				if (!pic.canPicture)
	   			{
	   				pic.canPicture = true;
	   			}
			
				transform.position = waypoint.position;
			}
		}
		
		if (pic.canPicture)
		{
			rotation = Quaternion.LookRotation(Player.position - transform.position);
   			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		}
	}
}