﻿using UnityEngine;
using System.Collections;

public class mariaBehaviorOriginal : MonoBehaviour {

	// Variables to tell if the NPC can talk, or is talking
	//bool talk.canTalk		= false;
	public bool isTalking			= false;

	public bool canSkip			= false;

	public bool hasDisplayed		= false;

	public bool thisDisplayed		= false;

	// Variable to hold how much time has gone by in a conversation
	public float timer		= 0.0f;

	// Variable to hold how much time is allowed before moving on in conversation
	public float time		= 0.0f;

	public int Damping		= 0;

	public int talkDistance		= 0;
	public int triggerDistance		= 0;
	
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
	private decisionScript1		dec1;
	private decisionScript1		dec2;
	private decisionScript1		dec3;
	private decisionScript1		dec4;
	private CharacterMotor		movement;
	private displayInfo			info;
	private playerScript		talk;

	void Awake () {

		// Variables to hold the scripts on other game objects so that we can manipulate them from this script
		cam 		= holder.GetComponent <cameraScript> ();
		//chosen 		= holder.GetComponent <timeChanger> ();
		menu 		= holder.GetComponent <menuScript> ();
		message 	= text.GetComponent <uiSystem> ();
		mouse 		= pc.GetComponent <MouseLook> ();
		look 		= Camera.main.GetComponent <MouseLook> ();
		dec1 		= decide1.GetComponent <decisionScript1> ();
		dec2 		= decide2.GetComponent <decisionScript1> ();
		dec3 		= decide3.GetComponent <decisionScript1> ();
		dec4 		= decide4.GetComponent <decisionScript1> ();
		movement 	= pc.GetComponent <CharacterMotor> ();
		info 		= this.GetComponent <displayInfo> ();
		talk 		= pc.GetComponent <playerScript> ();
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
				
				message.displaySubtitle("Dr. Clemens, welcome back.", 10);
				message.displayInfo("Maria Figueroa - Press E To Talk", 10);
				
				hasDisplayed = true;
			}
			
			else if (talkCount >= 1 && !hasDisplayed && !isTalking) {
				
				message.displaySubtitle("You have access to the IC Room now.", 5);
				message.info.enabled = false;
				
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
					time = .5f;
					
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
						
						message.displaySubtitle("I can help you with that right now.", 10);
						message.displayWarning("Security Badge Obtained Press Tab To Open Inventory.", 10);
						message.displayInfo("Maria Figueroa", 10);
						
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
						
						message.displaySubtitle("Fine, what do I have to do?", 10);
						message.displayWarning("Security Badge Obtained Press Tab To Open Inventory.", 10);
						message.displayInfo("Greg Clemens", 10);
						
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
						
						message.displaySubtitle("Not a problem, doctor.", 10);
						message.displayWarning("Security Badge Obtained Press Tab To Open Inventory.", 10);
						message.displayInfo("Maria Figueroa", 10);
						
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
	}
}