using UnityEngine;
using System.Collections;

public class guiSystem : MonoBehaviour {

	public Texture2D[] healthNum;
	public Texture2D[] itemNum;

	public bool badgeTaken		= false;

	public GUITexture healthGUI;

	public GUITexture inventory;
	public GUITexture item1;
	public GUITexture item2;
	public GUITexture item3;
	public GUITexture item4;

	public GameObject item2GUI;

	public GUITexture menu;

	public GameObject PC;
	public GameObject npc;
	public GameObject picture;
	public GameObject holder;

	private playerScript		player;
	private cameraScript		inv;
	private menuScript			m;
	private securityBehavior	key;
	//private mariaBehavior		badge;
	private pictureScript		badge;

	void Awake () {

		player 		= PC.GetComponent <playerScript> ();
		inv		 	= holder.GetComponent <cameraScript> ();
		m			= holder.GetComponent <menuScript> ();
		key 		= npc.GetComponent <securityBehavior> ();
		//badge 		= maria.GetComponent <mariaBehavior> ();
		badge 		= picture.GetComponent <pictureScript> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (healthGUI.texture != healthNum[player.health - 1])
		{
			healthGUI.texture = healthNum[player.health - 1];
		}
		
		if (inv.cameraMode == 1)
		{
			if (!inventory.enabled)
			{
				inventory.enabled = true;
			}
			
			if (key.talkCount >= 2)
			{
				if (!item1.enabled)
				{
					item1.enabled = true;
				}
			}
			
			if (badge.tookPicture == true)
			{
				if (!item2.enabled)
				{
					//Be sure to uncomment this part in order to make the badge the screenshot!
					//item2GUI.guiTexture.texture = Resources.Load("screenshot.png");
					
					item2.enabled = true;
				}
			}
			
			if (badgeTaken == true)
			{
				if (!item3.enabled)
				{
					item3.enabled = true;
				}
			}
		}
		
		else if (inv.cameraMode == 0)
		{
			if (inventory.enabled)
			{
				inventory.enabled = false;
			}
			
			if (item1.enabled || item2.enabled || item3.enabled || item4.enabled)
			{
				item1.enabled = false;
				item2.enabled = false;
				item3.enabled = false;
				item4.enabled = false;
			}
		}
		
		if (m.menuMode == 1)
		{
			
		}
		
		else if (m.menuMode == 0)
		{
			
		}
	}
}