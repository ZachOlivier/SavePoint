#pragma strict

var cameraMode											: int = 0;

var pc													: GameObject;


function Start () {

}

function Update () {
	var mouse : MouseLook = pc.gameObject.GetComponent(MouseLook);
	var cam : MouseLook = Camera.main.GetComponent(MouseLook);

	if (Input.GetButtonDown("Camera") && cameraMode == 0) {
		cameraMode = 1;
		Time.timeScale = 0.0;
		
		mouse.enabled = false;
		cam.enabled = false;
		
		print("Inventory Mode");
	}
	
	else if (Input.GetButtonDown("Camera") && cameraMode == 1) {
		cameraMode = 0;
		Time.timeScale = 1.0;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Normal Mode");
	}
	
	else if (Input.GetButtonDown("Camera") && !cameraMode == 0 && !cameraMode == 1) {
		cameraMode = 0;
		Time.timeScale = 1.0;
		
		mouse.enabled = true;
		cam.enabled = true;
		
		print("Camera Mode Error");
	}
}