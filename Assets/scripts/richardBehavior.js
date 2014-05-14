#pragma strict

// Variables to tell if the NPC can talk, or is talking
//var talk.canTalk												: boolean = false;
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
	var dec1 : decisionScript2 = decide1.gameObject.GetComponent(decisionScript2);
	var dec2 : decisionScript2 = decide2.gameObject.GetComponent(decisionScript2);
	var dec3 : decisionScript2 = decide3.gameObject.GetComponent(decisionScript2);
	var dec4 : decisionScript2 = decide4.gameObject.GetComponent(decisionScript2);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);
	var info : displayInfo = this.gameObject.GetComponent(displayInfo);
	var talk : playerScript = pc.gameObject.GetComponent(playerScript);
	
	if (Vector3.Distance(transform.position, Player.position) <= talkDistance)
	{
		transform.LookAt(Player);
		
		// Set can talk to true, this lets the player be able to use the E key to start a conversation
		if (!talk.canTalk)
		{
			talk.canTalk = true;
		}
		
		if (talkCount == 0 && !hasDisplayed && !isTalking) {
		
			message.displaySubtitle("Greg, you made it. I’m really glad you came.", 10);
			message.displayInfo("Richard Fields - Press E To Talk", 10);
			
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
			
				message.displaySubtitle("Greg, you made it. I’m really glad you came.", 10);
				message.displayWarning("Click a decision to continue", 10);
				message.displayInfo("Richard Fields", 10);
				
				message.displayDecision("Direct", "Friendly", "Annoyed", "", 10);
			
				dec1.canClick = true;
				dec2.canClick = true;
				dec3.canClick = true;
				
				hasDisplayed = true;
			}
			
			else if (talkSection == 1) {
				if (path == path1 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("So what's the big emergency?", 10);
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
				
					message.displaySubtitle("Thanks Rich. It's good to see you.", 10);
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
				
					message.displaySubtitle("I’m not. I had to leave Jill and Angie to come in here. \n I told you I wasn’t ready to do that.", 10);
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
				
					message.displaySubtitle("I didn’t say emergency; I said it was urgent. But yeah, this is serious.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path2 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("You too Greg, you too. Look pal, I wouldn’t have called you in but \n this is serious.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path3 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I know, Greg, and I respect that. I really do. I wouldn’t have asked \n if it wasn’t important.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 3) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("So, what is it?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 4) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("You know the machine has been silent for some time, right? Well, five weeks ago she spoke.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 5) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("What? And you didn’t tell me?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 6) {
				if (!hasDisplayed) {
				
					canSkip = false;
			
					message.displaySubtitle("I know, I know. Thing is, you didn’t want bothered at the time and also.. Well, \n because of the contents of the message, brass didn’t want to \n involve you at first.", 15);
					message.displayWarning("Click a decision to continue", 15);
					message.displayInfo("Richard Fields", 15);
					
					message.displayDecision("Angry", "Questioning", "Understanding", "Silence", 15);
				
					dec1.canClick = true;
					dec2.canClick = true;
					dec3.canClick = true;
					dec4.canClick = true;
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 7) {
				if (path == path11 || path == path21 || path == path31 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Great, so now I’m kept out of the loop on my own machine?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path12 || path == path22 || path == path32 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Why not?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path13 || path == path23 || path == path33 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I understand. I was on leave and you didn’t know what you were dealing with.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
		
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
					hasDisplayed = true;
				}
				
				else if (path == path14 || path == path24 || path == path34 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("...", 10);
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
				if (path == path11 || path == path21 || path == path31 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Greg, it’s not like that.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path12 || path == path22 || path == path32 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Let me explain..", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path13 || path == path23 || path == path33 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Exactly.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
				
				else if (path == path14 || path == path24 || path == path34 && !hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("...", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 9) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Since then it’s been repeating the message, the same message. \n It’s a simple schematic, a modification to the machine.", 15);
					message.displayWarning("Right click to continue", 15);
					message.displayInfo("Richard Fields", 15);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 10) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("What kind of modification?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 11) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("An upgrade. It appears to be some kind of human interface. The fact \n is the schematics that came through were clear, very clear, but they weren’t \n explanatory. We don’t understand the technology that we’re building here.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Richard Fields", 20);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 12) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Then why build it?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 13) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Why? Because we’re stuck here Greg. We’re not getting anymore useful \n information from the machine, you were on leave, and yes, I understand \n why but that doesn’t change the facts. And the fact is the government \n wanted communication flowing again and we were at a dead end buddy, \n a total dead end.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Richard Fields", 20);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 14) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Okay, you were stuck and this message seemed like the solution. \n I get that. So what’s the problem?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 15) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("There’s more. There was more to the message. At the end of the message, \n for each of these five weeks, they included a name.. Your name.", 15);
					message.displayWarning("Right click to continue", 15);
					message.displayInfo("Richard Fields", 15);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 16) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("My name?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 17) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I know. It’s weird. No reason was given, no explanation. Just your name. \n At first we thought it was some kind of sign off, or that they were addressing \n this to you. Hell, we even floated the idea that the message could be coming from you.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Richard Fields", 20);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 18) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Coming from me? Are you daft? The machine’s been on since August. \n It’s been what, a hundred and...", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 19) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("207 days Greg. And every day, corresponds to a new year in the future. \n That’s the system. That means 207 years from now there is a machine \n sending us a message with some schematics and your name attached to it. \n And it’s been sending us that same message for 35 years.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Richard Fields", 20);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 20) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("And you thought it might be me?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 21) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("We floated the idea. We never thought it was likely but think about it, \n every day a new year’s worth of technology was coming through to us. \n For 144 days that went on. We haven’t even scratched the surface \n sifting through that information. So yeah, we floated the idea.", 20);
					message.displayWarning("Right click to continue", 20);
					message.displayInfo("Richard Fields", 20);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 22) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("My god.. None of this makes any sense.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 23) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("I know. That’s what we thought.. at first. But then it occurred to us, \n maybe the message means you’re the one that needs to interface with the machine.", 15);
					message.displayWarning("Right click to continue", 15);
					message.displayInfo("Richard Fields", 15);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 24) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("What would make you think.. wait a minute. You’ve already tried using it, haven’t you?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 25) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Not me personally but--", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 26) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("You know what I mean. I can’t believe this. You didn’t call me \n in here to work on the machine, you want me to be a guinea pig.", 15);
					message.displayWarning("Right click to continue", 15);
					message.displayInfo("Greg Clemens", 15);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 27) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Greg--", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 28) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("No no no.. and tell me, how many others have you tried before calling me in?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 29) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Greg--", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 30) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Tell me.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 31) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Seven..", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 32) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("And what happened to them?", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 33) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Nothing much. A lot of static. A couple headaches. Two nosebleeds.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 34) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Son of a..", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 35) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Nothing severe though. Look, this is messed up, I’ll be the first \n to admit it. At the same time, could it be any more poetic? \n I mean she’s your girl. Maybe she’s just coming to you for help.", 15);
					message.displayWarning("Right click to continue", 15);
					message.displayInfo("Richard Fields", 15);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 36) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("It’s a machine.. it’s not my girl..", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 37) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Greg...", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 38) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("(sigh)... All right, I’ll do it.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 39) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Thanks Greg. Look, this shouldn’t take long, and then either way we’ll have our answer.", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Richard Fields", 10);
					
					hasDisplayed = true;
				}
			}
			
			else if (talkSection == 40) {
				if (!hasDisplayed) {
				
					canSkip = true;
				
					message.displaySubtitle("Yeah..", 10);
					message.displayWarning("Right click to continue", 10);
					message.displayInfo("Greg Clemens", 10);
					
					dec1.canClick = false;
					dec2.canClick = false;
					dec3.canClick = false;
					dec4.canClick = false;
					
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
				Application.LoadLevel(2);
			}
		}
	}
}