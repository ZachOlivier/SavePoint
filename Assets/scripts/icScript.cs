using UnityEngine;
using System.Collections;

public class icScript : MonoBehaviour {

	public bool isInteracting = false;

	public bool thisDisplayed = false;

	public GUITexture icMainScreen;
	public GUITexture icMessageScreen;

	public int btnW	= 0;
	public int btnH	= 0;
	public int btnX	= 0;
	public int btnY	= 0;

	public int icMenu = 0;

	public int interactDistance = 0;

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
	
		if (Vector3.Distance (transform.position, Player.position) <= interactDistance) {

			if (!isInteracting) {

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
		if (icMenu > 0)
		{
			btnW = Screen.width / 9;
			btnH = Screen.height / 12;
			btnX = (Screen.width / 2) - (btnW / 2);
			btnY = (Screen.height / 2) - (btnH / 2);

			if (GUI.Button (new Rect (btnX - 440, btnY - 340, btnW, btnH), "Exit Interface"))
			{
				icMainScreen.enabled = false;
				icMessageScreen.enabled = false;
				
				isInteracting = false;
				
				icMenu = 0;
			}
		}

		if (icMenu == 1)
		{
			btnW = Screen.width / 3;
			btnH = Screen.height / 11;
			btnX = (Screen.width / 2) - (btnW / 2);
			btnY = (Screen.height / 2) - (btnH / 2);

			icMainScreen.enabled = true;

			if (GUI.Button (new Rect (btnX, btnY + 4, btnW, btnH), " "))
			{
				icMainScreen.enabled = false;

				icMenu = 2;
			}

			if (GUI.Button (new Rect (btnX, btnY + 87, btnW, btnH), " "))
			{
				icMenu = 3;
			}

			if (GUI.Button (new Rect (btnX, btnY + 169, btnW, btnH), " "))
			{
				icMenu = 4;
			}
		}

		else if (icMenu == 2)
		{
			icMessageScreen.enabled = true;

			if (GUI.Button (new Rect (btnX, btnY - 340, btnW, btnH), "Go Back"))
			{
				icMessageScreen.enabled = false;

				icMenu = 1;
			}
		}

		else if (icMenu == 3)
		{
			if (GUI.Button (new Rect (btnX, btnY, btnW, btnH), "Go Back"))
			{
				icMenu = 1;
			}
		}

		else if (icMenu == 4)
		{
			if (GUI.Button (new Rect (btnX, btnY, btnW, btnH), "Go Back"))
			{
				icMenu = 1;
			}
		}
	}
}