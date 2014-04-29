﻿#pragma strict

var healthNum			: Texture2D[];
var itemNum				: Texture2D[];

var healthGUI 			: GUITexture;

var inventory			: GUITexture;
var item1	 			: GUITexture;
var item2 				: GUITexture;
var item3 				: GUITexture;
var item4 				: GUITexture;

var menu				: GUITexture;

var PC					: GameObject;
var npc					: GameObject;
var maria				: GameObject;
var holder				: GameObject;

function Start () {
	
}

function Update () {
	var player : playerScript = PC.gameObject.GetComponent(playerScript);
	var inv : cameraScript = holder.gameObject.GetComponent(cameraScript);
	var m : menuScript = holder.gameObject.GetComponent(menuScript);
	var key : securityBehavior = npc.gameObject.GetComponent(securityBehavior);
	var badge : mariaBehavior = maria.gameObject.GetComponent(mariaBehavior);
	
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
		
		if (key.talkCount >= 1)
		{
			if (!item1.enabled)
			{
				item1.enabled = true;
			}
		}
		
		if (badge.talkCount >= 1)
		{
			if (!item2.enabled)
			{
				item2.enabled = true;
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