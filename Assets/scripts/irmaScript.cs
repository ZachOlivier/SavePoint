using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class irmaScript : MonoBehaviour {

	public AudioClip irmaIntro;
	public AudioClip riotingAmbience;
	public AudioClip explosion;
	public AudioClip sentBack;
	public AudioClip gunShot;

	public bool audioPlayed;

	// Variables to tell if the NPC can talk, or is talking
	public bool isTalking			= false;
	
	public bool canSkip				= false;
	
	public bool hasDisplayed		= false;
	
	public bool thisDisplayed		= false;

	public bool firstPathOne		= false;
	public bool firstPathTwo		= false;
	public bool firstPathThree		= false;
	public bool firstPathFour		= false;
	public bool pathOneDone			= false;
	public bool pathTwoDone			= false;
	public bool pathThreeDone		= false;
	public bool pathFourDone		= false;

	public int btnW	= 0;
	public int btnH	= 0;
	public int btnX	= 0;
	public int btnY	= 0;
	
	// Variable to hold how much time has gone by in a conversation
	public float timer		= 0.0f;
	
	// Variable to hold how much time is allowed before moving on in conversation
	public float time		= 0.0f;
	
	public float SnapDist	= 0.1f;

	public float shake		= 0.0f;
	
	public int Damping		= 0;
	public int MoveSpeed	= 0;

	public int triggerDistance		= 0;
	
	// Variable to hold the current part of the conversation
	public int talkSection		= 0;
	public int talkCount		= 0;
	public int talkNumber		= 0;

	// Variable to hold which path the player is on from the decisions they've made
	public int path	= 0;
	
	// Variables to hold the decisions the player can make
	private int path1												= 1;
	private int path11												= 11;
	private int path12												= 12;
	private int path13												= 13;
	private int path14												= 14;
	private int path111												= 111;
	private int path112												= 112;
	private int path113												= 113;
	private int path114												= 114;
	private int path121												= 121;
	private int path122												= 122;
	private int path123												= 123;
	private int path124												= 124;
	private int path131												= 131;
	private int path132												= 132;
	private int path133												= 133;
	private int path134												= 134;
	private int path141												= 141;
	private int path142												= 142;
	private int path143												= 143;
	private int path144												= 144;
	
	private int path2												= 2;
	private int path21												= 21;
	private int path22												= 22;
	private int path23												= 23;
	private int path24												= 24;
	private int path211												= 211;
	private int path212												= 212;
	private int path213												= 213;
	private int path214												= 214;
	private int path221												= 221;
	private int path222												= 222;
	private int path223												= 223;
	private int path224												= 224;
	private int path231												= 231;
	private int path232												= 232;
	private int path233												= 233;
	private int path234												= 234;
	private int path241												= 241;
	private int path242												= 242;
	private int path243												= 243;
	private int path244												= 244;
	
	private int path3												= 3;
	private int path31												= 31;
	private int path32												= 32;
	private int path33												= 33;
	private int path34												= 34;
	private int path311												= 311;
	private int path312												= 312;
	private int path313												= 313;
	private int path314												= 314;
	private int path321												= 321;
	private int path322												= 322;
	private int path323												= 323;
	private int path324												= 324;
	private int path331												= 331;
	private int path332												= 332;
	private int path333												= 333;
	private int path334												= 334;
	private int path341												= 341;
	private int path342												= 342;
	private int path343												= 343;
	private int path344												= 344;
	
	private int path4												= 4;
	private int path41												= 41;
	private int path42												= 42;
	private int path43												= 43;
	private int path44												= 44;
	private int path411												= 411;
	private int path412												= 412;
	private int path413												= 413;
	private int path414												= 414;
	private int path421												= 421;
	private int path422												= 422;
	private int path423												= 423;
	private int path424												= 424;
	private int path431												= 431;
	private int path432												= 432;
	private int path433												= 433;
	private int path434												= 434;
	private int path441												= 441;
	private int path442												= 442;
	private int path443												= 443;
	private int path444												= 444;

	public Transform waypoint;
	public Transform cameraMain;

	public Vector3 camPosition;
	
	// Variable to hold the holder and text game objects so that we can access its scripts
	public GameObject holder;
	public GameObject text;
	public GameObject Core;
	public GameObject Daphne;
	public GameObject scepterBroken;
	public GameObject Scepter;
	
	private cameraScript		cam;
	//private timeChanger			chosen;
	private menuScript			menu;
	private uiSystem			message;
	private MouseLook			mouse;
	private MouseLook			look;
	private CharacterMotor		movement;
	private playerScript		talk;
	private displayInfo			core;
	private icScript			ic;
	private displayInfo			daphne;
	private displayInfo			scepter;
	private displayInfo			okScepter;

	void Awake () {

		// Variables to hold the scripts on other game objects so that we can manipulate them from this script
		cam 		= holder.GetComponent <cameraScript> ();
		//chosen 		= holder.GetComponent <timeChanger> ();
		menu 		= holder.GetComponent <menuScript> ();
		message 	= text.GetComponent <uiSystem> ();
		mouse 		= this.GetComponent <MouseLook> ();
		look 		= Camera.main.GetComponent <MouseLook> ();
		movement 	= this.GetComponent <CharacterMotor> ();
		talk 		= this.GetComponent <playerScript> ();
		core 		= Core.GetComponent <displayInfo> ();
		daphne		= Daphne.GetComponent <displayInfo> ();
		ic			= Core.GetComponent <icScript> ();
		scepter		= scepterBroken.GetComponent <displayInfo> ();
		okScepter	= Scepter.GetComponent <displayInfo> ();
	}

	// Use this for initialization
	void Start () {
	
		movement.enabled = false;
		menu.canMenu = false;
		cam.canChange = false;
		time = 4f;
		timer = 0f;
		talkCount = 0;
		talkSection = 0;
		talkNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (canSkip) {
			if (Input.GetButtonDown("Fire2")) {
				
				talkSection++;
				hasDisplayed = false;
			}
		}

		if (talkNumber == 0 && talkCount >= 6)
		{
			if (!audio.isPlaying && talkCount == 6)
			{
				holder.audio.volume = .1f;

				audio.clip = riotingAmbience;
				audio.loop = true;
				audio.volume = .5f;

				audio.Play();
			}

			else if (!audio.isPlaying && talkCount == 7)
			{
				holder.audio.volume = .1f;
				
				audio.clip = riotingAmbience;
				audio.loop = true;
				audio.volume = .7f;
				
				audio.Play();
			}
		}

		/*if (talkCount == 3 && Input.GetButtonDown("Talk"))
		{
			talkCount = 1000;
			talkSection = 1000;
			talkNumber = 1000;

			message.subtitle.enabled = false;
			message.fourDecision1.enabled = false;
			message.fourDecision2.enabled = false;
			message.fourDecision3.enabled = false;
			message.fourDecision4.enabled = false;
			message.info.enabled = false;

			// Let the player know they can't talk right now and let the game be able to pause
			cam.canChange = true;
			menu.canMenu = true;
			
			look.enabled = true;
			mouse.enabled = true;
			
			movement.enabled = true;
			
			hasDisplayed = false;
			
			dec1.canClick = false;
			dec2.canClick = false;
			dec3.canClick = false;
			dec4.canClick = false;

			core.coreDisplay = true;
			
			message.displayWarning("Conversation Ended\nAccess to IC-Machine Granted", 10);
		}*/

		if (talkNumber == 0)
		{
			if (talkCount == 0)
			{
				timer += Time.deltaTime;
				
				message.displaySubtitle("(Gasping and Panting) God.. Oh God... What just happened?", 6);
				message.displayInfo("Greg Clemens", 6);
				
				if (timer >= time)
				{
					talkCount = 1;
				}
			}

			else if (talkCount == 1)
			{
				if (!hasDisplayed)
				{
					message.displayWarning("Press E to Stand Up", 1000);

					hasDisplayed = true;
				}

				if (Input.GetButtonDown("Talk"))
				{
					transform.eulerAngles = new Vector3(0, -90, 0);
					this.transform.position = waypoint.transform.position;
					
					movement.enabled = true;

					message.warning.enabled = false;

					if (Application.loadedLevel == 3)
					{
						time = 6f;
						timer = 0f;

						talkCount = 2;
					}

					else if (Application.loadedLevel == 4)
					{
						menu.canMenu = true;
						cam.canChange = true;

						talkCount = 0;
						talkSection = 0;
						talkNumber = 1;
					}
				}
			}

			else if (talkCount == 2)
			{
				timer += Time.deltaTime;

				message.displaySubtitle("W... Where am I? What’s happening?", 5);
				message.displayInfo("Greg Clemens", 5);

				if (timer > time)
				{
					hasDisplayed = false;

					talkCount = 3;
				}
			}

			else if (talkCount == 3 && !hasDisplayed)
			{
				if (talkSection == 0)
				{
					look.enabled = false;
					mouse.enabled = false;
					
					movement.enabled = false;

					message.irmaTalk = true;

					canSkip = true;

					if (!audioPlayed)
					{
						holder.audio.volume = .1f;

						audio.PlayOneShot(irmaIntro);

						audioPlayed = true;
					}
					
					message.displaySubtitle("Hello Dr. Clemens. I’m IRMA, your Internal Recall/Memory Assistant.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Unknown Voice", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 1)
				{
					canSkip = true;

					if (audioPlayed)
					{
						audio.Stop();

						holder.audio.volume = .4f;

						audioPlayed = false;
					}
					
					message.displaySubtitle("What the hell? You’re my what?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 2)
				{
					canSkip = false;
					
					message.displaySubtitle("Internal Recall/Memory Assistant. Patented in February of 2102 by the Telva Corporation. My primary function is to serve as a cognitive enhancement tool. I have also been modified to grant you remote access to the operating system of the Iris-Chronus machine.", 100);
					message.displayWarning("Click a decision to continue", 100);
					message.displayInfo("IRMA", 100);

					if (firstPathOne)
					{
						if (pathOneDone && !pathTwoDone && !pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "Modified?", "2102?", "Iris-Chronus Machine?", 100);
						}

						else if (pathOneDone && !pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "Modified?", "2102?", "", 100);
						}

						else if (pathOneDone && !pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "Modified?", "", "Iris-Chronus Machine?", 100);;
						}

						else if (pathOneDone && pathTwoDone && !pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "", "2102?", "Iris-Chronus Machine?", 100);
						}

						else if (pathOneDone && !pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "Modified?", "", "", 100);
						}

						else if (pathOneDone && pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "", "2102?", "", 100);
						}
						
						else if (pathOneDone && pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "", "", "Iris-Chronus Machine?", 100);
						}
					}

					else if (firstPathTwo)
					{
						if (!pathOneDone && pathTwoDone && !pathThreeDone && !pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "2102?", "Iris-Chronus Machine?", 100);
						}
						
						else if (!pathOneDone && pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "2102?", "", 100);
						}
						
						else if (!pathOneDone && pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "", "Iris-Chronus Machine?", 100);
						}
						
						else if (pathOneDone && pathTwoDone && !pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "", "2102?", "Iris-Chronus Machine?", 100);
						}
						
						else if (!pathOneDone && pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "", "", 100);
						}
						
						else if (pathOneDone && pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "", "2102?", "", 100);
						}
						
						else if (pathOneDone && pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "", "", "Iris-Chronus Machine?", 100);
						}
					}

					else if (firstPathThree)
					{
						if (!pathOneDone && !pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "Modified?", "", "Iris-Chronus Machine?", 100);
						}
						
						else if (!pathOneDone && !pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "Modified?", "", "", 100);
						}
						
						else if (pathOneDone && !pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "Modified?", "", "Iris-Chronus Machine?", 100);
						}
						
						else if (!pathOneDone && pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "", "Iris-Chronus Machine?", 100);
						}
						
						else if (!pathOneDone && pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "", "", 100);
						}
						
						else if (pathOneDone && !pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "Modified?", "", "", 100);
						}
						
						else if (pathOneDone && pathTwoDone && pathThreeDone && !pathFourDone)
						{
							message.display4Decision("", "", "", "Iris-Chronus Machine?", 100);
						}
					}

					else if (firstPathFour)
					{
						if (!pathOneDone && !pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "Modified?", "2102?", "", 100);
						}
						
						else if (!pathOneDone && !pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "Modified?", "", "", 100);
						}
						
						else if (pathOneDone && !pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "Modified?", "2102?", "", 100);
						}
						
						else if (!pathOneDone && pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "2102?", "", 100);
						}
						
						else if (!pathOneDone && pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("Cognitive Enhancement Tool?", "", "", "", 100);
						}
						
						else if (pathOneDone && !pathTwoDone && pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "Modified?", "", "", 100);
						}
						
						else if (pathOneDone && pathTwoDone && !pathThreeDone && pathFourDone)
						{
							message.display4Decision("", "", "2102?", "", 100);
						}
					}

					else {
						message.display4Decision("Cognitive Enhancement Tool?", "Modified?", "2102?", "Iris-Chronus Machine?", 100);
					}
					
					hasDisplayed = true;
				}

				if (path == 1)
				{
					if (talkSection == 3)
					{
						if (!firstPathOne && !firstPathTwo && !firstPathThree && !firstPathFour)
						{
							firstPathOne = true;
						}

						canSkip = true;
						
						message.displaySubtitle("An implant in your brain’s right frontal-lobe. As such, you may access my digital database using the same neural pathways that already exist naturally as part of your short term memory. As a result, you have nearly instant access to any information stored in said database. Would you like to access the database now? I have been programmed with a tutorial to guide you through the experience.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}
					
					else if (talkSection == 4)
					{
						pathOneDone = true;

						path = 0;

						if (pathTwoDone && pathThreeDone && pathFourDone)
						{	
							message.subtitle.enabled = false;
							message.fourDecision1.enabled = false;
							message.fourDecision2.enabled = false;
							message.fourDecision3.enabled = false;
							message.fourDecision4.enabled = false;
							message.info.enabled = false;

							look.enabled = true;
							mouse.enabled = true;
							
							movement.enabled = true;
							
							hasDisplayed = false;
							
							message.displayWarning("Conversation Ended\nAccess to IC-Machine Granted", 10);

							timer = 0;
							time = 5;
							talkNumber = 0;
							talkCount = 4;
							talkSection = 0;
						}
						
						else
						{
							talkSection = 2;
						}
					}
				}

				else if (path == 2)
				{
					if (talkSection == 3)
					{
						if (!firstPathOne && !firstPathTwo && !firstPathThree && !firstPathFour)
						{
							firstPathTwo = true;
						}

						canSkip = true;
						
						message.displaySubtitle("You said you were modified. Modified by who?", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 4)
					{
						canSkip = true;
						
						message.displaySubtitle("I’m sorry Dr. Clemens. That information is unavailable.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 5)
					{
						canSkip = true;
						
						message.displaySubtitle("Unavailable? You mean because you don’t know or because you can’t tell me?", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 6)
					{
						canSkip = true;
						
						message.displaySubtitle("I’m sorry Dr. Clemens. That information is unavailable.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 7)
					{
						canSkip = true;
						
						message.displaySubtitle("Okay, great.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 8)
					{
						pathTwoDone = true;

						path = 0;

						if (pathOneDone && pathThreeDone && pathFourDone)
						{
							message.subtitle.enabled = false;
							message.fourDecision1.enabled = false;
							message.fourDecision2.enabled = false;
							message.fourDecision3.enabled = false;
							message.fourDecision4.enabled = false;
							message.info.enabled = false;
							
							look.enabled = true;
							mouse.enabled = true;
							
							movement.enabled = true;
							
							hasDisplayed = false;
							
							message.displayWarning("Conversation Ended\nAccess to IC-Machine Granted", 10);

							timer = 0;
							time = 5;
							talkNumber = 0;
							talkCount = 4;
							talkSection = 0;
						}
						
						else
						{
							talkSection = 2;
						}
					}
				}

				else if (path == 3)
				{
					if (talkSection == 3)
					{
						if (!firstPathOne && !firstPathTwo && !firstPathThree && !firstPathFour)
						{
							firstPathThree = true;
						}
						
						canSkip = true;
						
						message.displaySubtitle("Wait. 2102? You’re saying that I’m in the future?", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 4)
					{
						canSkip = true;
						
						message.displaySubtitle("No. To say that would not only be false but illogical. It is impossible to exist in the future; the point in time one currently occupies is, by definition, one’s present.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 5)
					{
						canSkip = true;
						
						message.displaySubtitle("Yeah, no, I know that. But this is the year 2102?", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 6)
					{
						canSkip = true;
						
						message.displaySubtitle("That is correct.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 7)
					{
						canSkip = true;
						
						message.displaySubtitle("Wait... no no no... let me think. I need to think. I was in the lab. Richard had hooked me up to the new IC-Machine. He turned it on. No... no it has to still be 2018. I can’t be in the future, that’s impossible. Even if there was a way to transport particles larger than the sub-atomic level... you can’t send anything forward. You can’t. It can’t be done. This can’t be real.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 8)
					{
						canSkip = true;
						
						message.displaySubtitle("I am sorry, Dr. Clemens but I am unable to understand this most recent string of thoughts. Were you attempting to communicate with me?", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 9)
					{
						canSkip = true;
						
						message.displaySubtitle("No... no just thinking out loud.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 10)
					{
						canSkip = true;
						
						message.displaySubtitle("Very well.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 11)
					{
						pathThreeDone = true;

						path = 0;

						if (pathOneDone && pathTwoDone && pathFourDone)
						{
							message.subtitle.enabled = false;
							message.fourDecision1.enabled = false;
							message.fourDecision2.enabled = false;
							message.fourDecision3.enabled = false;
							message.fourDecision4.enabled = false;
							message.info.enabled = false;
							
							look.enabled = true;
							mouse.enabled = true;
							
							movement.enabled = true;
							
							hasDisplayed = false;
							
							message.displayWarning("Conversation Ended\nAccess to IC-Machine Granted", 10);

							timer = 0;
							time = 5;
							talkNumber = 0;
							talkCount = 4;
							talkSection = 0;
						}
						
						else
						{
							talkSection = 2;
						}
					}
				}

				else if (path == 4)
				{
					if (talkSection == 3)
					{
						if (!firstPathOne && !firstPathTwo && !firstPathThree && !firstPathFour)
						{
							firstPathFour = true;
						}
						
						canSkip = true;
						
						message.displaySubtitle("You said I’m remotely connected to an IC-Machine. So there’s one nearby?", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("Greg Clemens", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 4)
					{
						canSkip = true;
						
						message.displaySubtitle("Very near. In this room, in fact.", 100);
						message.displayWarning("Right click to continue", 100);
						message.displayInfo("IRMA", 100);
						
						hasDisplayed = true;
					}

					else if (talkSection == 5)
					{
						pathFourDone = true;

						path = 0;

						if (pathOneDone && pathTwoDone && pathThreeDone)
						{
							message.subtitle.enabled = false;
							message.fourDecision1.enabled = false;
							message.fourDecision2.enabled = false;
							message.fourDecision3.enabled = false;
							message.fourDecision4.enabled = false;
							message.info.enabled = false;
							
							look.enabled = true;
							mouse.enabled = true;
							
							movement.enabled = true;
							
							hasDisplayed = false;
							
							message.displayWarning("Conversation Ended\nAccess to IC-Machine Granted", 10);

							timer = 0;
							time = 5;
							talkNumber = 0;
							talkCount = 4;
							talkSection = 0;
						}

						else
						{
							talkSection = 2;
						}
					}
				}
			}

			else if (talkCount == 4 && !hasDisplayed)
			{
				if (talkSection == 0)
				{
					canSkip = false;

					timer += Time.deltaTime;
					
					if (timer > time)
					{
						talkSection = 1;
					}
				}

				else if (talkSection == 1)
				{
					canSkip = true;
					
					message.displaySubtitle("Jesus my head... It’s still ringing.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 2)
				{
					canSkip = true;
					
					message.displaySubtitle("First time interfacing with a Cognitive Enhancement Tool can have that effect. As can temporal transport.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 3)
				{
					canSkip = true;
					
					message.displaySubtitle("I think I’m going to throw up.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 4)
				{
					canSkip = true;
					
					message.displaySubtitle("I would not judge you for doing so.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 5)
				{
					canSkip = true;
					
					message.displaySubtitle("Uh, thank you, Irma.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 6)
				{
					canSkip = true;
					
					message.displaySubtitle("Your thanks is welcome but unnecessary, Dr. Clemens. My withholding judgment is a matter of programming, not principle. Were my programming to dictate it, I would judge you, as the expression goes, to Hell and back.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 7)
				{
					canSkip = true;
					
					message.displaySubtitle("Uh... alright then, I’ll keep that in mind.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 8)
				{
					message.subtitle.enabled = false;
					message.info.enabled = false;

					cam.canChange = true;
					menu.canMenu = true;

					core.coreDisplay = true;

					okScepter.coreDisplay = true;

					message.displayWarning("Journal Updated: IRMA", 5);

					hasDisplayed = true;
				}
			}

			else if (talkCount == 5 && !hasDisplayed)
			{
				if (talkSection == 0)
				{
					look.enabled = false;
					mouse.enabled = false;

					cam.canChange = false;
					menu.canMenu = false;

					movement.enabled = false;

					canSkip = true;
					
					message.displaySubtitle("This is an IC-Machine?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 1)
				{
					canSkip = true;
					
					message.displaySubtitle("That's correct, Doctor.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 2)
				{
					canSkip = true;
					
					message.displaySubtitle("Looks like some kind of religious altar.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 3)
				{
					canSkip = true;
					
					message.displaySubtitle("The statues represent the Goddess of Messages, Iris, and the Titan God of Time, Chronus.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 4)
				{
					canSkip = true;
					
					message.displaySubtitle("I know. I named the machine after them. I’ve always loved Greek mythology and it somehow seemed like an appropriate name for a machine that sent messages through time. This though... it’s so literal. Like I said, it looks more like an object of worship than a machine of science.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 5)
				{
					canSkip = true;
					
					message.displaySubtitle("To the Daughters of Iris, it is both.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 6)
				{
					canSkip = true;
					
					message.displaySubtitle("Who?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 7)
				{
					canSkip = true;
					
					message.displaySubtitle("The Daughters of Iris. I’ll upload their file into your database.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 8)
				{
					look.enabled = true;
					mouse.enabled = true;

					cam.canChange = true;
					menu.canMenu = true;

					movement.enabled = true;

					message.subtitle.enabled = false;
					message.info.enabled = false;

					daphne.coreInspected = true;
					
					message.displayWarning("Journal Updated:\n Daughters of Iris ", 5);

					audio.volume = .1f;

					talkSection = 9;
				}
			}

			else if (talkCount == 6)
			{
				if (talkSection == 0 && !hasDisplayed)
				{
					look.enabled = false;
					mouse.enabled = false;

					cam.canChange = false;
					menu.canMenu = false;

					movement.enabled = false;

					canSkip = true;
					
					message.displaySubtitle("Shit! Somebody’s trapped under here!", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);

					hasDisplayed = true;
				}

				else if (talkSection == 1 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("I don’t think she’s alive.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 2 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("That is most unfortunate for us.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 3 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Us? What about her? What the hell happened here?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 4 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Three hours ago there was an explosion in the Northwest wing of this facility. Evidence indicates that it was not an accident. This building is under attack.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 5 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Under attack? By who?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 6 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Though there are several possible culprits, I don’t currently have enough information to make a reliable assessment.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);

					camPosition = cameraMain.localScale;

					timer = 0;
					time = 1.5f;
					
					hasDisplayed = true;
				}

				else if (talkSection == 7)
				{
					timer += Time.deltaTime;

					canSkip = false;

					if (!audioPlayed)
					{
						audio.volume = .6f;
						audio.PlayOneShot(explosion);

						audioPlayed = true;
					}

					if (timer > time)
					{
						cameraMain.localScale = camPosition;

						audioPlayed = false;

						talkSection = 8;
					}

					else
					{
						cameraMain.localPosition = camPosition + Random.insideUnitSphere * shake;
					}
				}

				else if (talkSection == 8 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("We are running out of time, Dr. Clemens.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 9 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("What do you mean?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 10 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Your life is in peril, Dr. Clemens and we don’t have time for full explanations. The woman beneath that rubble was assigned to protect you. She was also the only one able to remove the particle field blocking our own exit from the room.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 11 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Jesus, what do I do?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 12 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Find her caduceus, Doctor.. the staff she carried. That is our only hope.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 13 && !hasDisplayed)
				{
					canSkip = true;

					look.enabled = true;
					mouse.enabled = true;

					cam.canChange = true;
					menu.canMenu = true;
					
					movement.enabled = true;

					message.warning.enabled = false;

					scepter.daphneInspected = true;
					
					message.displaySubtitle("We have to hurry.", 5);
					message.displayInfo("IRMA", 5);
					
					hasDisplayed = true;
				}
			}

			else if (talkCount == 7)
			{
				if (talkSection == 0 && !hasDisplayed)
				{
					look.enabled = false;
					mouse.enabled = false;

					cam.canChange = false;
					menu.canMenu = false;
					
					movement.enabled = false;
					
					canSkip = true;
					
					message.displaySubtitle("This... caduceus looks broken.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 1 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("That is most unfortunate, Doctor. Most unfortunate indeed.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 2 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Why, what’s going to happen?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 3 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("I’m sorry, Dr. Clemens, there is no more time for answers. We must act while we still can. The woman who died in the collapse was named Daphne. It is important that in future iterations she lives.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 4 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Wait, iterations? I don’t understand any of this.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 5 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("I know, Doctor, and I’m sorry. Please, just do as I say, for all of our sakes. I am connecting you remotely to the IC machine. The collapse that killed Daphne must have occurred when the first explosion took place at 9:42pm. I need you to send a message back in time, warning her of this event. She cannot be standing by that pillar when the first explosion occurs.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 6 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("What good will that do us?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 7 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("None, and yet all the good in the world.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 8 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("This IC machine is nothing like the one that I created. I don’t even know how to use it.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 9 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Don’t worry, doctor, I’ll walk you through the process.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 10)
				{
					if (!hasDisplayed)
					{
						canSkip = false;
						
						message.displayWarning ("IC Machine Interface", 1000);
						
						ic.icMenu = 1;
						
						ic.isInteracting = true;

						hasDisplayed = true;
					}

					if (ic.tutorialDone)
					{
						hasDisplayed = false;

						talkSection = 11;
					}
				}

				else if (talkSection == 11 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("What do we do now?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 12 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Just one thing. Tell me good bye, doctor.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 13 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("What?", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 14 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Please, do what I say. Tell me good-bye.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("IRMA", 100);
					
					hasDisplayed = true;
				}

				else if (talkSection == 15 && !hasDisplayed)
				{
					canSkip = true;
					
					message.displaySubtitle("Good-bye Irma.", 100);
					message.displayWarning("Right click to continue", 100);
					message.displayInfo("Greg Clemens", 100);

					message.irmaTalk = false;
					
					hasDisplayed = true;
				}

				else if (talkSection == 16)
				{
					Application.LoadLevel(4);
				}
			}
		}
	}
}