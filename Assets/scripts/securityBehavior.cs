using UnityEngine;
using System.Collections;

public class securityBehavior : MonoBehaviour {

	// Variables to tell if the NPC can talk, or is talking
	//bool talk.canTalk		= false;
	public bool isTalking		= false;

	public bool canSkip		= false;

	public bool hasDisplayed	= false;

	public bool thisDisplayed	= false;
	
	// Variable to hold how much time has gone by in a conversation
	public float timer		= 0.0f;
	
	// Variable to hold how much time is allowed before moving on in conversation
	public float time		= 0.0f;

	public int Damping		= 0;

	public int talkDistance	= 0;
	public int triggerDistance	= 0;
	
	// Variable to hold the current part of the conversation
	public int talkSection		= 0;
	public int talkCount		= 0;
	
	// Variable to hold which path the player is on from the decisions they've made
	public int path	= 0;

	// Variables to hold the decisions the player can make
	public int path1												= 1;
	public int path11												= 11;
	public int path12												= 12;
	public int path13												= 13;
	public int path14												= 14;
	public int path111												= 111;
	public int path112												= 112;
	public int path113												= 113;
	public int path114												= 114;
	public int path121												= 121;
	public int path122												= 122;
	public int path123												= 123;
	public int path124												= 124;
	public int path131												= 131;
	public int path132												= 132;
	public int path133												= 133;
	public int path134												= 134;
	public int path141												= 141;
	public int path142												= 142;
	public int path143												= 143;
	public int path144												= 144;
	
	public int path2												= 2;
	public int path21												= 21;
	public int path22												= 22;
	public int path23												= 23;
	public int path24												= 24;
	public int path211												= 211;
	public int path212												= 212;
	public int path213												= 213;
	public int path214												= 214;
	public int path221												= 221;
	public int path222												= 222;
	public int path223												= 223;
	public int path224												= 224;
	public int path231												= 231;
	public int path232												= 232;
	public int path233												= 233;
	public int path234												= 234;
	public int path241												= 241;
	public int path242												= 242;
	public int path243												= 243;
	public int path244												= 244;
	
	public int path3												= 3;
	public int path31												= 31;
	public int path32												= 32;
	public int path33												= 33;
	public int path34												= 34;
	public int path311												= 311;
	public int path312												= 312;
	public int path313												= 313;
	public int path314												= 314;
	public int path321												= 321;
	public int path322												= 322;
	public int path323												= 323;
	public int path324												= 324;
	public int path331												= 331;
	public int path332												= 332;
	public int path333												= 333;
	public int path334												= 334;
	public int path341												= 341;
	public int path342												= 342;
	public int path343												= 343;
	public int path344												= 344;
	
	public int path4												= 4;
	public int path41												= 41;
	public int path42												= 42;
	public int path43												= 43;
	public int path44												= 44;
	public int path411												= 411;
	public int path412												= 412;
	public int path413												= 413;
	public int path414												= 414;
	public int path421												= 421;
	public int path422												= 422;
	public int path423												= 423;
	public int path424												= 424;
	public int path431												= 431;
	public int path432												= 432;
	public int path433												= 433;
	public int path434												= 434;
	public int path441												= 441;
	public int path442												= 442;
	public int path443												= 443;
	public int path444												= 444;

	public Transform Player;
	
	// Variable to hold the holder and text game objects so that we can access its scripts
	public GameObject holder;
	public GameObject text;
	public GameObject pc;
	public GameObject decide1;
	public GameObject decide2;
	public GameObject decide3;
	public GameObject decide4;

	private cameraScript		cam;
	//private timeChanger			chosen;
	private menuScript			menu;
	private uiSystem			message;
	private MouseLook			mouse;
	private MouseLook			look;
	private decisionScript		dec1;
	private decisionScript		dec2;
	private decisionScript		dec3;
	private decisionScript		dec4;
	private CharacterMotor		movement;
	private displayInfo			info;
	private playerScript		talk;

	void Awake () {

		// Variables to hold the scripts on other game objects so that we can manipulate them from this script
		cam = holder.GetComponent <cameraScript> ();
		//chosen = holder.GetComponent <timeChanger> ();
		menu = holder.GetComponent <menuScript> ();
		message = text.GetComponent <uiSystem> ();
		mouse = pc.GetComponent <MouseLook> ();
		look = Camera.main.GetComponent <MouseLook> ();
		dec1 = decide1.GetComponent <decisionScript> ();
		dec2 = decide2.GetComponent <decisionScript> ();
		dec3 = decide3.GetComponent <decisionScript> ();
		dec4 = decide4.GetComponent <decisionScript> ();
		movement = pc.GetComponent <CharacterMotor> ();
		info = this.GetComponent <displayInfo> ();
		talk = pc.GetComponent <playerScript> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance(transform.position, Player.position) <= talkDistance)
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
				message.displayInfo("William Hebb", 5);
				
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
					if (talkCount == 0)
					{
						talkSection = 0;
						path = 0;
					}
					
					// Set the first allowed amount of time for that section of the conversation
					time = .5f;
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
						
						message.displaySubtitle("Of course it did. You’re absolutely right. I’m sorry if it sounded like I meant anything else. I was just trying to tell you how much you’ve been missed.", 10);
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
						
						message.displaySubtitle("Of course you do! I’m sorry if it sounded like I meant anything else. I was just trying to tell you how much you’ve been missed.", 10);
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
						
						message.displaySubtitle("This morning at breakfast.. she’s sitting there in her wheelchair, at the kitchen table, and she’s making a mess, this huge mess, trying to lift her spoon to her mouth. So I go to take the spoon, to help her, and she says “Daddy I can do it myself!” Just like when she was four and learning to ride her bike. And for a split second I almost laugh. But then I remember-- she’s not four, she’s fifteen. At four she could still pedal a bike. At four she wasn’t wearing diapers. At four she didn’t.. she didn’t sound like a damn moron! And I think all this, right there, with her staring straight at me, and it takes everything I have in me not to just start bawling there on the spot. And somehow, somehow I don’t because I know it would only hurt her more, but my God it kills me inside.", 20);
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
						
						message.displaySubtitle("Jill had been standing at the counter, chopping vegetables for lunch later. She didn’t say anything. But after what Angie said the chopping stopped. We never looked at each other. We deliberately avoided looking at each other. I think we both knew what would happen if we did. So I just stared down at my cereal and swirled the flakes around the bowl. That’s how things have been of late.", 20);
						message.displayWarning("Right click to continue", 20);
						message.displayInfo("Greg Clemens", 20);
						
						hasDisplayed = true;
					}
					
					else if (path == path131 || path == path331 && !hasDisplayed) {
						
						canSkip = true;
						
						message.displaySubtitle("There’s nothing to say, really. She’s alive-- that’s the most important part. The rest will come with time.", 10);
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
						
						message.displaySubtitle("There’s nothing to say, really. Nothing to be done. The doctors have already admitted as much. She’s beyond their help, now.", 10);
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
						
						message.displaySubtitle("There’s nothing to say, really. She’s going to get better. Whatever it takes, she’s going to get better.", 10);
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
						
						message.displaySubtitle("There’s nothing to say, really. She has to get better. There has to be something, some way for her to get better. There has to.", 10);
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
						
						message.displaySubtitle("There’s nothing to say, really. She’s alive-- that’s the most important part. The rest will come with time.", 10);
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
						
						message.displaySubtitle("There’s nothing to say, really. Nothing to be done. The doctors have already admitted as much. She’s beyond their help, now.", 10);
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
						
						message.displaySubtitle("There’s nothing to say, really. She’s going to get better. Whatever it takes, she’s going to get better.", 10);
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
						
						message.displaySubtitle("There’s nothing to say, really. She has to get better. There has to be something, some way for her to get better. There has to.", 10);
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
			//------------------------------------------------------------------------------------------------------------------------------------------
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
						
						message.displaySubtitle("Oh, alright I suppose. Another day closer to retirement so.. can’t complain. Is there anything I can do for you?", 10);
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
						
						canSkip = false;
						
						message.displaySubtitle("You know how this place is. The technology may be always changing but nothing else is.", 10);
						message.displayWarning("Click a decision to continue", 10);
						message.displayInfo("William Hobb", 10);
						
						message.displayDecision("", "", "How are you?", "End Conversation", 10);
						
						dec1.canClick = false;
						dec3.canClick = true;
						dec4.canClick = true;
						
						hasDisplayed = true;
					}
					
					else if (path == path21 && !hasDisplayed) {
						
						message.displaySubtitle("You know how this place is. The technology may be always changing but nothing else is. Oh, speaking of technology changing: Here is your new key card.", 10);
						message.displayWarning("Key Card Obtained\nPress Tab To Open Inventory", 10);
						message.displayInfo("William Hobb", 10);
						
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
						
						talk.canTalk = true;
						isTalking = false;
						
						hasDisplayed = true;
					}
					
					else if (path == path13 || path == path33 || path == path43 && !hasDisplayed) {
						
						canSkip = false;
						
						message.displaySubtitle("Oh, alright I suppose. Another day closer to retirement so.. can’t complain. Is there anything I can do for you?", 10);
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
						message.displayWarning("Conversation Ended.", 10);
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
						
						talk.canTalk = true;
						isTalking = false;
						
						hasDisplayed = true;
					}
					
					else if (path == path24 && !hasDisplayed) {
						
						message.displaySubtitle("I'll see you later.", 5);
						message.displayWarning("Conversation Ended.", 10);
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
						path = path2;
						
						talk.canTalk = true;
						isTalking = false;
						
						hasDisplayed = true;
					}
				}
				
				if (talkSection == 2) {
					if (path == path131 || path == path331 || path == path431 && !hasDisplayed) {
						
						message.displaySubtitle("You know how this place is. The technology may be always changing but nothing else is. Oh, speaking of technology changing: Here is your new key card.", 10);
						message.displayWarning("Key Card Obtained\nPress Tab To Open Inventory", 10);
						message.displayInfo("William Hobb", 10);
						
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
						
						talk.canTalk = true;
						isTalking = false;
						
						hasDisplayed = true;
					}
					
					else if (path == path134 || path == path334 || path == path434 && !hasDisplayed) {
						
						message.displaySubtitle("I'll see you later.", 5);
						message.displayWarning("Conversation Ended.", 10);
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
						
						talkSection = 1;
						path = path13;
						
						canSkip = false;
						
						talk.canTalk = true;
						isTalking = false;
						
						hasDisplayed = true;
					}
					
					else if (path == path113 || path == path313 || path == path413 && !hasDisplayed)
					{	
						message.displaySubtitle("Oh, alright I suppose. Another day closer to retirement so.. can’t complain. Here's your new key card.", 10);
						message.displayWarning("Key Card Obtained\nPress Tab To Open Inventory", 10);
						message.displayInfo("William Hobb", 10);
						
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
						
						talk.canTalk = true;
						isTalking = false;
						
						hasDisplayed = true;
					}
					
					else if (path == path114 || path == path314 || path == path414 && !hasDisplayed)
					{	
						message.displaySubtitle("I'll see you later.", 5);
						message.displayWarning("Conversation Ended.", 10);
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
						
						talkSection = 1;
						path = path11;
						
						talk.canTalk = true;
						isTalking = false;
						
						hasDisplayed = true;
					}
				}
			}
		}
	}
}