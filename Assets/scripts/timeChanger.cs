/*using UnityEngine;
using System.Collections;

public class timeChanger : MonoBehaviour {

	// Variable to hold which path the player is on from the decisions they've made
	int pathChosen		= 0;
	
	// Variables to hold which decisions the player makes
	int path1	= 0;
	int path2	= 1;
	int path3	= 2;
	
	// Variables to hold the npc game object so that we can access its scripts
	GameObject npc;

	private npcBehavior		path;

	void Awake () {

		path = npc.GetComponent <npcBehavior> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// If the player chose path 1
		if (pathChosen == path1) {
			
			// Switch the level to update the time based on the path chosen
			//Application.LoadLevel(2);
		}
		
		else if (pathChosen == path2) {
			//Application.LoadLevel(2);
		}
		
		else if (pathChosen == path3) {
			//Application.LoadLevel(2);
		}
	}
}*/