using UnityEngine;
using System.Collections;

public class richardCutscene : MonoBehaviour {

	// Variables to tell if the NPC can talk, or is talking
	public bool canTalk		= false;
	public bool isTalking		= false;

	public bool canSkip		= false;

	public bool hasDisplayed	= false;
	
	// Variable to hold how much time has gone by in a conversation
	public float timer		= 0.0f;
	
	// Variable to hold how much time is allowed before moving on in conversation
	public float time		= 0.0f;
	
	// Variable to hold the current part of the conversation
	public int talkSection		= 0;
	public int talkCount		= 0;
	
	// Variable to hold the holder and text game objects so that we can access its scripts
	public GameObject text;

	private uiSystem	message;

	void Awake () {

		message = text.GetComponent <uiSystem> ();
	}

	// Use this for initialization
	void Start () {
	
		talkSection = 0;
		
		isTalking = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isTalking) {
			
			if (canSkip) {
				if (Input.GetButtonDown("Fire2")) {
					
					talkSection++;
					hasDisplayed = false;
				}
			}
			
			if (talkCount == 0) {
				if (talkSection == 0 && !hasDisplayed) {
					
					canSkip = true;
					
					message.displaySubtitle("A few minutes later...", 100);
					message.displayWarning("Right click to continue", 100);
					
					hasDisplayed = true;
				}
				
				else if (talkSection == 1) {
					if (!hasDisplayed) {
						
						canSkip = true;
						
						message.displaySubtitle("Okay, now just relax Greg. I’m going to turn it on now. \n Let me know if you feel any pain.", 10);
						message.displayWarning("Right click to continue", 10);
						message.displayInfo("Richard Fields", 10);
						
						hasDisplayed = true;
					}
				}
				
				else if (talkSection == 2) {
					if (!hasDisplayed) {
						
						canSkip = true;
						
						message.displaySubtitle("Okay. Right now I’m not feeling anything, except maybe a little-- (gasps)", 10);
						message.displayWarning("Right click to continue", 10);
						message.displayInfo("Greg Clemens", 10);
						
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
					Camera.main.enabled = false;
					
					timer = 0;
					talkCount = 2;
				}
			}
		}
	}
}