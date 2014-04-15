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

var talkDistance										: int = 0;
var triggerDistance										: int = 0;

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

// Variable to hold the holder and text game objects so that we can access its scripts
var holder												: GameObject;
var text												: GameObject;
var pc													: GameObject;
var decide1												: GameObject;
var decide2												: GameObject;
var decide3												: GameObject;
var decide4												: GameObject;

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
	var dec1 : decisionScript = decide1.gameObject.GetComponent(decisionScript);
	var dec2 : decisionScript = decide2.gameObject.GetComponent(decisionScript);
	var dec3 : decisionScript = decide3.gameObject.GetComponent(decisionScript);
	var dec4 : decisionScript = decide4.gameObject.GetComponent(decisionScript);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);
	var info : displayInfo = this.gameObject.GetComponent(displayInfo);
	
	if (Vector3.Distance(transform.position, Player.position) <= talkDistance)
	{
		// Set can talk to true, this lets the player be able to use the E key to start a conversation
		if (!canTalk)
		{
			canTalk = true;
		}
		
		if (talkCount == 0 && !hasDisplayed && !isTalking) {
		
			message.displaySubtitle("Good evening Dr. Clemens.", 10);
			message.displayInfo("William Hebb - Press E To Talk", 100);
			
			hasDisplayed = true;
		}
		
		else if (talkCount == 1 && !hasDisplayed && !isTalking) {

			message.displaySubtitle("Yes Sir?", 5);
			message.displayInfo("William Hebb - Press E To Talk", 100);
			
			hasDisplayed = true;
		}
		
		else if (talkCount == 2 && !hasDisplayed && !isTalking) {
		
			message.displaySubtitle("You take care of yourself.", 5);
			message.info.enabled = false;
			
			hasDisplayed = true;
		}
	}
	
	if (Vector3.Distance(transform.position, Player.position) > talkDistance)
	{
		// Set can talk to false and end the conversation
		if (canTalk)
		{
			canTalk = false;
		}
		
		if (isTalking)
		{
			isTalking = false;
		}
		
		if (talkCount >= 1)
		{
			if (hasDisplayed)
			{
				hasDisplayed = false;
			}
		}
		
		if (!info.canDisplay)
		{
			info.canDisplay = true;
		}
	}

	// If the player pressed the E key and the NPC can talk, and the game isn't paused
	if (Input.GetButtonDown("Talk") && canTalk && cam.cameraMode == 0) {
	
		if (talkCount != 2) {
		
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
	else if (Input.GetButtonDown("Talk") && !canTalk && cam.cameraMode == 0) {
		
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
			
				message.displaySubtitle("It sure is nice seeing you again sir. It's been too long.", 100);
				message.displayWarning("Click a decision to continue", 100);
				message.displayInfo("William Hobb", 100);
				
				message.displayDecision("Apologetic", "Evasive", "Defensive", "Dismissive", 100);
			
				dec1.canClick = true;
				dec2.canClick = true;
				dec3.canClick = true;
				dec4.canClick = true;
				
				hasDisplayed = true;
			}
			
			else if (talkSection == 1) {
				if (path == path1 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I know it has. I.. home had to come first.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path2 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Thanks, William. It’s nice to see you too. How’ve you been?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path3 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I have a daughter at home that might disagree.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path4 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I know. But I’m back now.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
		
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
				
					message.displaySubtitle("Of course it did. You’re absolutely right. I’m sorry if it sounded like I meant anything else. \n I was just trying to tell you how much you’ve been missed.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path2) {
				
					talkSection = 0;
					path = path2;
					talkCount = 1;
				}
				
				else if (path == path3 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Of course you do! I’m sorry if it sounded like I meant anything else. I was just trying to \n tell you how much you’ve been missed.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path4) {
				
					talkSection = 0;
					path = path4;
					talkCount = 1;
				}
			}
			
			else if (talkSection == 3) {
				if (path == path1 || path == path3 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("No, it’s fine. It’s just.. It’s been tough, with Angie.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 4) {
				if (path == path1 || path == path3 && !hasDisplayed) {
				
					canSkip = false;
				
					message.displaySubtitle("I really am sorry, Doctor. How is she doing?", 10);
					message.displayWarning("Click a decision to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					message.displayDecision("Confide", "", "Don't Confide", "", 10);
		
					dec1.canClick = true;
					dec3.canClick = true;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 5) {
				if (path == path11 || path == path31 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("This morning at breakfast.. she’s sitting there in her wheelchair, at the kitchen table, \n and she’s making a mess, this huge mess, trying to lift her spoon to her mouth. \n So I go to take the spoon, to help her, and she says “Daddy I can do it myself!” \n Just like when she was four and learning to ride her bike. And for a split second I almost laugh. \n But then I remember-- she’s not four, she’s fifteen. At four she could still pedal a bike. \n At four she wasn’t wearing diapers. At four she didn’t.. she didn’t sound like a damn moron! \n And I think all this, right there, with her staring straight at me, and it takes everything \n I have in me not to just start bawling there on the spot. \n And somehow, somehow I don’t because I know it would only hurt her more, \n but my God it kills me inside.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Greg Clemens", 20);
		
					dec1.canClick = false;
					dec3.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path13 || path == path33 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("It’s life, you know? Some days are better than others.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
		
					dec1.canClick = false;
					dec3.canClick = false;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 6) {
				if (path == path11 || path == path31 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Jesus..", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path13 || path == path33 && !hasDisplayed) {
				
					canSkip = false;
				
					message.displaySubtitle("I’m so sorry Greg. I don’t know what to say.", 100);
					message.displayWarning("Click a decision to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					message.displayDecision("Optimistic", "Pessimistic", "Determined", "Desperate", 10);
			
					dec1.canClick = true;
					dec2.canClick = true;
					dec3.canClick = true;
					dec4.canClick = true;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 7) {
				if (path == path11 || path == path31 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Jill had been standing at the counter, chopping vegetables for lunch later. She didn’t say anything. \n But after what Angie said the chopping stopped. We never looked at each other. \n We deliberately avoided looking at each other. I think we both knew what \n would happen if we did. So I just stared down at my cereal \n and swirled the flakes around the bowl. That’s how things have been of late.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Greg Clemens", 20);
					
					hasDisplayed = true;
				}
				
				else if (path == path131 || path == path331 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s nothing to say, really. She’s alive-- that’s the most important part. \n The rest will come with time.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path132 || path == path332 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s nothing to say, really. Nothing to be done. The doctors have already admitted as much. \n She’s beyond their help, now.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path133 || path == path333 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s nothing to say, really. She’s going to get better. \n Whatever it takes, she’s going to get better.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path134 || path == path334 && !hasDisplayed) {
				
					canSkip = true;
					
					message.displaySubtitle("There’s nothing to say, really. She has to get better. There has to be something, \n some way for her to get better. There has to.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 8) {
				if (path == path11 || path == path31 && !hasDisplayed) {
				
					canSkip = false;
				
					message.displaySubtitle("I’m so sorry Greg. I don’t know what to say.", 10);
					message.displayWarning("Click a decision to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					message.displayDecision("Optimistic", "Pessimistic", "Determined", "Desperate", 10);
			
					dec1.canClick = true;
					dec2.canClick = true;
					dec3.canClick = true;
					dec4.canClick = true;
					
					hasDisplayed = true;
				}
				
				else if (path == path131 || path == path132 || path == path133 || path == path134) {
				
					talkSection = 0;
					path = path1;
					talkCount = 1;
				}
				
				else if (path == path331 || path == path332 || path == path333 || path == path334) {
				
					talkSection = 0;
					path = path3;
					talkCount = 1;
				}
			}
			
			else if (talkSection == 9) {
				if (path == path111 || path == path311 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s nothing to say, really. She’s alive-- that’s the most important part. \n The rest will come with time.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path112 || path == path312 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s nothing to say, really. Nothing to be done. The doctors have already admitted as much. \n She’s beyond their help, now.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path113 || path == path313 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s nothing to say, really. She’s going to get better. \n Whatever it takes, she’s going to get better.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path114 || path == path314 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s nothing to say, really. She has to get better. There has to be something, \n some way for her to get better. There has to.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
			
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 10) {
				if (path == path111 || path == path112 || path == path113 || path == path114) {
				
					talkSection = 0;
					path = path1;
					talkCount = 1;
				}
				
				else if (path == path311 || path == path312 || path == path313 || path == path314) {
				
					talkSection = 0;
					path = path3;
					talkCount = 1;
				}
			}
		}
		
		if (talkCount == 1) {
			if (talkSection == 0) {
				if (path == path1 || path == path3 || path == path4 && !hasDisplayed) {
				
					canSkip = false;
				
					message.displaySubtitle("Is there anything I can do for you?", 10);
					message.displayWarning("Click a decision to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					message.displayDecision("News", "", "How are you?", "End Conversation", 10);
			
					dec1.canClick = true;
					dec3.canClick = true;
					dec4.canClick = true;
					
					hasDisplayed = true;
				}
				
				else if (path == path2 && !hasDisplayed) {
				
					canSkip = false;
				
					message.displaySubtitle("Oh, alright I suppose. Another day closer to retirement so.. can’t complain. \n Is there anything I can do for you?", 10);
					message.displayWarning("Click a decision to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					message.displayDecision("News", "", "", "End Conversation", 10);
			
					dec1.canClick = true;
					dec4.canClick = true;
					
					hasDisplayed = true;
				}
			}
			
			if (talkSection == 1) {
				if (path == path11 || path == path31 || path == path41 && !hasDisplayed) {
				
					message.displaySubtitle("You know how this place is. The technology may be always changing but nothing else is.", 5);
					message.displayWarning("Key Card Obtained", 10);
					message.displayInfo("William Hobb", 5);
			
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
					
					talkSection = 0;
					path = path1;
					
					canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path21 && !hasDisplayed) {
					
					message.displaySubtitle("You know how this place is. The technology may be always changing but nothing else is.", 5);
					message.displayWarning("Key Card Obtained", 10);
					message.displayInfo("William Hobb", 5);
			
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
					
					talkCount = 2;
					
					canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path13 || path == path33 || path == path43 && !hasDisplayed) {
				
					canSkip = false;
				
					message.displaySubtitle("Oh, alright I suppose. Another day closer to retirement so.. can’t complain. \n Is there anything I can do for you?", 10);
					message.displayWarning("Click a decision to continue", 10);
					message.displayInfo("William Hobb", 10);
					
					message.displayDecision("News", "", "", "End Conversation", 10);
			
					dec1.canClick = true;
					dec3.canClick = false;
					dec4.canClick = true;
					
					hasDisplayed = true;
				}
				
				else if (path == path14 || path == path34 || path == path44 && !hasDisplayed) {
				
					message.displaySubtitle("I'll see you later.", 5);
					message.displayWarning("Key Card Obtained", 10);
					message.displayInfo("William Hobb", 5);
			
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
					
					talkSection = 0;
					path = path1;
					
					canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path24 && !hasDisplayed) {
					
					message.displaySubtitle("I'll see you later.", 5);
					message.displayWarning("Key Card Obtained", 10);
					message.displayInfo("William Hobb", 5);
			
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
					
					talkCount = 2;
					
					canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
			}
			
			if (talkSection == 2) {
				if (path == path131 || path == path331 || path == path431 && !hasDisplayed) {
				
					message.displaySubtitle("You know how this place is. The technology may be always changing but nothing else is.", 5);
					message.displayWarning("Key Card Obtained", 10);
					message.displayInfo("William Hobb", 5);
			
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
					
					talkCount = 2;
					
					canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path134 || path == path334 || path == path434 && !hasDisplayed) {
				
					message.displaySubtitle("I'll see you later.", 5);
					message.displayWarning("Key Card Obtained", 10);
					message.displayInfo("William Hobb", 5);
			
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
					
					talkCount = 2;
				
					canSkip = false;
					
					canTalk = true;
					isTalking = false;
					
					hasDisplayed = true;
				}
			}
		}
	}
}