#pragma strict

var canDisplay											: boolean = true;

var timer												: float = 0.0;
var time												: float = 0.0;

var text												: GameObject;

function Start () {
	canDisplay = true;
}

function Update () {
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

	if (this.gameObject.name == "Security Guard" && canDisplay) {
		message.displayInfo("Security Guard William Hebb", 4);
	}
	
	if (this.gameObject.name == "Maria" && canDisplay) {
		message.displayInfo("Head of Security Maria Figueroa", 4);
	}
	
	if (this.gameObject.name == "Enemy" && canDisplay) {
		message.displayInfo("Enemy Patrol", 4);
	}
	
	if (this.gameObject.tag == "Collider" && canDisplay) {
		this.gameObject.collider.enabled = false;
		
		timer = .05;
	}
}

function OnMouseExit () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (this.gameObject.name == "securityGuard" && canDisplay) {
		message.info.enabled = false;
	}
	
	if (this.gameObject.name == "Maria" && canDisplay) {
		message.info.enabled = false;
	}
	
	if (this.gameObject.name == "enemy" && canDisplay) {
		message.info.enabled = false;
	}
}