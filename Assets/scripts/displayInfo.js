#pragma strict

var canDisplay											: boolean = false;
var wasInspected										: boolean = false;

var onWilliam											: boolean = false;
var onMaria												: boolean = false;
var onRichard											: boolean = false;
var onEnemy												: boolean = false;

var vagueDistance										: int = 0;
var detailDistance										: int = 0;

var timer												: float = 0.0;
var time												: float = 0.0;

var text												: GameObject;

var Player												: Transform;

function Start () {
	
}

function Update () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

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
				message.displayInfo("Security pesonnel", 4);
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
	}
	
	if (Vector3.Distance(transform.position, Player.position) <= detailDistance)
	{
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
			message.displayWarning("Right Click to Inspect", 4);
		}
	
		onWilliam = true;
	}
	
	if (this.gameObject.name == "Maria" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click to Inspect", 4);
		}
	
		onMaria = true;
	}
	
	if (this.gameObject.name == "Richard" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click to Inspect", 4);
		}
	
		onRichard = true;
	}
	
	if (this.gameObject.name == "Enemy" && canDisplay) {
		if (!wasInspected)
		{
			message.displayWarning("Right Click to Inspect", 4);
		}
	
		onEnemy = true;
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
}