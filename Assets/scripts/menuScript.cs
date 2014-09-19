using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	public int btnW	= 0;
	public int btnH	= 0;
	public int btnX	= 0;
	public int btnY	= 0;

	// Variable to tell if the menu is open
	public double menuMode	= 0;

	// Variable to tell if the menu can open or not
	public bool canMenu	= true;

	// Variables to hold the player and npc game objects so that we can access their scripts
	public GameObject pc;
	public GameObject npc;
	public GameObject text;
	public GameObject picture;

	public GUIStyle myStyle;

	private MouseLook		mouse;
	//private CharacterMotor	movement;
	private MouseLook		cam;
	private playerScript	talk;
	private cameraScript	inventory;
	private uiSystem		message;
	private pictureScript	pic;

	void Awake () {

		// Variables to hold the scripts on other game objects so that we can manipulate them from this script
		mouse 		= pc.GetComponent <MouseLook> ();
		//movement 	= pc.GetComponent <CharacterMotor> ();
		cam 		= Camera.main.GetComponent <MouseLook> ();
		talk 		= pc.GetComponent <playerScript> ();
		inventory 	= this.GetComponent <cameraScript> ();
		message 	= text.GetComponent <uiSystem> ();
		pic 		= picture.GetComponent <pictureScript> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// If the player pressed the escape key and the menu is currently not open and can change
		if (Input.GetButtonDown("Menu") && menuMode == 0 && canMenu) {
			
			// Pause the game then open the menu
			Time.timeScale = 0.0f;
			
			//movement.enabled = false;
			
			// Make it so the player can't open the inventory or start a conversation
			inventory.canChange = false;
			talk.canTalk = false;
			
			// Make it so the camera won't move
			mouse.enabled = false;
			cam.enabled = false;
			
			// Display a message on the screen that will stay for 4 seconds
			message.displayWarning("Menu opened.. \n Press Escape to Close", .1f);
			
			menuMode = 1;
		}
		
		// Else if the player pressed the escape key and the menu is currently open and can change
		else if (Input.GetButtonDown("Menu") && canMenu) {
			
			if (menuMode == 1 || menuMode == 2 || menuMode == 10 || menuMode == 11 || menuMode == 12)
			{
				Time.timeScale = 1.0f;
				
				//movement.enabled = true;
				
				inventory.canChange = true;
				
				mouse.enabled = true;
				cam.enabled = true;
				
				message.displayWarning("Menu closed..", 4);
				
				menuMode = 0;
			}
		}
		
		// Else if the player pressed the escape key and the menu isn't in either mode but can change
		else if (Input.GetButtonDown("Menu") && canMenu) {
			
			if (menuMode != 0 || menuMode != 1 || menuMode != 2 || menuMode != 10 || menuMode != 11 || menuMode != 12)
			{
				Time.timeScale = 1.0f;
				
				//movement.enabled = true;
				
				inventory.canChange = true;
				
				mouse.enabled = true;
				cam.enabled = true;
				
				message.displayWarning("Menu error!..", 4);
				
				menuMode = 0;
			}
		}
	}
	
	void OnGUI ()
	{
		
		if (menuMode == 1)
		{
			btnX = (Screen.width / 2) - (btnW / 2);
			btnY = (Screen.height / 2) - (btnH / 2);
			btnW = Screen.width / 5;
			btnH = Screen.height / 10;
			
			GUI.Label (new Rect(btnX - 75, btnY - 325, btnW, btnH), "Menu Screen", myStyle);
			
			if (GUI.Button (new Rect (btnX, btnY - 50, btnW, btnH), "Options"))
			{
				menuMode = 2;
			}
			
			if (GUI.Button (new Rect (btnX, btnY + 50, btnW, btnH), "Reset Level"))
			{
				menuMode = 11;
			}
			
			if (GUI.Button (new Rect (btnX, btnY + 150, btnW, btnH), "Restart Game (Intro)"))
			{
				menuMode = 12;
			}
			
			if (GUI.Button (new Rect (btnX, btnY + 250, btnW, btnH), "Quit Game"))
			{
				menuMode = 10;
			}
		}
		
		else if (menuMode == 2)
		{
			GUI.Label (new Rect(btnX - 120, btnY - 325, btnW, btnH), "Options Screen", myStyle);
			
			if (GUI.Button (new Rect (btnX, btnY - 250, btnW, btnH), "Save Options"))
			{
				menuMode = 1;
			}
		}
		
		else if (menuMode == 10)
		{
			GUI.Label (new Rect(btnX - 100, btnY - 100, btnW, btnH), "Are you sure?", myStyle);
			
			if (GUI.Button (new Rect (btnX - 200, btnY, btnW, btnH), "Cancel"))
			{
				menuMode = 1;
			}
			
			if (GUI.Button (new Rect (btnX + 200, btnY, btnW, btnH), "Quit"))
			{
				Application.Quit();
			}
		}
		
		else if (menuMode == 11)
		{
			GUI.Label (new Rect(btnX - 100, btnY - 100, btnW, btnH), "Are you sure?", myStyle);
			
			if (GUI.Button (new Rect (btnX - 200, btnY, btnW, btnH), "Cancel"))
			{
				menuMode = 1;
			}
			
			if (GUI.Button (new Rect (btnX + 200, btnY, btnW, btnH), "Reset Level"))
			{
				inventory.canChange = true;
				
				mouse.enabled = true;
				cam.enabled = true;
				
				Time.timeScale = 1.0f;
				
				menuMode = 0;
				
				Application.LoadLevel(1);
			}
		}
		
		else if (menuMode == 12)
		{
			GUI.Label (new Rect(btnX - 100, btnY - 100, btnW, btnH), "Are you sure?", myStyle);
			
			if (GUI.Button (new Rect (btnX - 200, btnY, btnW, btnH), "Cancel"))
			{
				menuMode = 1;
			}
			
			if (GUI.Button (new Rect (btnX + 200, btnY, btnW, btnH), "Restart Game (Intro)"))
			{
				inventory.canChange = true;
				
				mouse.enabled = true;
				cam.enabled = true;
				
				Time.timeScale = 1.0f;
				
				menuMode = 0;
				
				Application.LoadLevel(0);
			}
		}
		
		else
		{
			
		}
	}
}