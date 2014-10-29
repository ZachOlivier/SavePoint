using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class introScript : MonoBehaviour {

	// Variables for holding time and what part the intro scene is at in order to let player skip if desired
	//int timer		= 0;
	public int part			= 0;
	public int audioPart 	= 0;
	
	public bool audioPlayed = false;

	public float timer;
	public float introTimer1;
	public float introTimer2;
	public float introTimer3;
	public float introTimer4;
	public float introTimer5;

	public Texture2D icBG;

	public AudioClip music1;
	public AudioClip music2;
	public AudioClip music3;
	public AudioClip music4;

	public AudioClip expandedIntro;
	public AudioClip introTalk1;

	public bool canSkip	= true;
	public bool canBack	= true;

	public GUISkin mySkin;

	public GameObject text;

	private uiSystem		message;

	void Awake () {

		message = text.GetComponent <uiSystem> ();
	}

	// Use this for initialization
	void Start () {
	
		// Make sure that whenever the intro scene is played, it starts at the beginning
		part = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("Fire1") && canSkip) {
			if (part >= 1 && part <= 5)
			{

			}

			else
			{
				part++;
			}
		}
		
		if (Input.GetButtonDown("Fire2") && canBack) {
			if (part >= 1 && part <= 5)
			{
				
			}
			
			else
			{
				part--;
			}
		}
		
		if (Input.GetButtonDown("Talk")) {
			if (part > -1)
			{
				part = 48;
			}
		}

		if (part >= 1 && part <= 5)
		{
			timer += Time.deltaTime;
		}

		if (!message.displayingOne)
		{
			message.fourDecision1.enabled = false;
		}

		if (!message.displayingThree)
		{
			message.fourDecision2.enabled = false;
			message.fourDecision3.enabled = false;
		}

		if (part == -1)
		{
			canBack = false;

			message.displaySubtitle("\n\n\n\n\n\n\n\n\n\n\n\n\n\nThis game contains language not suitable for children.\n\nGameplay changes depending on decisions the player makes.", 1000);
			message.subtitleBox.enabled = false;
		}

		if (part == 0) {

			canBack = false;

			if (!audioPlayed)
			{
				audio.PlayOneShot(expandedIntro);

				audioPart = 0;

				audioPlayed = true;
			}

			message.displaySubtitle("My name is Gregory Clemens. I’m a particle physicist with a doctorate from MIT. I have a wife named Jill and a daughter, Angie. I’m 45 years old. My name is Gregory Clemens. I’m a particle physicist with a doctorate from MIT. I have a wife named Jill and a daughter, Angie. I’m 45 years old. My name is Gregory Clemens. I’m a particle physicist with a doctorate from MIT. I have a wife named Jill and a daughter, Angie. I’m 45 years old. I can.. I can do better. (Fading) My name is Gregory Clemens. I’m a particle physicist with a doctorate from MIT. I have a wife named Jill.....", 100);
			message.displayWarning("Left Click to Proceed, Right Click to Go Back", 1000);
			message.displayInfo("Press E to Skip", 1000);
			message.display1Decision("Unknown Voice", 100);
		}
		
		if (part == 1) {
			
			canBack = true;

			if (audioPart == 0)
			{
				audio.Stop();

				audioPlayed = false;

				audioPart++;
			}

			else if (audioPart == 1)
			{
				if (!audioPlayed)
				{
					audio.PlayOneShot(introTalk1);
					
					audioPlayed = true;
				}
			}
			
			message.displaySubtitle("Okay okay, so Dr. Clemens, I just have to ask you this one last question : \n You've created this.. what did you call it?", 100);
			message.display1Decision("Broadcaster #1", 100);

			if (timer >= introTimer1)
			{
				part++;
			}

			message.warning.enabled = false;
			message.displayingThree = false;
		}
		
		if (part == 2) {
			
			message.displaySubtitle("It's an I-C Machine.", 100);
			message.display3Decision("", "Greg Clemens", "Main Character", 100);

			if (timer >= introTimer2)
			{
				part++;
			}

			message.displayingOne = false;
		}
		
		if (part == 3) {
			
			message.displaySubtitle("This... amazing machine... that sends messages to the past and receives them from the future. \n So if you were to send yourself, your past self, a single personal message, what would it be?", 100);
			message.display1Decision("Broadcaster #1", 100);

			if (timer >= introTimer3)
			{
				part++;
			}

			message.displayingThree = false;
		}
		
		if (part == 4) {
			
			message.displaySubtitle("Do better.", 100);
			message.display1Decision("Greg Clemens", 100);

			if (timer >= introTimer4)
			{
				part++;
			}
		}
		
		if (part == 5) {
			
			message.displaySubtitle("Wait a minute, you’re the person responsible for what is potentially the most significant invention \n in the history of all humankind, and you’re message to yourself would be ‘Do better?’. All I can say \n to that is God help the rest of us! Thank you so much Dr. Gregory Clemens, or as the headlines are calling you : \n \nThe Man Who Texted Yesterday.", 100);
			message.display1Decision("Broadcaster #1", 100);

			if (timer >= introTimer5)
			{
				part++;

				timer = 0;
			}

			message.displayingThree = false;
		}
		
		if (part == 6) {

			if (audioPart == 1)
			{
				audio.Stop();

				audioPart++;
			}

			audio.clip = music3;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}

			message.displaySubtitle("“Do better”? I can’t believe you said that.", 100);
			message.displayWarning("Left Click to Proceed, Right Click to Go Back", 1000);
			message.display3Decision("", "Jill", "Greg's Wife", 100);

			message.displayingOne = false;
		}
		
		if (part == 7) {
			
			message.displaySubtitle("I was being humble.", 100);
			message.display1Decision("Greg Clemens", 100);

			message.displayingThree = false;
		}
		
		if (part == 8) {
			
			message.displaySubtitle("That was not humble Greg. That was the opposite of humble.", 100);
			message.display1Decision("Jill", 100);

			message.displayingThree = false;
		}
		
		if (part == 9) {
			
			message.displaySubtitle("That was pretty douchie, Dad.", 100);
			message.display3Decision("", "Angie", "Greg's Daughter", 100);

			message.displayingOne = false;
		}
		
		if (part == 10) {
			
			message.displaySubtitle("Angie...", 100);
			message.display1Decision("Greg Clemens", 100);

			message.displayingThree = false;
		}
		
		if (part == 11) {
			
			message.displaySubtitle("Sorry Dad, just saying..", 100);
			message.display1Decision("Angie", 100);
		}
		
		if (part == 12) {
			
			message.displaySubtitle("Honey, you were being a douche.", 100);
			message.display1Decision("Jill", 100);
		}
		
		if (part == 13) {
			
			message.displaySubtitle("How is that anything but humble?", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 14) {
			
			message.displaySubtitle("Dad, it’s like kicking a hundred yard field goal and going, \n “Man, I’m really off my game today.”", 100);
			message.display1Decision("Angie", 100);
		}
		
		if (part == 15) {
			
			audio.clip = music1;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}
			
			message.displaySubtitle("Today, the President awarded physicist Gregory Clemens with both the National Medal of Science \n and the National Medal of Innovation and Technology. Usually the highest honors possible, \n today the medals were complemented by a special proclamation and…", 100);
			message.display1Decision("Broadcaster #2", 100);
		}
		
		if (part == 16) {
			
			message.displaySubtitle("So according to our source, each day that passes since the machine was turned on is another year of data received \n -- discoveries, technologies, information about events, your local weather forecasts (laughing).", 100);
			message.display1Decision("Broadcaster #1", 100);
		}
		
		if (part == 17) {
			
			message.displaySubtitle("Do better", 100);
			message.display1Decision("Unknown Voice", 100);
		}
		
		if (part == 18) {
			
			message.displaySubtitle("The US Government signed a deal granting itself exclusive rights to the I-C machine and its technology.", 100);
			message.display1Decision("Pundit #1", 100);
		}
		
		if (part == 19) {
			
			message.displaySubtitle("In a move that surprised absolutely no one.", 100);
			message.display1Decision("Pundit #2", 100);
		}
		
		if (part == 20) {
			
			message.displaySubtitle("Right? I mean, with the ramifications of this kind of technology, was there any way this \n wasn’t going to happen, one way or another?", 100);
			message.display1Decision("Pundit #1", 100);
		}
		
		if (part == 21) {
			
			message.displaySubtitle("Exactly Ted. They were going to take control of the thing one way or another. This was just \n the nice way of doing it. But believe me, it was a shotgun sale.", 100);
			message.display1Decision("Pundit #2", 100);
		}
		
		if (part == 22) {
			
			message.displaySubtitle("Maybe so, but even though they’re hiding the details, you know it was for a pretty penny.", 100);
			message.display1Decision("Pundit #1", 100);
		}
		
		if (part == 23) {
			
			message.displaySubtitle("I know, right? I mean what is it like to be Gregory Clemens. Can anything NOT go well for this man?", 100);
			message.display1Decision("Pundit #2", 100);
		}
		
		if (part == 24) {
			
			message.displaySubtitle("Do better", 100);
			message.display1Decision("Unknown Voice", 100);
		}
		
		if (part == 25) {
			
			audio.clip = music2;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}
			
			message.displaySubtitle("(Car Crash)", 100);

			message.displayingOne = false;
		}
		
		if (part == 26) {
			
			message.displaySubtitle("… a fatal car crash that left one high school student dead and critically injured two more. \n Among the injured was 15 year old Angela Clemens, daughter of renowned scientist and inventor...", 100);
			message.display1Decision("News Anchor", 100);
		}
		
		if (part == 27) {
			
			message.displaySubtitle("Your daughter suffered severe brain trauma. With enough therapy I think it’s reasonable to \n believe she may regain a good bit of her speech. She may even gain limited control of her extremities. \n As for walking, or more complex motor functions, you never know but it’s important that you \n and Angie manage your expectations.", 100);
			message.display1Decision("Surgeon", 100);
		}
		
		if (part == 28) {
			
			message.displaySubtitle("More bad news for Dr. Greg Clemens. A spokesman for the American Council for the \n Advancement of Physics today released a statement that the I-C machine, the time messaging \n machine developed by Dr. Clemens, has ceased working.", 100);
			message.display1Decision("Broadcaster #3", 100);
		}
		
		if (part == 29) {
			
			message.displaySubtitle("It’s gone cold, Greg. Nothing’s coming through.", 100);
			message.display1Decision("Employer", 100);
		}
		
		if (part == 30) {
			
			message.displaySubtitle("Do better", 100);
			message.display1Decision("Unknown Voice", 100);
		}
		
		if (part == 31) {
			
			message.displaySubtitle("Did you check the plug?", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 32) {
			
			message.displaySubtitle("Look, we’ve been over the machine, over and over, everything appears fine.", 100);
			message.display1Decision("Employer", 100);
		}
		
		if (part == 33) {
			
			message.displaySubtitle("I can’t help you. Not right now.", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 34) {
			
			message.displaySubtitle("We need you Greg.", 100);
			message.display1Decision("Employer", 100);	
		}
		
		if (part == 35) {
			
			message.displaySubtitle("Angie needs me more.", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 36) {
			
			message.displaySubtitle("Do better", 100);
			message.display1Decision("Unknown Voice", 100);
		}
		
		if (part == 37) {
			
			message.displaySubtitle("There has to be something more we can do.", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 38) {
			
			message.displaySubtitle("Mr. Clemens, I understand your desire to see your daughter better but you have to understand \n she’s already come a long way, much further than we initially thought she could. It looks like \n she’s going to regain most of her ability to speak. That said, there’s only so much that can be \n done. With time we may discover new options but at this point we’ve pursued every course \n available to us.", 100);
			message.display1Decision("Surgeon", 100);	
		}
		
		if (part == 39) {
			
			message.displaySubtitle("And how long is Angie going to have to wait?", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 40) {
			
			message.displaySubtitle("Do better", 100);
			message.display1Decision("Unknown Voice", 100);	
		}
		
		if (part == 41) {
			
			message.displaySubtitle("(Phone Ringing)", 100);

			message.displayingOne = false;
		}
		
		if (part == 42) {
			
			message.displaySubtitle("(To himself) I need to go back to work. I have to help Angie. I have to...", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 43) {
			
			message.displaySubtitle("Greg? I know what you said. Look, it’s urgent. We need you here. I wouldn’t ask again otherwise.", 100);
			message.display1Decision("Employer", 100);
		}
		
		if (part == 44) {
			
			message.displaySubtitle("Honey? Jill, wake up.", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 45) {
			
			message.displaySubtitle("Mmmm? Who was that.", 100);
			message.display1Decision("Jill", 100);
		}
		
		if (part == 46) {
			
			message.displaySubtitle("It was work. I have to go back. I have to ...", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 47) {
			
			audio.Stop();
			
			message.displaySubtitle("(To himself) Do better.", 100);
			message.display1Decision("Greg Clemens", 100);
		}
		
		if (part == 48) {

			if (audioPart == 0 || audioPart == 1)
			{
				audio.Stop();

				audioPart += 5;
			}
			
			audio.clip = music1;
			audio.loop = true;
			
			if (!audio.isPlaying) {
				audio.Play();
			}
			
			canBack = false;

			message.displayingOne = false;
			message.displayingTwo = false;
			message.displayingThree = false;
			message.displayingFour = false;

			message.warning.enabled = false;
			message.info.enabled = false;
			message.fourDecision1.enabled = false;
			message.fourDecision2.enabled = false;
			message.fourDecision3.enabled = false;
			message.fourDecision4.enabled = false;

			message.displaySubtitle("\n\n\n\n\n\n\n\n\n\n\n\n\nSave Point\n\n\n\n\nEpisode 1: The Man Who Texted Yesterday", 1000);
		}
		
		// After the last scene has played
		if (part == 49) {

			message.displaySubtitle("\n\n\n\n\n\n\n\n\n\n\n\n\n\nThis game contains language not suitable for children.\n\nGameplay changes depending on decisions the player makes.", 1000);
			message.subtitleBox.enabled = false;
		}

		if (part == 50)
		{
			audio.Stop();
			
			// Load the next level, currently set to the game level 1 (Prototype)
			Application.LoadLevel(1);
		}
	}

	/*void OnGUI()
	{
		if (GUI.skin != mySkin)
		{
			GUI.skin = mySkin;
		}

		mySkin.box.normal.background = icBG;

		GUILayout.Box("", GUILayout.Width (1600), GUILayout.Height (900));
	}*/
}