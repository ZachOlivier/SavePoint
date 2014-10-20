using UnityEngine;
using System.Collections;

public class icScript : MonoBehaviour {

	public bool isInteracting 	= false;
	public bool canInteract		= false;

	public bool tutorialDone	= false;

	public bool thisDisplayed 	= false;

	public string selectedTitle;
	public string selectedWho;
	public string selectedMessage;
	public Texture2D icBG;
	public Texture2D icMainScreen;
	public Texture2D icMessageScreen;
	public Texture2D boxTexture;
	public Texture2D selectedTexture;

	public float btnW	= 0;
	public float btnH	= 0;
	public float btnX	= 0;
	public float btnY	= 0;

	public int icMenu = 0;

	public int interactDistance = 0;

	public GUISkin mySkin;

	public Transform Player;

	public GameObject pc;
	public GameObject text;
	public GameObject holder;

	private MouseLook 		mouse;
	private CharacterMotor 	movement;
	private MouseLook 		cam;
	private playerScript 	talk;
	private menuScript 		menu;
	private cameraScript	inventory;
	private uiSystem 		message;

	void Awake () {
		
		// Variables to hold the scripts on other game objects so that we can manipulate them from this script
		mouse 		= pc.GetComponent <MouseLook> ();
		movement 	= pc.GetComponent <CharacterMotor> ();
		cam 		= Camera.main.GetComponent <MouseLook> ();
		talk 		= pc.GetComponent <playerScript> ();
		menu 		= holder.GetComponent <menuScript> ();
		inventory 	= holder.GetComponent <cameraScript> ();
		message 	= text.GetComponent <uiSystem> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (selectedTitle == "")
		{
			if (selectedTitle != "No Message Selected")
			{
				selectedTitle = "No Message Selected";
			}
		}

		if (Vector3.Distance (transform.position, Player.position) <= interactDistance) {

			if (!isInteracting && canInteract) {

				message.displayWarning ("Press E to Interact", 100);

				if (!movement.enabled)
				{
					movement.enabled = true;
				}

				if (!menu.canMenu)
				{
					menu.canMenu = true;
				}

				if (!inventory.canChange)
				{
					inventory.canChange = true;
				}

				if (!talk.canTalk)
				{
					talk.canTalk = true;
				}

				if (!mouse.enabled)
				{
					mouse.enabled = true;
				}

				if (!cam.enabled)
				{
					cam.enabled = true;
				}

				if (!thisDisplayed)
				{
					thisDisplayed = true;
				}

				if (Input.GetButtonDown ("Talk")) {
					
					// Make it so the player can't move
					movement.enabled = false;

					// Make it so the player can't open the menu or start a conversation
					menu.canMenu = false;
					inventory.canChange = false;
					talk.canTalk = false;

					// Make it so the camera won't move
					mouse.enabled = false;
					cam.enabled = false;

					message.displayWarning ("IC Machine Interface", 10000);
					
					icMenu = 1;

					isInteracting = true;
				}
			}
		}

		else {

			if (thisDisplayed)
			{
				message.warning.enabled = false;

				thisDisplayed = false;
			}
		}
	}

	void OnGUI()
	{
		if (GUI.skin != mySkin)
		{
			GUI.skin = mySkin;
		}

		if (icMenu == 1)
		{
			btnW = Screen.width / 3;
			btnH = Screen.height / 12;
			btnX = (Screen.width / 2) - (btnW / 2);
			btnY = (Screen.height / 2) - (btnH / 2);

			mySkin.box.normal.background = icBG;
			mySkin.box.fontSize = 22;

			GUI.Box(new Rect (0, 0, Screen.width, Screen.height), "");

			GUI.Label(new Rect((Screen.width / 2) - 180, (Screen.height / 2) - 255, 1600, 100), "Iris Chronus Machine");
			GUI.Label(new Rect((Screen.width / 2) - 180, (Screen.height / 2) - 215, 1600, 100), "Version 2.7.001");
			GUI.Label(new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 105, 1600, 100), "Welcome, Gregory Clemens");

			mySkin.button.normal.background = boxTexture;

			if (GUI.Button (new Rect (btnX, btnY + 4, btnW, btnH), "Quantum Message System"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else
				
				icMenu = 2;
			}

			if (GUI.Button (new Rect (btnX, btnY + 87, btnW, btnH), "Vignette Collection"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				icMenu = 3;
			}

			if (GUI.Button (new Rect (btnX, btnY + 169, btnW, btnH), "Observation Repository"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				icMenu = 4;
			}

			if (GUI.Button (new Rect (btnX - 440, btnY - 340, btnW / 3, btnH), "Exit Interface"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				if (!tutorialDone)
				{
					tutorialDone = true;
				}
				
				isInteracting = false;
				
				icMenu = 0;
			}
		}

		else if (icMenu == 2)
		{
			mySkin.box.normal.background = icBG;
			GUI.Box(new Rect (0, 0, Screen.width, Screen.height), "");

			GUI.Label(new Rect(50, 100, 1600, 100), "Quantum Message System");
			GUI.Label(new Rect(Screen.width - 275, 20, Screen.width, 100), "G. Clemens  S.I. 1");

			mySkin.box.normal.background = boxTexture;
			mySkin.box.fontSize = 22;

			if (mySkin.box.normal.textColor != Color.white)
			{
				mySkin.box.normal.textColor = Color.white;
			}

			GUI.Box(new Rect(45, 190, Screen.width / 7, Screen.height / 1.4f), "Inbound");
			GUI.Box(new Rect((Screen.width / 7) + (45 + 5), 190, Screen.width / 7, Screen.height / 1.4f), "Outbound");

			GUI.Box (new Rect(Screen.width / 2.9f, 190, Screen.width / 1.6f, Screen.height / 1.4f), selectedTitle + "\n" + selectedWho);
			GUI.TextField(new Rect(Screen.width / 2.7f, 255, Screen.width / 1.725f, Screen.height / 3), selectedMessage);
			//GUI.Label (new Rect((Screen.width / 2), 210, Screen.width, 100), selectedWho);

			mySkin.button.normal.background = boxTexture;

			if (GUI.Button (new Rect (10, btnY - 340, btnW / 3, btnH), "<< Back"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				icMenu = 1;
			}

			mySkin.button.normal.background = selectedTexture;

			if (GUI.Button (new Rect(Screen.width / 1.2f, 680, Screen.width / 8, Screen.height / 20), "Send Message"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else
				
				selectedTitle = "";
				selectedWho = "";
				selectedMessage = "";
			}

			mySkin.button.normal.background = icBG;

			if (GUI.Button (new Rect (55, 260, Screen.width / 8, Screen.height / 14), "Message 1"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				selectedTitle = "Message 1";
				selectedWho = "From: Unknown Sender";
				selectedMessage = "Dr. Clemens,\n\nI realize this is highly inappropriate, but I think you should know that I know your secret. Yep, you are from the past and are now in the future. I plan to blackmail you. Keep this inbox available. I'll be in touch.\n\n-Anonymous";
			}

			if (GUI.Button (new Rect ((Screen.width / 8) + (55 + 32), 260, Screen.width / 8, Screen.height / 14), "Message 2"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				selectedTitle = "Message 2";
				selectedWho = "To: New Recipient";
				selectedMessage = "Daphne,\n\nAlot of typing goes here to see if the text field will work right for what I need it to do and to make someone laugh. Are you laughing? No? Oh well, at least I tried. Oh, and watch out for that huge pillar. It's going to fall on you if you're not careful. Yep, I can see the future. Mind blown, huh?\n\n-Gregory Clemens";
			}
		}

		else if (icMenu == 3)
		{
			mySkin.box.normal.background = icBG;
			mySkin.box.fontSize = 22;

			GUI.Box(new Rect (0, 0, Screen.width, Screen.height), "");

			if (GUI.Button (new Rect (10, btnY - 340, btnW / 3, btnH), "<< Back"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				icMenu = 1;
			}
		}

		else if (icMenu == 4)
		{
			mySkin.box.normal.background = icBG;
			mySkin.box.fontSize = 22;

			GUI.Box(new Rect (0, 0, Screen.width, Screen.height), "");

			if (GUI.Button (new Rect (10, btnY - 340, btnW / 3, btnH), "<< Back"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				icMenu = 1;
			}
		}
	}
}