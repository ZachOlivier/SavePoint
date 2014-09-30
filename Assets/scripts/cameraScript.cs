using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	// Variable to tell which mode the camera is in
	public int cameraMode 	= 0;

	// Variable to tell whether the camera mode can switch or not
	public bool canChange 	= true;

	// Variables to hold the player and npc game objects so that we can access their scripts
	public GameObject pc;
	public GameObject npc;
	public GameObject text;
	public GameObject picture;

	private MouseLook 		mouse;
	private CharacterMotor 	movement;
	private MouseLook 		cam;
	private playerScript 	talk;
	private menuScript 		menu;
	private uiSystem 		message;
	private pictureScript	pic;

	void Awake () {

		// Variables to hold the scripts on other game objects so that we can manipulate them from this script
		mouse 		= pc.GetComponent <MouseLook> ();
		movement 	= pc.GetComponent <CharacterMotor> ();
		cam 		= Camera.main.GetComponent <MouseLook> ();
		talk 		= pc.GetComponent <playerScript> ();
		menu 		= this.GetComponent <menuScript> ();
		message 	= text.GetComponent <uiSystem> ();
		pic 		= picture.GetComponent <pictureScript> ();
	}

	// This void only fires once during the start of this script
	void Start () {
		
	}

	// This void fires over and over again throughout the life of this script
	void Update () {
		
		// If the player pressed the tab key and the camera is currently in normal mode and can change
		if (Input.GetButtonDown("Camera") && cameraMode == 0 && canChange) {
			
			// Switch the camera mode to inventory mode
			cameraMode = 1;
			//Time.timeScale = 0.0;
			
			// Make it so the player can't move
			movement.enabled = false;
			
			// Make it so the player can't open the menu or start a conversation
			menu.canMenu = false;
			talk.canTalk = false;
			
			// Make it so the camera won't move
			mouse.enabled = false;
			cam.enabled = false;
			
			// Display a message on the screen that will stay for 4 seconds
			message.displayWarning("Inventory mode active.. \n Press Tab to Close", 4);
		}
		
		// Else if the player pressed the tab key and the camera is currently in inventory mode and can change
		else if (Input.GetButtonDown("Camera") && cameraMode == 1  && canChange) {
			cameraMode = 0;
			//Time.timeScale = 1.0;

			if (!pic.canPicture)
			{
			movement.enabled = true;
			}

			else {
				movement.enabled = false;
			}
			
			menu.canMenu = true;
			
			mouse.enabled = true;
			cam.enabled = true;
			
			message.displayWarning("Normal mode active..", 4);
		}
		
		// Else if the player pressed the tab key and the camera isn't in either mode but can change
		else if (Input.GetButtonDown("Camera") && canChange) {
			
			if (cameraMode != 0 || cameraMode != 1)
			{
				cameraMode = 0;
				//Time.timeScale = 1.0;
				
				if (!pic.canPicture)
				{
					movement.enabled = true;
				}
				
				else {
					movement.enabled = false;
				}
				
				menu.canMenu = true;
				
				mouse.enabled = true;
				cam.enabled = true;
				
				message.displayWarning("Camera error!..", 4);
			}
		}
	}
}