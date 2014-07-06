#pragma strict

var canDisplay											: boolean = false;
var wasInspected										: boolean = false;

var onWilliam											: boolean = false;
var onMaria												: boolean = false;
var onRichard											: boolean = false;
var onEnemy												: boolean = false;
var onPortrait											: boolean = false;
var onIC												: boolean = false;
var onCore												: boolean = false;
var onBadge												: boolean = false;
var canTouch											: boolean = false;

var vagueDistance										: int = 0;
var detailDistance										: int = 0;
var touchDistance										: int = 0;

var timer												: float = 0.0;
var time												: float = 0.0;

var text												: GameObject;
var gui													: GameObject;

var Player												: Transform;

function Start () {
	
}

function Update () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	
	if (this.gameObject.name == "badge")
	{
		var taken : guiSystem = gui.gameObject.GetComponent(guiSystem);
	}

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

		if (this.gameObject.name == "William" && onWilliam && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("A security guard", 4);
			}
			
			else
			{
				message.displayInfo("Security Guard William Hebb", 4);
			}
		}
		
		else if (this.gameObject.name == "Maria" && onMaria && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("Security personnel", 4);
			}
			
			else
			{
				message.displayInfo("Head of Security Maria Figueroa", 4);
			}
		}
		
		else if (this.gameObject.name == "Richard" && onRichard && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("A scientist", 4);
			}
			
			else
			{
				message.displayInfo("Scientist Richard Fields", 4);
			}
		}
		
		else if (this.gameObject.name == "Enemy" && onEnemy && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("Unknown person", 4);
			}
			
			else
			{
				message.displayInfo("Enemy Patrol *Blind*", 4);
			}
		}
		
		else if (this.gameObject.name == "portrait" && onPortrait && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("A framed picture", 4);
			}
			
			else
			{
				message.displayInfo("My family portrait", 4);
				message.displaySubtitle("We took this photo two years ago while on vacation. Did Jill really look that much younger? Did I? And look at Angie, her smile is the widest, her eyes so bright and full of promise. I shouldn’t be here; I should be with you.. except, I’m here for you. I’m going to fix this.. somehow.", 10);
			}
		}
		
		else if (this.gameObject.name == "ICMachine" && onIC && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("What's this?", 4);
			}
			
			else
			{
				message.displayInfo("IC machine", 4);
				message.displaySubtitle("This has been added since I left. It looks crudely constructed, as if made in a hurry.", 5);
			}
		}
		
		else if (this.gameObject.name == "Core" && onCore && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("My creation", 4);
			}
			
			else
			{
				message.displayInfo("IC core", 4);
				message.displaySubtitle("The Iris-Chronus machine. I named it after Iris, the Greek Goddess of Messages and Chronus, the God of Time.", 5);
			}
		}
		
		else if (this.gameObject.name == "badge" && onBadge && canDisplay && Input.GetButtonDown("Fire2"))
		{
			if (!wasInspected)
			{
				message.displayInfo("A badge?", 4);
			}
			
			else
			{
				message.displayInfo("Brian's badge", 4);
				message.displaySubtitle("Looks like Brian left his clearance card laying around.", 5);
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
		
		if (this.gameObject.name == "William" && onWilliam && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("Security Guard William Hebb", 4);
			
			wasInspected = true;
		}
		
		else if (this.gameObject.name == "Maria" && onMaria && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("Head of Security Maria Figueroa", 4);
			
			wasInspected = true;
		}
		
		else if (this.gameObject.name == "Richard" && onRichard && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("Scientist Richard Fields", 4);
			
			wasInspected = true;
		}
		
		else if (this.gameObject.name == "Enemy" && onEnemy && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("Enemy Patrol *Blind*", 4);
			
			wasInspected = true;
		}
		
		else if (this.gameObject.name == "portrait" && onPortrait && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("My family portrait", 4);
			message.displaySubtitle("We took this photo two years ago while on vacation. Did Jill really look that much younger? Did I? And look at Angie, her smile is the widest, her eyes so bright and full of promise. I shouldn’t be here; I should be with you.. except, I’m here for you. I’m going to fix this.. somehow.", 10);
			
			wasInspected = true;
		}
		
		else if (this.gameObject.name == "ICMachine" && onIC && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("IC machine", 4);
			message.displaySubtitle("This has been added since I left. It looks crudely constructed, as if made in a hurry.", 5);
			
			wasInspected = true;
		}
		
		else if (this.gameObject.name == "Core" && onCore && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("IC core", 4);
			message.displaySubtitle("The Iris-Chronus machine. I named it after Iris, the Greek Goddess of Messages and Chronus, the God of Time.", 5);
			
			wasInspected = true;
		}
		
		else if (this.gameObject.name == "badge" && onBadge && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("Brian's badge", 4);
			message.displaySubtitle("Looks like Brian left his clearance card laying around.", 5);
			
			wasInspected = true;
		}
	}
	
	if (Vector3.Distance(transform.position, Player.position) <= touchDistance)
	{
		canTouch = true;
	
		if (this.gameObject.name == "badge" && wasInspected && canDisplay && canTouch)
		{
			message.displayWarning("Press T to Take", 100);
		}
		
		if (this.gameObject.name == "badge" && canDisplay && wasInspected && Input.GetButtonDown("Action"))
		{
			message.displayWarning("Badge Taken \n Press Tab to Open Inventory", 5);
			message.displaySubtitle("I’m sure he won’t mind if I borrow this.", 5);
			
			taken.badgeTaken = true;
			
			Destroy(this.gameObject);
		}
		
		else if (this.gameObject.name == "badge" && onBadge && canDisplay && Input.GetButtonDown("Fire2"))
		{
			message.displayInfo("Brian's badge", 4);
			message.displaySubtitle("Looks like Brian left his clearance card laying around.", 5);
			
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

function OnMouseEnter () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (this.gameObject.name == "William" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onWilliam = true;
	}
	
	if (this.gameObject.name == "Maria" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onMaria = true;
	}
	
	if (this.gameObject.name == "Richard" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onRichard = true;
	}
	
	if (this.gameObject.name == "Enemy" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onEnemy = true;
	}
	
	if (this.gameObject.name == "portrait" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onPortrait = true;
	}
	
	if (this.gameObject.name == "ICMachine" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onIC = true;
	}
	
	if (this.gameObject.name == "Core" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onCore = true;
	}
	
	if (this.gameObject.name == "badge" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click/Press R to Inspect", 4);
		}
	
		onBadge = true;
	}
	
	if (this.gameObject.tag == "Collider" && canDisplay) {
		this.gameObject.collider.enabled = false;
		
		timer = .05;
	}
}

function OnMouseExit () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

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
}