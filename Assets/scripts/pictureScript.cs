using UnityEngine;
using System.Collections;

public class pictureScript : MonoBehaviour {

	public bool canPicture		= false;
	public bool inPicture		= false;
	public bool tookPicture	= false;

	public GameObject pc;
	public GameObject text;

	private CharacterMotor		movement;
	private uiSystem	message;

	void Awake () {

		movement 	= pc.GetComponent <CharacterMotor> ();
		message = text.GetComponent <uiSystem> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (canPicture && inPicture && Input.GetButtonDown("Action"))
		{
			//Application.CaptureScreenshot("screenshot.png");
			
			message.displaySubtitle("Finally.. Now can I do what I came here to do?", 5);
			message.displayWarning("Picture Taken, Received New Badge \n Press Tab to Open Inventory", 5);
			message.displayInfo("Greg Clemens", 5);

			movement.enabled = true;

			tookPicture = true;
			canPicture = false;
		}
	}
	
	void OnMouseEnter ()
	{
		
		if (canPicture)
		{
			message.displayWarning("Press T to Take Picture", 100);
			
			inPicture = true;
		}
	}
	
	void OnMouseExit ()
	{
		
		if (canPicture)
		{
			message.warning.enabled = false;
			
			inPicture = false;
		}
	}
}