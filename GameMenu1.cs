using UnityEngine;
using System.Collections;

public class GameMenu1 : MonoBehaviour {

	// static bool that checks if Controls gui is open
	public static bool helpOpen = true;

	public static int fleetCount = 0;
	public static bool fleetOdd = true;
	//public float horChange = 0;
	//public float vertChange = 0;

	void Awake (){

	}
	
	void OnGUI () {
		
		// GUI - SOLAR SYSTEM title if not in Planet View, PLANET NAME if in Planet View
		if (SelectorScript.planetView || SelectorScript.planetHover == true) {
			GUI.Box (new Rect (Screen.width / 2 - 60, 10, 120, 25), PlanetAssigner.planetInstance[SelectorScript.planetNum].planetName);
		} 
		else {
			GUI.Box(new Rect(Screen.width/2-60,10,120,25), "SOLAR SYSTEM");
		}
	

		// GUI - Game Menu
		GUI.Box(new Rect(10,10,100,100), "Game Menu");
		
		// Button - Load Main Menu 
		if(GUI.Button(new Rect(15,35,90,20), "Main Menu") && SolarGenerator.turnEnd == false) {
			helpOpen = false;
			Application.LoadLevel(0);
		}

		// GUI - Help Button
		if(GUI.Button(new Rect(15,60,90,20), "Help")) {
			helpOpen = true;
		}

			// GUI - Help Popup Window - Planet View
			if(helpOpen == true && SelectorScript.planetView == true){
				GUI.Box(new Rect(Screen.width/2-180,65,360,85), "Help Guide\n" +
					"Select a structure from the Build Structures menu to build it.\n" +
				    "If you have a ship hangar,\nselect a unit from the Build Units menu to build it.\n" +
				    "Click \"Exit\" under Planet View to return to the Solar Map.");
				// If X is clicked, make helpOpen false so that popup windows disappears
				if(GUI.Button(new Rect(Screen.width/2+155,65,25,20), "X")){
					helpOpen = false;
				}
			}
			
			// GUI - Help Popup Window - Solar System
			if(helpOpen == true && SelectorScript.planetView == false){
				GUI.Box(new Rect(Screen.width/2-180,65,360,70), "Help Guide\n" +
			    	"Click and drag to move around the Solar System.\n" +
					"Zoom in and out with the scroll wheel.\n" +
					"Click on a planet to enter Planet View.");
				// If X is clicked, make helpOpen false so that popup windows disappears
				if(GUI.Button(new Rect(Screen.width/2+155,65,25,20), "X")){
					helpOpen = false;
				}
			}

		// Button - Load Cluster Map
		if(GUI.Button(new Rect(15,85,90,20), "Cluster Map") && SolarGenerator.turnEnd == false) {
			helpOpen = false;
			Application.LoadLevel(1);
		}

		// GUI - Planet View/Exit Menu displays when in Planet View
		if(SelectorScript.planetView == true && SelectorScript.viewTransition == false) {
			GUI.Box(new Rect(120,10,100,50), "Planet View");	
			
			// Button - Exit Planet View - When clicked, reset main camera to xy position of planet with z of -14
			if(GUI.Button(new Rect(125,35,90,20), "Exit")) {
				SelectorScript.exitingPlanet = true;
				SelectorScript.planetView = false;
				GameMenu1.helpOpen = false;


			}
		}

		//----------//
		// GUI - Planet Information displays when in Planet View
		
		if(SelectorScript.planetView == true || SelectorScript.planetHover == true) {
			
			GUI.Box(new Rect(Screen.width/2-194,Screen.height-65,388,62), "Planet Information");
			
			GUI.Box(new Rect(Screen.width/2-190,Screen.height-44,60,38), "Ships\n" + PlanetAssigner.planetInstance[SelectorScript.planetNum].shipCount);
			
			if (PlanetAssigner.planetInstance[SelectorScript.planetNum].hangarBuilt == false){
				GUI.Box(new Rect(Screen.width/2-126,Screen.height-44,60,38), "Hangar\nNo");
			}
			else{
				GUI.Box(new Rect(Screen.width/2-126,Screen.height-44,60,38), "Hangar\nYes");
			}
			
			GUI.Box(new Rect(Screen.width/2-62,Screen.height-44,60,38), "Fleets\n" + PlanetAssigner.planetInstance[SelectorScript.planetNum].localFleetCount);
			GUI.Box(new Rect(Screen.width/2+2,Screen.height-44,60,38), "Other\n");
			GUI.Box(new Rect(Screen.width/2+66,Screen.height-44,60,38), "Other\n");
			GUI.Box(new Rect(Screen.width/2+130,Screen.height-44,60,38), "Other\n");

		}

		
		//----------//
		// GUI - Player Information Menu 
			
		GUI.Box(new Rect(Screen.width-150,Screen.height/2-65,140,100), "Player Information");	

		// Button - View Technology Tree
		if(GUI.Button(new Rect(Screen.width-145,Screen.height/2-40,130,20), "Economy")) {

			//Functionality Unavailable
			//make messageBox1 true and save time that button was pressed
			GameController1.messageBox1 = true;
			GameController1.buttonDownTime = Time.time;
			//make other messages false (look into lists)
			GameController1.messageBox2 = false;
			GameController1.messageBox3 = false;
			GameController1.messageBox4 = false;
			GameController1.messageBox5 = false;
				
		}

		// Button - View Technology Tree
		if(GUI.Button(new Rect(Screen.width-145,Screen.height/2-15,130,20), "Supply Lines")) {
			
			//Functionality Unavailable
			//make messageBox1 true and save time that button was pressed
			GameController1.messageBox1 = true;
			GameController1.buttonDownTime = Time.time;
			//make other messages false (look into lists)
			GameController1.messageBox2 = false;
			GameController1.messageBox3 = false;
			GameController1.messageBox4 = false;
			GameController1.messageBox5 = false;
			
		}

		// Button - View Technology Tree
		if(GUI.Button(new Rect(Screen.width-145,Screen.height/2+10,130,20), "Tech Tree")) {
			
			//Functionality Unavailable
			//make messageBox1 true and save time that button was pressed
			GameController1.messageBox1 = true;
			GameController1.buttonDownTime = Time.time;
			//make other messages false (look into lists)
			GameController1.messageBox2 = false;
			GameController1.messageBox3 = false;
			GameController1.messageBox4 = false;
			GameController1.messageBox5 = false;
			
		}

		//----------//
		// GUI - Fleets Menu
		// box size dependent on number of fleets	
		GUI.Box(new Rect(Screen.width-150,Screen.height/2+40,140,50+(30*fleetCount)), "Fleets");


		// Button - New Fleet increases fleetCount by 1
		if(GUI.Button(new Rect(Screen.width-130,Screen.height/2+65,100,20), "New Fleet")) {

			//only allow new fleet creation when in Planet View
			if (SelectorScript.planetView && SelectorScript.viewTransition == false)
			{
				// if fleet count is not maxed out, add 1 to fleetCount
				if(fleetCount < 5)
				{
					fleetCount += 1;
					PlanetAssigner.planetInstance[SelectorScript.planetNum].localFleetCount += 1;
				}

				// else (fleet count is maxed out), display message about tech tree requirement
				else
				{
					//make messageBox4 true and save time that button was pressed
					GameController1.messageBox4 = true;
					GameController1.buttonDownTime = Time.time;
					//make other messages false (look into lists)
					GameController1.messageBox1 = false;
					GameController1.messageBox2 = false;
					GameController1.messageBox3 = false;
					GameController1.messageBox5 = false;
				}	
			}

			// else (not in Planet View), display message about Planet View requirement
			else
			{
				//make messageBox4 true and save time that button was pressed
				GameController1.messageBox5 = true;
				GameController1.buttonDownTime = Time.time;
				//make other messages false (look into lists)
				GameController1.messageBox1 = false;
				GameController1.messageBox2 = false;
				GameController1.messageBox3 = false;
				GameController1.messageBox4 = false;
			}	
		}

		// Display fleet icons
		for(int i = 1; i <= fleetCount; i++)
		{
			GUI.backgroundColor = Color.cyan;
			GUI.Button(new Rect(Screen.width-145,Screen.height/2+60+(30*i),130,25), "" + i);
			
		}

		/*
		// Display fleets in Planet View
		if (SelectorScript.planetView)
		{
			for(int i = 0; i < PlanetAssigner.planetInstance[SelectorScript.planetNum].localFleetCount; i++)
			{
				// fleet position, relative to planet
				GUI.Box(new Rect(Screen.width/2+300,Screen.height/2-100, 200, 200), "");
			}
		}
		*/
	} // end of OnGUI()
	
}
