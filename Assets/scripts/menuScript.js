#pragma strict

var menuMode											: int = 0;

var canMenu												: boolean = true;

var pc													: GameObject;
var npc													: GameObject;


function Start () {

}

function Update () {
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);
	var cam : MouseLook = Camera.main.GetComponent(MouseLook);
	var talk : npcBehavior = npc.gameObject.GetComponent(npcBehavior);
	var menu : cameraMode = this.gameObject.GetComponent(cameraMode);

	if (Input.GetButtonDown("Menu") && menuMode == 0 && canMenu) {
		menuMode = 1;
		Time.timeScale = 0.0;
		
		//movement.enabled = false;
		
		menu.canChange = false;
		
		talk.canTalk = false;
		
		mouse.enabled = false;
		cam.enabled = false;
		
		print("Menu Open");
	}
	
	else if (Input.GetButtonDown("Menu") && menuMode == 1  && canMenu) {
		menuMode = 0;
		Time.timeScale = 1.0;
		
		//movement.enabled = true;
		
		menu.canChange = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Menu Closed");
	}
	
	else if (Input.GetButtonDown("Menu") && !menuMode == 0 && !menuMode == 1  && canMenu) {
		menuMode = 0;
		Time.timeScale = 1.0;
		
		//movement.enabled = true;
		
		menu.canChange = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Menu Mode Error");
	}
}