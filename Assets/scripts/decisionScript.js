#pragma strict

// Variables to tell whether the mouse is hovering over a decision box
var decisionOne											: boolean = false;
var decisionTwo											: boolean = false;
var decisionThree										: boolean = false;
var decisionFour										: boolean = false;

// Variable to tell whether the decisions can be clicked or not
var canClick											: boolean = false;

// Variables to hold the decisions the player can make
var path1												: int = 1;
var path11												: int = 11;
var path12												: int = 12;
var path13												: int = 13;
var path14												: int = 14;
var path111												: int = 111;
var path112												: int = 112;
var path113												: int = 113;
var path114												: int = 114;
var path121												: int = 121;
var path122												: int = 122;
var path123												: int = 123;
var path124												: int = 124;
var path131												: int = 131;
var path132												: int = 132;
var path133												: int = 133;
var path134												: int = 134;
var path141												: int = 141;
var path142												: int = 142;
var path143												: int = 143;
var path144												: int = 144;

var path2												: int = 2;
var path21												: int = 21;
var path22												: int = 22;
var path23												: int = 23;
var path24												: int = 24;
var path211												: int = 211;
var path212												: int = 212;
var path213												: int = 213;
var path214												: int = 214;
var path221												: int = 221;
var path222												: int = 222;
var path223												: int = 223;
var path224												: int = 224;
var path231												: int = 231;
var path232												: int = 232;
var path233												: int = 233;
var path234												: int = 234;
var path241												: int = 241;
var path242												: int = 242;
var path243												: int = 243;
var path244												: int = 244;

var path3												: int = 3;
var path31												: int = 31;
var path32												: int = 32;
var path33												: int = 33;
var path34												: int = 34;
var path311												: int = 311;
var path312												: int = 312;
var path313												: int = 313;
var path314												: int = 314;
var path321												: int = 321;
var path322												: int = 322;
var path323												: int = 323;
var path324												: int = 324;
var path331												: int = 331;
var path332												: int = 332;
var path333												: int = 333;
var path334												: int = 334;
var path341												: int = 341;
var path342												: int = 342;
var path343												: int = 343;
var path344												: int = 344;

var path4												: int = 4;
var path41												: int = 41;
var path42												: int = 42;
var path43												: int = 43;
var path44												: int = 44;
var path411												: int = 411;
var path412												: int = 412;
var path413												: int = 413;
var path414												: int = 414;
var path421												: int = 421;
var path422												: int = 422;
var path423												: int = 423;
var path424												: int = 424;
var path431												: int = 431;
var path432												: int = 432;
var path433												: int = 433;
var path434												: int = 434;
var path441												: int = 441;
var path442												: int = 442;
var path443												: int = 443;
var path444												: int = 444;

// Variable to hold the holder and npc game objects so that we can access its scripts
var npc													: GameObject;
var holder												: GameObject;
var text												: GameObject;

// This function only fires once during the start of this script
function Start () {

}

// This function fires over and over again throughout the life of this script
function Update () {
	var talk : npcBehavior = npc.gameObject.GetComponent(npcBehavior);
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (Input.GetButtonDown("Fire1") && decisionOne && this.gameObject.name == "decision1Box") {
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
		
		talk.time = 1;
		
		canClick = false;
		decisionOne = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
	
	if (Input.GetButtonDown("Fire1") && decisionTwo && this.gameObject.name == "decision2Box") {
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
		
		talk.time = 1;
		
		canClick = false;
		decisionTwo = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
	
	if (Input.GetButtonDown("Fire1") && decisionThree && this.gameObject.name == "decision3Box") {
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
		
		talk.time = 1;
		
		canClick = false;
		decisionThree = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
	
	if (Input.GetButtonDown("Fire1") && decisionFour && this.gameObject.name == "decision4Box") {
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
		
		talk.time = 1;
		
		canClick = false;
		decisionFour = false;
		
		message.decision1.enabled = false;
		message.decision2.enabled = false;
		message.decision3.enabled = false;
		message.decision4.enabled = false;
	}
}

function OnMouseEnter () {
	var message : uiSystem = text.gameObject.GetComponent(uiSystem);

	if (this.gameObject.name == "decision1Box" && canClick) {
		message.displayInfo("Decision 1 Path", 3);
	
		decisionOne = true;
	}
	
	if (this.gameObject.name == "decision2Box" && canClick) {
		message.displayInfo("Decision 2 Path", 3);
	
		decisionTwo = true;
	}
	
	if (this.gameObject.name == "decision3Box" && canClick) {
		message.displayInfo("Decision 3 Path", 3);
	
		decisionThree = true;
	}
	
	if (this.gameObject.name == "decision4Box" && canClick) {
		message.displayInfo("Decision 4 Path", 3);
	
		decisionFour = true;
	}
}

function OnMouseExit () {
	if (this.gameObject.name == "decision1Box" && canClick) {
		decisionOne = false;
	}
	
	if (this.gameObject.name == "decision2Box" && canClick) {
		decisionTwo = false;
	}
	
	if (this.gameObject.name == "decision3Box" && canClick) {
		decisionThree = false;
	}
	
	if (this.gameObject.name == "decision4Box" && canClick) {
		decisionFour = false;
	}
}