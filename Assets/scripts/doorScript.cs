using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class doorScript : MonoBehaviour {
	
	public AnimationClip 		doorOpen;
	public AnimationClip		doorClose;
	
	public AudioClip		reject;
	public AudioClip		confirm;
	
	public float doorMoveTime		= 0.0f;
	public float doorMoveTimer		= 0.0f;
	
	public bool canOpen		= false;
	public bool ICopen		= false;
	
	public bool atDoor		= false;
	
	public GameObject		text;
	public GameObject		npc;
	public GameObject		picture;
	public GameObject		door1;
	public GameObject		door2;
	public GameObject		gui;
	public GameObject		enemy;
	
	private securityBehavior		key;
	//private mariaBehavior			badge;
	private pictureScript			badge;
	private guiSystem				taken;
	private uiSystem				message;
	private enemyBehavior			Enemy;
	
	void Awake () {
		
		key 		= npc.GetComponent <securityBehavior> ();
		//badge 		= maria.GetComponent <mariaBehavior> ();
		badge 		= picture.GetComponent <pictureScript> ();
		taken 		= gui.GetComponent <guiSystem> ();
		message 	= text.GetComponent <uiSystem> ();
		Enemy 		= enemy.GetComponent <enemyBehavior> ();
	}
	
	// Use this for initialization
	void Start () {
		
		canOpen = false;
		ICopen = false;
		
		doorMoveTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (key.talkCount >= 2 && this.gameObject.name == "SecurityDoor") {
			if (!canOpen)
			{
				canOpen = true;
			}
		}
		
		if (badge.tookPicture == true) {
			if (!ICopen)
			{
				ICopen = true;
			}
		}
		
		if (atDoor == true && taken.badgeTaken == true && Input.GetButtonDown("Talk"))
		{
			if (!ICopen)
			{
				if (enemy.transform.position == Enemy.waypointOne.position)
				{
					message.displaySubtitle("That isn't your badge. I'll be taking that, you can get your own from Maria", 10);
					message.displayWarning("Badge confiscated", 10);
					message.displayInfo("Security Guard", 10);
					
					taken.badgeTaken = false;
				}
				
				else {
					ICopen = true;
					
					animation.Play(doorOpen.name);
					audio.PlayOneShot(confirm);
					message.displayWarning("Access Granted", 4);
				}
			}
		}
	}
	
	void OnTriggerEnter (Collider other) {
		
		if (other.gameObject.tag == "Player" && this.gameObject.name == "SecurityDoor") {
			if (canOpen) {
				animation.Play(doorOpen.name);
				
				audio.PlayOneShot(confirm);
			}
			
			else {
				audio.PlayOneShot(reject);
				
				message.displaySubtitle("I need to update my security card first.. William might be able to help.", 10);
				message.displayInfo("Greg Clemens", 10);
				message.displayWarning("Door access denied", 10);
			}
		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor")
		{
			atDoor = true;
			
			if (ICopen) {
				animation.Play(doorOpen.name);
				
				audio.PlayOneShot(confirm);
			}
			
			else if (taken.badgeTaken == true && !ICopen)
			{
				audio.PlayOneShot(reject);
				
				message.displayWarning("Press E to Use Badge", 100);
			}
			
			else {
				audio.PlayOneShot(reject);
				
				message.displaySubtitle("I need to update my security badge first.. Maria is in charge of that.", 10);
				message.displayInfo("Greg Clemens", 10);
				message.displayWarning("Door access denied", 10);
			}
		}

		if (other.gameObject.tag == "Player" && this.gameObject.name == "Door")
		{
			animation.Play(doorOpen.name);
		}
	}
	
	void OnTriggerExit (Collider other) {
		
		if (other.gameObject.tag == "Player" && this.gameObject.name == "SecurityDoor" && canOpen) {
			animation.Play(doorClose.name);
		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor" && ICopen) {
			animation.Play(doorClose.name);
		}

		if (other.gameObject.tag == "Player" && this.gameObject.name == "Door")
		{
			animation.Play(doorClose.name);
		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.name == "ICsecurityDoor")
		{
			message.warning.enabled = false;
			
			atDoor = false;
		}
	}
}