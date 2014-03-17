#pragma strict

var cameraMode											: int = 0;

var canChange											: boolean = true;

var pc													: GameObject;
var npc													: GameObject;


function Start () {

}

function Update () {
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var movement : CharacterMotor = pc.gameObject.GetComponent(CharacterMotor);
	var cam : MouseLook = Camera.main.GetComponent(MouseLook);
	var talk : npcBehavior = npc.gameObject.GetComponent(npcBehavior);
	var menu : menuScript = this.gameObject.GetComponent(menuScript);

	if (Input.GetButtonDown("Camera") && cameraMode == 0 && canChange) {
		cameraMode = 1;
		//Time.timeScale = 0.0;
		
		movement.enabled = false;
		
		menu.canMenu = false;
		
		talk.canTalk = false;
		
		mouse.enabled = false;
		cam.enabled = false;
		
		print("Inventory Mode");
	}
	
	else if (Input.GetButtonDown("Camera") && cameraMode == 1  && canChange) {
		cameraMode = 0;
		//Time.timeScale = 1.0;
		
		movement.enabled = true;
		
		menu.canMenu = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Normal Mode");
	}
	
	else if (Input.GetButtonDown("Camera") && !cameraMode == 0 && !cameraMode == 1  && canChange) {
		cameraMode = 0;
		//Time.timeScale = 1.0;
		
		movement.enabled = true;
		
		menu.canMenu = true;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Camera Mode Error");
	}
}