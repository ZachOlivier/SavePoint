using UnityEngine;
using System.Collections;

public class pictureScript : MonoBehaviour {

	public bool canPicture		= false;
	public bool inPicture		= false;
	public bool tookPicture		= false;
	public bool flashed			= false;

	public float time;
	public float timer;

	public GameObject light;

	public GameObject pc;
	public GameObject text;
	public GameObject holder;

	private CharacterMotor		movement;
	private uiSystem			message;
	private cameraScript		cam;
	private menuScript			menu;

	void Awake () {

		movement 	= pc.GetComponent <CharacterMotor> ();
		message 	= text.GetComponent <uiSystem> ();
		cam 		= holder.GetComponent <cameraScript> ();
		menu 		= holder.GetComponent <menuScript> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (canPicture && inPicture && Input.GetButtonDown("Talk"))
		{
			//Application.CaptureScreenshot("screenshot.png");
			
			message.displaySubtitle("Finally.. Now can I do what I came here to do?", 5);
			message.displayWarning("Picture Taken, Received Badge\nPress Tab to Open Inventory", 5);
			message.displayInfo("Greg Clemens", 5);

			movement.enabled = true;
			menu.canMenu = true;
			cam.canChange = true;

			tookPicture = true;
			canPicture = false;
		}

		if (!flashed && tookPicture)
		{
			timer += Time.deltaTime;

			light.light.enabled = true;

			if (timer >= time)
			{
				light.light.enabled = false;

				timer = 0;

				flashed = true;
			}
		}
	}
	
	void OnMouseEnter ()
	{
		
		if (canPicture)
		{
			message.displayWarning("Press E to Take Picture", 100);
			
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