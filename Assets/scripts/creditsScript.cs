using UnityEngine;
using System.Collections;

public class creditsScript : MonoBehaviour {

	public GUITexture icBG;

	public float scrollSpeed;

	public GUISkin mySkin;

	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;
	public GameObject text5;
	public GameObject text6;
	public GameObject text7;
	public Vector2 oPosition1;
	public Vector2 oPosition2;
	public Vector2 oPosition3;
	public Vector2 oPosition4;
	public Vector2 oPosition5;
	public Vector2 oPosition6;
	public Vector2 oPosition7;
	public Vector2 position1;
	public Vector2 position2;
	public Vector2 position3;
	public Vector2 position4;
	public Vector2 position5;
	public Vector2 position6;
	public Vector2 position7;

	public GameObject Text;

	private uiSystem message;

	void Awake ()
	{
		message = Text.GetComponent <uiSystem> ();
	}

	// Use this for initialization
	void Start () {

		icBG.pixelInset = new Rect(0, 0, Screen.width, Screen.height);

		oPosition1 = new Vector2(text1.transform.position.x, text1.transform.position.y);
		oPosition2 = new Vector2(text2.transform.position.x, text2.transform.position.y);
		oPosition3 = new Vector2(text3.transform.position.x, text3.transform.position.y);
		oPosition4 = new Vector2(text4.transform.position.x, text4.transform.position.y);
		oPosition5 = new Vector2(text5.transform.position.x, text5.transform.position.y);
		oPosition6 = new Vector2(text6.transform.position.x, text6.transform.position.y);
		oPosition7 = new Vector2(text7.transform.position.x, text7.transform.position.y);

		position1 = new Vector2(text1.transform.position.x, text1.transform.position.y);
		position2 = new Vector2(text2.transform.position.x, text2.transform.position.y);
		position3 = new Vector2(text3.transform.position.x, text3.transform.position.y);
		position4 = new Vector2(text4.transform.position.x, text4.transform.position.y);
		position5 = new Vector2(text5.transform.position.x, text5.transform.position.y);
		position6 = new Vector2(text6.transform.position.x, text6.transform.position.y);
		position7 = new Vector2(text7.transform.position.x, text7.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {

		if (position7.y >= 10)
		{
			position1 = oPosition1;
			position2 = oPosition2;
			position3 = oPosition3;
			position4 = oPosition4;
			position5 = oPosition5;
			position6 = oPosition6;
			position7 = oPosition7;
		}

		else
		{
			position1.y += scrollSpeed * Time.deltaTime;
			position2.y += scrollSpeed * Time.deltaTime;
			position3.y += scrollSpeed * Time.deltaTime;
			position4.y += scrollSpeed * Time.deltaTime;
			position5.y += scrollSpeed * Time.deltaTime;
			position6.y += scrollSpeed * Time.deltaTime;
			position7.y += scrollSpeed * Time.deltaTime;
			
			text1.transform.position = position1;
			text2.transform.position = position2;
			text3.transform.position = position3;
			text4.transform.position = position4;
			text5.transform.position = position5;
			text6.transform.position = position6;
			text7.transform.position = position7;
		}
	}

	void OnGUI ()
	{
		if (GUI.skin != mySkin)
		{
			GUI.skin = mySkin;
		}

		if (GUI.Button (new Rect(Screen.width * .87f, Screen.height * .8f, Screen.width / 9, Screen.height / 14), "Reset Game"))
		{
			if (Event.current.button == 1 || Event.current.button == 2)
			{
				
			}
			
			else
			{
				Application.LoadLevel(0);
			}
		}

		if (GUI.Button (new Rect(Screen.width * .87f, Screen.height * .9f, Screen.width / 9, Screen.height / 14), "Quit Game"))
		{
			if (Event.current.button == 1 || Event.current.button == 2)
			{
				
			}
			
			else
			{
				Application.Quit();
			}
		}
	}
}