﻿using UnityEngine;
using System.Collections;

public class displayInfo : MonoBehaviour {

	public bool canDisplay			= false;
	public bool coreDisplay			= false;
	public bool coreInspected		= false;
	public bool daphneInspected		= false;
	public bool wasInspected		= false;

	public bool onWilliam			= false;
	public bool onMaria				= false;
	public bool onRichard			= false;
	public bool onEnemy				= false;
	public bool onPortrait			= false;
	public bool onIC				= false;
	public bool onCore				= false;
	public bool onBadge				= false;
	public bool onPhone				= false;
	public bool onBook				= false;
	public bool onDaphne			= false;
	public bool onScepter			= false;

	public bool calledHome			= false;
	public bool canTouch			= false;

	public int vagueDistance		= 0;
	public int detailDistance		= 0;
	public int touchDistance		= 0;

	public float timer				= 0.0f;
	public float time				= 0.0f;

	public GameObject		pc;
	public GameObject		text;
	public GameObject		gui;

	public Transform		Player;

	private irmaScript		irma;
	private uiSystem		message;
	private guiSystem		taken;

	void Awake () {

		message		= text.GetComponent <uiSystem> ();

		if (this.gameObject.name == "badge")
		{
			taken = gui.GetComponent <guiSystem> ();
		}

		if (Application.loadedLevel == 3)
		{
			irma = pc.GetComponent <irmaScript> ();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Vector3.Distance(transform.position, Player.position) > vagueDistance)
		{
			if (canDisplay)
			{
				canDisplay = false;
			}
		}
		
		if (Vector3.Distance(transform.position, Player.position) <= vagueDistance && Vector3.Distance(transform.position, Player.position) > detailDistance)
		{
			if (!canDisplay)
			{
				canDisplay = true;
			}
			
			if (this.gameObject.name == "William" && onWilliam && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("A security guard", 5);
				}
				
				else
				{
					message.displayInfo("Security Guard William Hebb", 5);
				}
			}
			
			else if (this.gameObject.name == "Maria" && onMaria && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("Security personnel", 5);
				}
				
				else
				{
					message.displayInfo("Head of Security Maria Figueroa", 5);
				}
			}
			
			else if (this.gameObject.name == "Richard" && onRichard && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("A scientist", 5);
				}
				
				else
				{
					message.displayInfo("Scientist Richard Fields", 5);
				}
			}
			
			else if (this.gameObject.name == "Enemy" && onEnemy && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("Unknown person", 5);
				}
				
				else
				{
					message.displayInfo("Security Guard", 5);
				}
			}
			
			else if (this.gameObject.name == "portrait" && onPortrait && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("A framed picture", 5);
				}
				
				else
				{
					message.displayInfo("My family portrait", 10);
					message.displaySubtitle("We took this photo two years ago while on vacation. Did Jill really look that much younger? Did I? And look at Angie, her smile is the widest, her eyes so bright and full of promise. I shouldn’t be here; I should be with you.. except, I’m here for you. I’m going to fix this.. somehow.", 10);
				}
			}
			
			else if (this.gameObject.name == "ICMachine" && onIC && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("What's this?", 5);
				}
				
				else
				{
					message.displayInfo("IC machine", 5);
					message.displaySubtitle("This has been added since I left. It looks crudely constructed, as if made in a hurry.", 5);
				}
			}
			
			else if (this.gameObject.name == "Core" && onCore && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("My creation", 5);
				}
				
				else
				{
					if (Application.loadedLevel == 1)
					{
						message.displayInfo("IC core", 5);
						message.displaySubtitle("The Iris-Chronus machine. I named it after Iris, the Greek Goddess of Messages and Chronus, the God of Time.", 5);
					}

					else if (Application.loadedLevel == 3 && coreDisplay)
					{
						irma.hasDisplayed = false;
						irma.talkSection = 0;
						irma.talkNumber = 0;
						irma.talkCount = 5;
						
						coreDisplay = false;
					}

					else if (Application.loadedLevel == 3 && coreInspected)
					{
						message.displayInfo("IC core", 7);
						message.displaySubtitle("The Iris-Chronus machine. I named it after Iris, the Greek Goddess of Messages and Chronus, the God of Time. This one is different from the one I created.", 7);
					}
				}
			}
			
			else if (this.gameObject.name == "badge" && onBadge && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("A badge?", 5);
				}
				
				else
				{
					message.displayInfo("Brian's Badge", 5);
					message.displaySubtitle("Looks like Brian left his clearance card laying around.", 5);
				}
			}
			
			else if (this.gameObject.name == "phone" && onPhone && canDisplay && !calledHome && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("A phone?", 5);
				}
				
				else
				{
					message.displayInfo("My Office Phone", 5);
					message.displaySubtitle("Perhaps I should call home..", 5);
				}
			}
			
			else if (this.gameObject.name == "book" && onBook && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (!wasInspected)
				{
					message.displayInfo("A book?", 5);
				}
				
				else
				{
					message.displayInfo("My Greek Mythology Book", 5);
					message.displaySubtitle("It’s still turned to the same page I was reading when Angie.. when I got the news.", 5);
				}
			}

			else if (this.gameObject.name == "Daphne" && onDaphne && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (coreInspected)
				{
					irma.hasDisplayed = false;
					irma.talkSection = 0;
					irma.talkNumber = 0;
					irma.talkCount = 6;
				}
			}

			else if (this.gameObject.name == "scepter" && onScepter && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (coreDisplay)
				{
					message.displayInfo("Caduceus", 5);
					message.displaySubtitle("Used for the IC-Machine. There should be another somewhere.", 5);
				}
			}

			else if (this.gameObject.name == "scepterBroken" && onScepter && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (daphneInspected)
				{
					irma.hasDisplayed = false;
					irma.talkSection = 0;
					irma.talkNumber = 0;
					irma.talkCount = 7;
				}
			}
		}
		
		if (Vector3.Distance(transform.position, Player.position) <= detailDistance && Vector3.Distance(transform.position, Player.position) > touchDistance)
		{
			if (canTouch)
			{
				message.warning.enabled = false;
				
				canTouch = false;
			}
			
			if (!canDisplay)
			{
				canDisplay = true;
			}
			
			if (this.gameObject.name == "William" && onWilliam && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("Security Guard William Hebb", 5);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "Maria" && onMaria && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("Head of Security Maria Figueroa", 5);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "Richard" && onRichard && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("Scientist Richard Fields", 5);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "Enemy" && onEnemy && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("Security Guard", 5);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "portrait" && onPortrait && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("My family portrait", 10);
				message.displaySubtitle("We took this photo two years ago while on vacation. Did Jill really look that much younger? Did I? And look at Angie, her smile is the widest, her eyes so bright and full of promise. I shouldn’t be here; I should be with you.. except, I’m here for you. I’m going to fix this.. somehow.", 10);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "ICMachine" && onIC && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("IC machine", 5);
				message.displaySubtitle("This has been added since I left. It looks crudely constructed, as if made in a hurry.", 5);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "Core" && onCore && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (Application.loadedLevel == 1)
				{
					message.displayInfo("IC core", 5);
					message.displaySubtitle("The Iris-Chronus machine. I named it after Iris, the Greek Goddess of Messages and Chronus, the God of Time.", 5);

					wasInspected = true;
				}

				else if (Application.loadedLevel == 3 && coreDisplay)
				{
					irma.hasDisplayed = false;
					irma.talkSection = 0;
					irma.talkNumber = 0;
					irma.talkCount = 5;

					coreDisplay = false;
				}
				
				else if (Application.loadedLevel == 3 && coreInspected)
				{
					message.displayInfo("IC core", 7);
					message.displaySubtitle("The Iris-Chronus machine. I named it after Iris, the Greek Goddess of Messages and Chronus, the God of Time. This one is different from the one I created.", 7);
				
					wasInspected = true;
				}
			}
			
			else if (this.gameObject.name == "badge" && onBadge && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("Brian's Badge", 5);
				message.displaySubtitle("Looks like Brian left his clearance card laying around.", 5);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "phone" && onPhone && canDisplay && !calledHome && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("My Office Phone", 5);
				message.displaySubtitle("Perhaps I should call home..", 5);
				
				wasInspected = true;
			}
			
			else if (this.gameObject.name == "book" && onBook && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("My Greek Mythology Book", 5);
				message.displaySubtitle("It’s still turned to the same page I was reading when Angie.. when I got the news.", 5);
				
				wasInspected = true;
			}

			else if (this.gameObject.name == "Daphne" && onDaphne && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (coreInspected)
				{
					wasInspected = true;

					irma.hasDisplayed = false;
					irma.talkSection = 0;
					irma.talkNumber = 0;
					irma.talkCount = 6;
				}
			}
			
			else if (this.gameObject.name == "scepter" && onScepter && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (coreDisplay)
				{
					message.displayInfo("Caduceus", 5);
					message.displaySubtitle("Used for the IC-Machine. There should be another somewhere.", 5);
					
					wasInspected = true;
				}
			}
			
			else if (this.gameObject.name == "scepterBroken" && onScepter && canDisplay && Input.GetButtonDown("Inspect"))
			{
				if (daphneInspected)
				{
					wasInspected = true;

					irma.hasDisplayed = false;
					irma.talkSection = 0;
					irma.talkNumber = 0;
					irma.talkCount = 7;
				}
			}
		}
		
		if (Vector3.Distance(transform.position, Player.position) <= touchDistance)
		{
			canTouch = true;
			
			if (this.gameObject.name == "badge" && wasInspected && canDisplay && canTouch)
			{
				message.displayWarning("Press E to Take", 100);
			}
			
			if (this.gameObject.name == "badge" && canDisplay && wasInspected && Input.GetButtonDown("Talk"))
			{
				message.displayWarning("Badge Taken \n Press Tab to Open Inventory", 5);
				message.displaySubtitle("I’m sure he won’t mind if I borrow this.", 5);
				message.displayInfo("Greg Clemens", 5);
				
				taken.badgeTaken = true;
				
				Destroy(this.gameObject);
			}
			
			else if (this.gameObject.name == "badge" && onBadge && canDisplay && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("Brian's Badge", 5);
				message.displaySubtitle("Looks like Brian left his clearance card laying around.", 5);
				
				wasInspected = true;
			}
			
			if (this.gameObject.name == "phone" && wasInspected && canDisplay && !calledHome && canTouch)
			{
				message.displayWarning("Press E to Call Home", 100);
			}
			
			if (this.gameObject.name == "phone" && canDisplay && wasInspected && !calledHome && Input.GetButtonDown("Talk"))
			{
				message.displayWarning("Called Home", 5);
				message.displaySubtitle("They need me at home, I should hurry.", 5);
				message.displayInfo("Greg Clemens", 5);
				
				calledHome = true;
			}
			
			else if (this.gameObject.name == "phone" && onPhone && canDisplay && !calledHome && Input.GetButtonDown("Inspect"))
			{
				message.displayInfo("My Office Phone", 5);
				message.displaySubtitle("Perhaps I should call home..", 5);
				
				wasInspected = true;
			}
		}
		
		if (timer > 0) {
			time += Time.deltaTime;
			
			if (time > timer) {
				timer = 0;
				time = 0;
				
				this.gameObject.collider.enabled = true;
			}
		}
	}

	void OnMouseEnter () {
		
		if (this.gameObject.name == "William" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onWilliam = true;
		}
		
		if (this.gameObject.name == "Maria" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onMaria = true;
		}
		
		if (this.gameObject.name == "Richard" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onRichard = true;
		}
		
		if (this.gameObject.name == "Enemy" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onEnemy = true;
		}
		
		if (this.gameObject.name == "portrait" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onPortrait = true;
		}
		
		if (this.gameObject.name == "ICMachine" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onIC = true;
		}
		
		if (this.gameObject.name == "Core" && canDisplay) {

			if (Application.loadedLevel == 1)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			else if (Application.loadedLevel == 3 && coreDisplay)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onCore = true;
		}
		
		if (this.gameObject.name == "badge" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onBadge = true;
		}
		
		if (this.gameObject.name == "phone" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onPhone = true;
		}
		
		if (this.gameObject.name == "book" && canDisplay) {
			if (!wasInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onBook = true;
		}

		if (this.gameObject.name == "Daphne" && canDisplay) {
			if (!wasInspected && coreInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onDaphne = true;
		}

		if (this.gameObject.name == "scepter" && canDisplay) {
			if (!wasInspected && coreDisplay)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onScepter = true;
		}

		if (this.gameObject.name == "scepterBroken" && canDisplay) {
			if (!wasInspected && daphneInspected)
			{
				message.displayWarning("Press R to Inspect", 5);
			}
			
			onScepter = true;
		}
		
		if (this.gameObject.tag == "Collider" && canDisplay) {
			this.gameObject.collider.enabled = false;
			
			timer = .05f;
		}
	}
	
	void OnMouseExit () {
		
		if (this.gameObject.name == "William") {
			onWilliam = false;
		}
		
		if (this.gameObject.name == "Maria") {
			onMaria = false;
		}
		
		if (this.gameObject.name == "Richard") {
			onRichard = false;
		}
		
		if (this.gameObject.name == "Enemy") {
			onEnemy = false;
		}
		
		if (this.gameObject.name == "portrait") {
			onPortrait = false;
		}
		
		if (this.gameObject.name == "ICMachine") {
			onIC = false;
		}
		
		if (this.gameObject.name == "Core") {
			onCore = false;
		}
		
		if (this.gameObject.name == "badge") {
			onBadge = false;
		}
		
		if (this.gameObject.name == "phone") {
			onPhone = false;
		}
		
		if (this.gameObject.name == "book") {
			onBook = false;
		}

		if (this.gameObject.name == "Daphne")
		{
			onDaphne = false;
		}

		if (this.gameObject.name == "scepter")
		{
			onScepter = false;
		}

		if (this.gameObject.name == "scepterBroken")
		{
			onScepter = false;
		}
	}
}