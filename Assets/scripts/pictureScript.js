#pragma strict

var canPicture									: boolean = false;
var inPicture									: boolean = false;
var tookPicture									: boolean = false;

var text										: GameObject;

function Start () {
	
}

function Update () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);
	
	if (canPicture && inPicture && Input.GetButtonDown("Action"))
	{
		Application.CaptureScreenshot("screenshot.png");
		
		message.displaySubtitle("Finally.. Now can I do what I came here to do?", 5);
		message.displayWarning("Picture Taken, Received New Badge \n Press Tab to Open Inventory", 5);
		message.displayInfo("Greg Clemens", 5);
		
		tookPicture = true;
		canPicture = false;
	}
}

function OnMouseEnter ()
{
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (canPicture)
	{
		message.displayWarning("Press T to Take Picture", 100);
	
		inPicture = true;
	}
}

function OnMouseExit ()
{
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (canPicture)
	{
		message.warning.enabled = false;
	
		inPicture = false;
	}
}