using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	public int btnW	= 0;
	public int btnH	= 0;
	public int btnX	= 0;
	public int btnY	= 0;

	// Variable to tell if the menu is open
	public int menuMode	= 0;

	// Variable to tell if the menu can open or not
	public bool canMenu	= true;

	public GUITexture menuBackground;

	// Variables to hold the player and npc game objects so that we can access their scripts
	public GameObject pc;
	public GameObject npc;
	public GameObject text;
	//public GameObject picture;
	
	public GUISkin mySkin;

	private MouseLook		mouse;
	//private CharacterMotor	movement;
	private MouseLook		cam;
	private playerScript	talk;
	private cameraScript	inventory;
	private uiSystem		message;
	//private pictureScript	pic;

	void Awake () {

		// Variables to hold the scripts on other game objects so that we can manipulate them from this script
		mouse 		= pc.GetComponent <MouseLook> ();
		//movement 	= pc.GetComponent <CharacterMotor> ();
		cam 		= Camera.main.GetComponent <MouseLook> ();
		talk 		= pc.GetComponent <playerScript> ();
		inventory 	= this.GetComponent <cameraScript> ();
		message 	= text.GetComponent <uiSystem> ();
		//pic 		= picture.GetComponent <pictureScript> ();
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

				menuBackground.enabled = false;
				
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
		if (GUI.skin != mySkin)
		{
			GUI.skin = mySkin;
		}

		if (menuMode == 1)
		{
			btnX = (Screen.width / 2) - (btnW / 2);
			btnY = (Screen.height / 2) - (btnH / 2);
			btnW = Screen.width / 5;
			btnH = Screen.height / 10;

			menuBackground.enabled = true;

			GUI.Label (new Rect(btnX + 45, btnY - 325, btnW, btnH), "Menu Screen");
			
			if (GUI.Button (new Rect (btnX, btnY - 50, btnW, btnH), "Options"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 2;
			}
			
			if (GUI.Button (new Rect (btnX, btnY + 50, btnW, btnH), "Reset Level"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 11;
			}
			
			if (GUI.Button (new Rect (btnX, btnY + 150, btnW, btnH), "Restart Game"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 12;
			}
			
			if (GUI.Button (new Rect (btnX, btnY + 250, btnW, btnH), "Quit Game"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 10;
			}
		}
		
		else if (menuMode == 2)
		{
			GUI.Label (new Rect(btnX + 30, btnY - 325, btnW, btnH), "Options Screen");
			
			if (GUI.Button (new Rect (btnX, btnY - 250, btnW, btnH), "Save Options"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 1;
			}
		}
		
		else if (menuMode == 10)
		{
			GUI.Label (new Rect(btnX + 45, btnY - 100, btnW, btnH), "Are you sure?");
			
			if (GUI.Button (new Rect (btnX - 200, btnY, btnW, btnH), "Cancel"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 1;
			}
			
			if (GUI.Button (new Rect (btnX + 200, btnY, btnW, btnH), "Quit"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				Application.Quit();
			}
		}
		
		else if (menuMode == 11)
		{
			GUI.Label (new Rect(btnX + 45, btnY - 100, btnW, btnH), "Are you sure?");
			
			if (GUI.Button (new Rect (btnX - 200, btnY, btnW, btnH), "Cancel"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 1;
			}
			
			if (GUI.Button (new Rect (btnX + 200, btnY, btnW, btnH), "Reset Level"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else
				{
					inventory.canChange = true;
					
					mouse.enabled = true;
					cam.enabled = true;
					
					Time.timeScale = 1.0f;
					
					menuMode = 0;

					if (Application.loadedLevel == 1)
					{
						Application.LoadLevel(1);
					}

					else if (Application.loadedLevel == 3)
					{
						Application.LoadLevel(3);
					}

					else if (Application.loadedLevel == 4)
					{
						Application.LoadLevel(4);
					}
				}
			}
		}
		
		else if (menuMode == 12)
		{
			GUI.Label (new Rect(btnX + 45, btnY - 100, btnW, btnH), "Are you sure?");
			
			if (GUI.Button (new Rect (btnX - 200, btnY, btnW, btnH), "Cancel"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else

				menuMode = 1;
			}
			
			if (GUI.Button (new Rect (btnX + 200, btnY, btnW, btnH), "Restart Game"))
			{
				if (Event.current.button == 1 || Event.current.button == 2)
				{
					
				}
				
				else
				{
					inventory.canChange = true;
					
					mouse.enabled = true;
					cam.enabled = true;
					
					Time.timeScale = 1.0f;
					
					menuMode = 0;
					
					Application.LoadLevel(0);
				}
			}
		}
		
		else
		{
			
		}
	}
}