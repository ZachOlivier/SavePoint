using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class introScript : MonoBehaviour {

	// Variables for holding time and what part the intro scene is at in order to let player skip if desired
	//int timer		= 0;
	public int part		= 0;

	public AudioClip music1;
	public AudioClip music2;
	public AudioClip music3;
	public AudioClip music4;

	public bool canSkip	= true;
	public bool canBack	= true;

	// Variables for holding the text game objects, we want to be able to manipulate their position
	public GameObject savePoint;
	public GameObject episodeText;

	public GameObject text;

	private uiSystem		message;
	//private soundScript		music;

	void Awake () {

		message = text.GetComponent <uiSystem> ();
		//music = this.GetComponent <soundScript> ();
	}

	// Use this for initialization
	void Start () {
	
		// Make sure that whenever the intro scene is played, it starts at the beginning
		part = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("Fire1") && canSkip) {
			part++;
		}
		
		if (Input.GetButtonDown("Fire2") && canBack) {
			part--;
		}
		
		if (Input.GetButtonDown("Talk")) {
			part = 50;
		}
		
		if (part == 0) {
			
			canBack = false;
			
			message.displaySubtitle("Do better", 1000);
			message.displayWarning("Left Click to Proceed, Right Click to Go Back", 1000);
			message.displayInfo("Press E to Skip", 1000);
			message.displayDecision("Unknown Voice", "", "", "", 100);
		}
		
		if (part == 1) {
			
			canBack = true;
			
			audio.clip = music3;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}
			
			message.displaySubtitle("Okay okay, so Dr. Clemens, I just have to ask you this one last question : \n You've created this.. what did you call it?", 1000);
			message.displayDecision("Broadcaster #1", "", "", "", 100);
		}
		
		if (part == 2) {
			
			message.displaySubtitle("I-C Machine.", 1000);
			message.displayDecision("Greg Clemens", "Main Character", "", "", 100);
		}
		
		if (part == 3) {
			
			message.displaySubtitle("This... amazing machine... that sends messages to the past and receives them from the future. \n So if you were to send yourself, your past self, a single personal message, what would it be?", 1000);
			message.displayDecision("Broadcaster #1", "", "", "", 100);
		}
		
		if (part == 4) {
			
			message.displaySubtitle("Do better.", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 5) {
			
			message.displaySubtitle("Wait a minute, you’re the person responsible for what is potentially the most significant invention \n in the history of all humankind, and you’re message to yourself would be ‘Do better?’. All I can say \n to that is God help the rest of us! Thank you so much Dr. Gregory Clemens, or as the headlines are calling you : \n \n The Man Who Texted Yesterday.", 1000);
			message.displayDecision("Broadcaster #1", "", "", "", 100);
		}
		
		if (part == 6) {
			
			message.displaySubtitle("“Do better”? I can’t believe you said that.", 1000);
			message.displayDecision("Jill", "Greg's Wife", "", "", 100);
		}
		
		if (part == 7) {
			
			message.displaySubtitle("I was being humble.", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 8) {
			
			message.displaySubtitle("That was not humble Greg. That was the opposite of humble.", 1000);
			message.displayDecision("Jill", "", "", "", 100);
		}
		
		if (part == 9) {
			
			message.displaySubtitle("That was pretty douchie, Dad.", 1000);
			message.displayDecision("Angie", "Greg's Daughter", "", "", 100);
		}
		
		if (part == 10) {
			
			message.displaySubtitle("Angie...", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 11) {
			
			message.displaySubtitle("Sorry Dad, just saying..", 1000);
			message.displayDecision("Angie", "", "", "", 100);
		}
		
		if (part == 12) {
			
			message.displaySubtitle("Honey, you were being a douche.", 1000);
			message.displayDecision("Jill", "", "", "", 100);
		}
		
		if (part == 13) {
			
			message.displaySubtitle("How is that anything but humble?", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 14) {
			
			message.displaySubtitle("Dad, it’s like kicking a hundred yard field goal and going, \n “Man, I’m really off my game today.”", 1000);
			message.displayDecision("Angie", "", "", "", 100);
		}
		
		if (part == 15) {
			
			audio.clip = music1;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}
			
			message.displaySubtitle("Today, the President awarded physicist Gregory Clemens with both the National Medal of Science \n and the National Medal of Innovation and Technology. Usually the highest honors possible, \n today the medals were complemented by a special proclamation and…", 1000);
			message.displayDecision("Broadcaster #2", "", "", "", 100);
		}
		
		if (part == 16) {
			
			message.displaySubtitle("So according to our source, each day that passes since the machine was turned on is another year of data received \n -- discoveries, technologies, information about events, your local weather forecasts (laughing).", 1000);
			message.displayDecision("Broadcaster #1", "", "", "", 100);
		}
		
		if (part == 17) {
			
			message.displaySubtitle("Do better", 1000);
			message.displayDecision("Unknown Voice", "", "", "", 100);
		}
		
		if (part == 18) {
			
			message.displaySubtitle("The US Government signed a deal granting itself exclusive rights to the I-C machine and its technology.", 1000);
			message.displayDecision("Pundit #1", "", "", "", 100);
		}
		
		if (part == 19) {
			
			message.displaySubtitle("In a move that surprised absolutely no one.", 1000);
			message.displayDecision("Pundit #2", "", "", "", 100);
		}
		
		if (part == 20) {
			
			message.displaySubtitle("Right? I mean, with the ramifications of this kind of technology, was there any way this \n wasn’t going to happen, one way or another?", 1000);
			message.displayDecision("Pundit #1", "", "", "", 100);
		}
		
		if (part == 21) {
			
			message.displaySubtitle("Exactly Ted. They were going to take control of the thing one way or another. This was just \n the nice way of doing it. But believe me, it was a shotgun sale.", 1000);
			message.displayDecision("Pundit #2", "", "", "", 100);
		}
		
		if (part == 22) {
			
			message.displaySubtitle("Maybe so, but even though they’re hiding the details, you know it was for a pretty penny.", 1000);
			message.displayDecision("Pundit #1", "", "", "", 100);
		}
		
		if (part == 23) {
			
			message.displaySubtitle("I know, right? I mean what is it like to be Gregory Clemens. Can anything NOT go well for this man?", 1000);
			message.displayDecision("Pundit #2", "", "", "", 100);
		}
		
		if (part == 24) {
			
			message.displaySubtitle("Do better", 1000);
			message.displayDecision("Unknown Voice", "", "", "", 100);
		}
		
		if (part == 25) {
			
			audio.clip = music2;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}
			
			message.displaySubtitle("(Car Crash)", 1000);
			message.displayDecision("", "", "", "", 100);
		}
		
		if (part == 26) {
			
			message.displaySubtitle("… a fatal car crash that left one high school student dead and critically injured two more. \n Among the injured was 15 year old Angela Clemens, daughter of renowned scientist and inventor...", 1000);
			message.displayDecision("News Anchor", "", "", "", 100);
		}
		
		if (part == 27) {
			
			message.displaySubtitle("Your daughter suffered severe brain trauma. With enough therapy I think it’s reasonable to \n believe she may regain a good bit of her speech. She may even gain limited control of her extremities. \n As for walking, or more complex motor functions, you never know but it’s important that you \n and Angie manage your expectations.", 1000);
			message.displayDecision("Surgeon", "", "", "", 100);
		}
		
		if (part == 28) {
			
			message.displaySubtitle("More bad news for Dr. Greg Clemens. A spokesman for the American Council for the \n Advancement of Physics today released a statement that the I-C machine, the time messaging \n machine developed by Dr. Clemens, has ceased working.", 1000);
			message.displayDecision("Broadcaster #3", "", "", "", 100);
		}
		
		if (part == 29) {
			
			message.displaySubtitle("It’s gone cold, Greg. Nothing’s coming through.", 1000);
			message.displayDecision("Employer", "", "", "", 100);
		}
		
		if (part == 30) {
			
			message.displaySubtitle("Do better", 1000);
			message.displayDecision("Unknown Voice", "", "", "", 100);
		}
		
		if (part == 31) {
			
			message.displaySubtitle("Did you check the plug?", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 32) {
			
			message.displaySubtitle("Look, we’ve been over the machine, over and over, everything appears fine.", 1000);
			message.displayDecision("Employer", "", "", "", 100);
		}
		
		if (part == 33) {
			
			message.displaySubtitle("I can’t help you. Not right now.", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 34) {
			
			message.displaySubtitle("We need you Greg.", 1000);
			message.displayDecision("Employer", "", "", "", 100);	
		}
		
		if (part == 35) {
			
			message.displaySubtitle("Angie needs me more.", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 36) {
			
			message.displaySubtitle("Do better", 1000);
			message.displayDecision("Unknown Voice", "", "", "", 100);
		}
		
		if (part == 37) {
			
			message.displaySubtitle("There has to be something more we can do.", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 38) {
			
			message.displaySubtitle("Mr. Clemens, I understand your desire to see your daughter better but you have to understand \n she’s already come a long way, much further than we initially thought she could. It looks like \n she’s going to regain most of her ability to speak. That said, there’s only so much that can be \n done. With time we may discover new options but at this point we’ve pursued every course \n available to us.", 1000);
			message.displayDecision("Surgeon", "", "", "", 100);	
		}
		
		if (part == 39) {
			
			message.displaySubtitle("And how long is Angie going to have to wait?", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 40) {
			
			message.displaySubtitle("Do better", 1000);
			message.displayDecision("Unknown Voice", "", "", "", 100);	
		}
		
		if (part == 41) {
			
			message.displaySubtitle("(Phone Ringing)", 1000);
			message.displayDecision("", "", "", "", 100);
		}
		
		if (part == 42) {
			
			message.displaySubtitle("(To himself) I need to go back to work. I have to help Angie. I have to...", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 43) {
			
			message.displaySubtitle("Greg? I know what you said. Look, it’s urgent. We need you here. I wouldn’t ask again otherwise.", 1000);
			message.displayDecision("Employer", "", "", "", 100);
		}
		
		if (part == 44) {
			
			message.displaySubtitle("Honey? Jill, wake up.", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 45) {
			
			message.displaySubtitle("Mmmm? Who was that.", 1000);
			message.displayDecision("Jill", "", "", "", 100);
		}
		
		if (part == 46) {
			
			message.displaySubtitle("It was work. I have to go back. I have to ...", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 47) {
			
			audio.Stop();
			
			message.displaySubtitle("(To himself) Do better.", 1000);
			message.displayDecision("Greg Clemens", "", "", "", 100);
		}
		
		if (part == 48) {
			
			audio.clip = music1;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}
			
			canBack = false;
			
			message.subtitle.enabled = false;
			message.warning.enabled = false;
			message.info.enabled = false;
			message.decision1.enabled = false;
			message.decision2.enabled = false;
			message.decision3.enabled = false;
			message.decision4.enabled = false;

			Vector3 position = savePoint.transform.position;
			position.z = 0.0f;
			savePoint.transform.position = position;
		}
		
		if (part == 49) {
			
			Destroy(savePoint.gameObject);

			Vector3 position = episodeText.transform.position;
			position.z = 20.0f;
			episodeText.transform.position = position;
		}
		
		// After the last scene has played
		if (part == 50) {
			
			audio.Stop();
			
			// Load the next level, currently set to the game level 1 (Prototype)
			Application.LoadLevel(1);
		}
	}
}