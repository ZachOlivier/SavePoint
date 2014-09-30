using UnityEngine;
using System.Collections;

public class decisionScript1 : MonoBehaviour {
	
	// Variables to tell whether the mouse is hovering over a decision box
	public bool fourDecisionOne										= false;
	public bool fourDecisionTwo										= false;
	public bool fourDecisionThree									= false;
	public bool fourDecisionFour									= false;
	
	// Variable to tell whether the decisions can be clicked or not
	public bool canClick											= false;
	
	// Variables to hold the decisions the player can make
	public int path1												= 1;
	public int path11												= 11;
	public int path12												= 12;
	public int path13												= 13;
	public int path14												= 14;
	public int path111												= 111;
	public int path112												= 112;
	public int path113												= 113;
	public int path114												= 114;
	public int path121												= 121;
	public int path122												= 122;
	public int path123												= 123;
	public int path124												= 124;
	public int path131												= 131;
	public int path132												= 132;
	public int path133												= 133;
	public int path134												= 134;
	public int path141												= 141;
	public int path142												= 142;
	public int path143												= 143;
	public int path144												= 144;
	
	public int path2												= 2;
	public int path21												= 21;
	public int path22												= 22;
	public int path23												= 23;
	public int path24												= 24;
	public int path211												= 211;
	public int path212												= 212;
	public int path213												= 213;
	public int path214												= 214;
	public int path221												= 221;
	public int path222												= 222;
	public int path223												= 223;
	public int path224												= 224;
	public int path231												= 231;
	public int path232												= 232;
	public int path233												= 233;
	public int path234												= 234;
	public int path241												= 241;
	public int path242												= 242;
	public int path243												= 243;
	public int path244												= 244;
	
	public int path3												= 3;
	public int path31												= 31;
	public int path32												= 32;
	public int path33												= 33;
	public int path34												= 34;
	public int path311												= 311;
	public int path312												= 312;
	public int path313												= 313;
	public int path314												= 314;
	public int path321												= 321;
	public int path322												= 322;
	public int path323												= 323;
	public int path324												= 324;
	public int path331												= 331;
	public int path332												= 332;
	public int path333												= 333;
	public int path334												= 334;
	public int path341												= 341;
	public int path342												= 342;
	public int path343												= 343;
	public int path344												= 344;
	
	public int path4												= 4;
	public int path41												= 41;
	public int path42												= 42;
	public int path43												= 43;
	public int path44												= 44;
	public int path411												= 411;
	public int path412												= 412;
	public int path413												= 413;
	public int path414												= 414;
	public int path421												= 421;
	public int path422												= 422;
	public int path423												= 423;
	public int path424												= 424;
	public int path431												= 431;
	public int path432												= 432;
	public int path433												= 433;
	public int path434												= 434;
	public int path441												= 441;
	public int path442												= 442;
	public int path443												= 443;
	public int path444												= 444;
	
	// Variable to hold the holder and npc game objects so that we can access its scripts
	public GameObject 		maria;
	public GameObject 		holder;
	public GameObject		text;
	
	private mariaBehavior		talk;
	private uiSystem			message;
	
	void Awake () {
		
		talk 		= maria.GetComponent <mariaBehavior> ();
		message 	= text.GetComponent <uiSystem> ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("Fire1") && fourDecisionOne && this.gameObject.name == "decideBox1") {
			
			talk.hasDisplayed = false;
			talk.talkSection++;
			
			if (talk.path == 0) {
				talk.path = path1;
			}
			
			else if (talk.path == 1) {
				talk.path = path11;
			}
			
			else if (talk.path == 2) {
				talk.path = path21;
			}
			
			else if (talk.path == 3) {
				talk.path = path31;
			}
			
			else if (talk.path == 4) {
				talk.path = path41;
			}
			
			else if (talk.path == 11) {
				talk.path = path111;
			}
			
			else if (talk.path == 12) {
				talk.path = path121;
			}
			
			else if (talk.path == 13) {
				talk.path = path131;
			}
			
			else if (talk.path == 14) {
				talk.path = path141;
			}
			
			else if (talk.path == 21) {
				talk.path = path211;
			}
			
			else if (talk.path == 22) {
				talk.path = path221;
			}
			
			else if (talk.path == 23) {
				talk.path = path231;
			}
			
			else if (talk.path == 24) {
				talk.path = path241;
			}
			
			else if (talk.path == 31) {
				talk.path = path311;
			}
			
			else if (talk.path == 32) {
				talk.path = path321;
			}
			
			else if (talk.path == 33) {
				talk.path = path331;
			}
			
			else if (talk.path == 34) {
				talk.path = path341;
			}
			
			else if (talk.path == 41) {
				talk.path = path411;
			}
			
			else if (talk.path == 42) {
				talk.path = path421;
			}
			
			else if (talk.path == 43) {
				talk.path = path431;
			}
			
			else if (talk.path == 44) {
				talk.path = path441;
			}
			
			canClick = false;

			message.fourDecision1.enabled = false;
			message.fourDecision2.enabled = false;
			message.fourDecision3.enabled = false;
			message.fourDecision4.enabled = false;

			message.displayingOne 	= false;
			message.displayingTwo 	= false;
			message.displayingThree = false;
			message.displayingFour 	= false;
			
			fourDecisionOne = false;
		}
		
		if (Input.GetButtonDown("Fire1") && fourDecisionTwo && this.gameObject.name == "decideBox2") {
			
			talk.hasDisplayed = false;
			talk.talkSection++;
			
			if (talk.path == 0) {
				talk.path = path2;
			}
			
			else if (talk.path == 1) {
				talk.path = path12;
			}
			
			else if (talk.path == 2) {
				talk.path = path22;
			}
			
			else if (talk.path == 3) {
				talk.path = path32;
			}
			
			else if (talk.path == 4) {
				talk.path = path42;
			}
			
			else if (talk.path == 11) {
				talk.path = path112;
			}
			
			else if (talk.path == 12) {
				talk.path = path122;
			}
			
			else if (talk.path == 13) {
				talk.path = path132;
			}
			
			else if (talk.path == 14) {
				talk.path = path142;
			}
			
			else if (talk.path == 21) {
				talk.path = path212;
			}
			
			else if (talk.path == 22) {
				talk.path = path222;
			}
			
			else if (talk.path == 23) {
				talk.path = path232;
			}
			
			else if (talk.path == 24) {
				talk.path = path242;
			}
			
			else if (talk.path == 31) {
				talk.path = path312;
			}
			
			else if (talk.path == 32) {
				talk.path = path322;
			}
			
			else if (talk.path == 33) {
				talk.path = path332;
			}
			
			else if (talk.path == 34) {
				talk.path = path342;
			}
			
			else if (talk.path == 41) {
				talk.path = path412;
			}
			
			else if (talk.path == 42) {
				talk.path = path422;
			}
			
			else if (talk.path == 43) {
				talk.path = path432;
			}
			
			else if (talk.path == 44) {
				talk.path = path442;
			}
			
			canClick = false;

			message.fourDecision1.enabled = false;
			message.fourDecision2.enabled = false;
			message.fourDecision3.enabled = false;
			message.fourDecision4.enabled = false;

			message.displayingOne 	= false;
			message.displayingTwo 	= false;
			message.displayingThree = false;
			message.displayingFour 	= false;
			
			fourDecisionTwo = false;
		}
		
		if (Input.GetButtonDown("Fire1") && fourDecisionThree && this.gameObject.name == "decideBox3") {
			
			talk.hasDisplayed = false;
			talk.talkSection++;
			
			if (talk.path == 0) {
				talk.path = path3;
			}
			
			else if (talk.path == 1) {
				talk.path = path13;
			}
			
			else if (talk.path == 2) {
				talk.path = path23;
			}
			
			else if (talk.path == 3) {
				talk.path = path33;
			}
			
			else if (talk.path == 4) {
				talk.path = path43;
			}
			
			else if (talk.path == 11) {
				talk.path = path113;
			}
			
			else if (talk.path == 12) {
				talk.path = path123;
			}
			
			else if (talk.path == 13) {
				talk.path = path133;
			}
			
			else if (talk.path == 14) {
				talk.path = path143;
			}
			
			else if (talk.path == 21) {
				talk.path = path213;
			}
			
			else if (talk.path == 22) {
				talk.path = path223;
			}
			
			else if (talk.path == 23) {
				talk.path = path233;
			}
			
			else if (talk.path == 24) {
				talk.path = path243;
			}
			
			else if (talk.path == 31) {
				talk.path = path313;
			}
			
			else if (talk.path == 32) {
				talk.path = path323;
			}
			
			else if (talk.path == 33) {
				talk.path = path333;
			}
			
			else if (talk.path == 34) {
				talk.path = path343;
			}
			
			else if (talk.path == 41) {
				talk.path = path413;
			}
			
			else if (talk.path == 42) {
				talk.path = path423;
			}
			
			else if (talk.path == 43) {
				talk.path = path433;
			}
			
			else if (talk.path == 44) {
				talk.path = path443;
			}
			
			canClick = false;

			message.fourDecision1.enabled = false;
			message.fourDecision2.enabled = false;
			message.fourDecision3.enabled = false;
			message.fourDecision4.enabled = false;

			message.displayingOne 	= false;
			message.displayingTwo 	= false;
			message.displayingThree = false;
			message.displayingFour 	= false;
			
			fourDecisionThree = false;
		}
		
		if (Input.GetButtonDown("Fire1") && fourDecisionFour && this.gameObject.name == "decideBox4") {
			
			talk.hasDisplayed = false;
			talk.talkSection++;
			
			if (talk.path == 0) {
				talk.path = path4;
			}
			
			else if (talk.path == 1) {
				talk.path = path14;
			}
			
			else if (talk.path == 2) {
				talk.path = path24;
			}
			
			else if (talk.path == 3) {
				talk.path = path34;
			}
			
			else if (talk.path == 4) {
				talk.path = path44;
			}
			
			else if (talk.path == 11) {
				talk.path = path114;
			}
			
			else if (talk.path == 12) {
				talk.path = path124;
			}
			
			else if (talk.path == 13) {
				talk.path = path134;
			}
			
			else if (talk.path == 14) {
				talk.path = path144;
			}
			
			else if (talk.path == 21) {
				talk.path = path214;
			}
			
			else if (talk.path == 22) {
				talk.path = path224;
			}
			
			else if (talk.path == 23) {
				talk.path = path234;
			}
			
			else if (talk.path == 24) {
				talk.path = path244;
			}
			
			else if (talk.path == 31) {
				talk.path = path314;
			}
			
			else if (talk.path == 32) {
				talk.path = path324;
			}
			
			else if (talk.path == 33) {
				talk.path = path334;
			}
			
			else if (talk.path == 34) {
				talk.path = path344;
			}
			
			else if (talk.path == 41) {
				talk.path = path414;
			}
			
			else if (talk.path == 42) {
				talk.path = path424;
			}
			
			else if (talk.path == 43) {
				talk.path = path434;
			}
			
			else if (talk.path == 44) {
				talk.path = path444;
			}
			
			canClick = false;

			message.fourDecision1.enabled = false;
			message.fourDecision2.enabled = false;
			message.fourDecision3.enabled = false;
			message.fourDecision4.enabled = false;

			message.displayingOne 	= false;
			message.displayingTwo 	= false;
			message.displayingThree = false;
			message.displayingFour 	= false;
			
			fourDecisionFour = false;
		}
	}
	
	void OnMouseEnter () {
		
		if (this.gameObject.name == "decideBox1" && canClick) {
			fourDecisionOne = true;
		}
		
		if (this.gameObject.name == "decideBox2" && canClick) {
			fourDecisionTwo = true;
		}
		
		if (this.gameObject.name == "decideBox3" && canClick) {
			fourDecisionThree = true;
		}
		
		if (this.gameObject.name == "decideBox4" && canClick) {
			fourDecisionFour = true;
		}
	}
	
	void OnMouseExit () {
		
		if (this.gameObject.name == "decideBox1" && canClick) {
			fourDecisionOne = false;
		}
		
		if (this.gameObject.name == "decideBox2" && canClick) {
			fourDecisionTwo = false;
		}
		
		if (this.gameObject.name == "decideBox3" && canClick) {
			fourDecisionThree = false;
		}
		
		if (this.gameObject.name == "decideBox4" && canClick) {
			fourDecisionFour = false;
		}
	}
}