using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

	public GameObject shipHangar1;
	private GameObject hangar1;
	 
	public GameObject ship1;
	private GameObject ship;

	public static bool hangarSound = false;
	public static bool shipSound = false;
	
	// Ships Visible is a float so that it can be divided by another number to calculate starting position, which depends on # of Visible Ships
	public static float shipsVisible = 0f;


	void Start () {

	}

	void FixedUpdate(){

		// if in Planet View and hangar is built, rotate consistently around planet
		if (SelectorScript.planetView == true && hangar1 != null && PlanetAssigner.planetInstance[SelectorScript.planetNum].hangarBuilt == true) {
			hangar1.transform.RotateAround (transform.position, Vector3.forward, 0.5f);
		}
	}

	void Update () {

		// if in Planet View and a Ship Hangar has been built and hangar1 = null, call ShipHangar() which instantiates hangar object
		if (SelectorScript.planetView == true && hangar1 == null && PlanetAssigner.planetInstance[SelectorScript.planetNum].hangarBuilt == true){
			ShipHangar();
		}	

		// If ships have already been built, this instantiates ships when entering Planet View
		if (SelectorScript.planetView == true && PlanetAssigner.planetInstance[SelectorScript.planetNum].shipCount > 0 && shipsVisible == 0f){
			for(int i = 0; i < PlanetAssigner.planetInstance[SelectorScript.planetNum].shipCount; i++){
				ShipCreation();
			}
		}
	}

	// function to instantiate ship objects next to active planet
	void ShipCreation(){
		
		// ship starting position, relative to planet
		Vector3 shipStartPosition = new Vector3((SelectorScript.activePlanet.transform.position.x + (SelectorScript.activePlanet.transform.localScale.x*1.05f)), SelectorScript.activePlanet.transform.position.y + .45f - (shipsVisible/10f), SelectorScript.activePlanet.transform.position.z);
		
		// instantiate ship object
		ship = Instantiate (ship1, shipStartPosition, ship1.transform.rotation) as GameObject;
		
		// set ship tag to "Ship"
		ship.tag = "Ship";
		
		// increase shipsVisible by 1
		shipsVisible += 1f;
		
	}

	// function to instantiate hangar object and start at random orbit position around planet
	void ShipHangar(){

		// hangar starting x position should be planet's x position - (planet x scale - .2)
		Vector3 hangarStartPosition = new Vector3((transform.position.x - (transform.localScale.x/2 + .15f)), transform.position.y, transform.position.z);

		hangar1 = Instantiate(shipHangar1, hangarStartPosition, Quaternion.identity) as GameObject;
		hangar1.transform.RotateAround(transform.position, Vector3.forward, Random.Range(0F, 360.0F));

		// set hangar tag to "Structure"
		hangar1.tag = "Structure";
	}


	void OnGUI()
	{

		//----------//
		// GUI - Build Structures Menu displays when in Planet View
		if(SelectorScript.planetView == true && SelectorScript.viewTransition == false) {
			
			GUI.Box(new Rect(10,Screen.height/2-65,140,100), "Build Structures");	
			
			// Button - Build Ship Hangar
			if(GUI.Button(new Rect(15,Screen.height/2-40,130,20), "Ship Hangar")) {
				
				//If structure hasn't been built make hangarBuilt true, else display notification message
				if(PlanetAssigner.planetInstance[SelectorScript.planetNum].hangarBuilt == false)
				{
					PlanetAssigner.planetInstance[SelectorScript.planetNum].hangarBuilt = true;
					hangarSound = true;
				}
				else{
					//Structure Already Built
					//make messageBox2 true and save time that button was pressed
					GameController1.messageBox2 = true;
					GameController1.buttonDownTime = Time.time;
				}
				//make other messages false (look into lists)
				GameController1.messageBox1 = false;
				GameController1.messageBox3 = false;
				GameController1.messageBox4 = false;
			}
			
			
			// Button - Build Orbital Defense
			if(GUI.Button(new Rect(15,Screen.height/2-15,130,20), "Orbital Defense")) {
				//Functionality Unavailable
				//make messageBox1 true and save time that button was pressed
				GameController1.messageBox1 = true;
				GameController1.buttonDownTime = Time.time;
				//make other messages false (look into lists)
				GameController1.messageBox2 = false;
				GameController1.messageBox3 = false;
				GameController1.messageBox4 = false;
			}
			
			// Button - Colonize Planet
			if(GUI.Button(new Rect(15,Screen.height/2+10,130,20), "Colonize Planet")) {
				//Functionality Unavailable
				//make messageBox1 true and save time that button was pressed
				GameController1.messageBox1 = true;
				GameController1.buttonDownTime = Time.time;
				//make other messages false (look into lists)
				GameController1.messageBox2 = false;
				GameController1.messageBox3 = false;
				GameController1.messageBox4 = false;
			}
			
		}
		
		//----------//
		// GUI - Build Units Menu displays when in Planet View and a hangar has been built
		if(SelectorScript.planetView == true && PlanetAssigner.planetInstance[SelectorScript.planetNum].hangarBuilt && SelectorScript.viewTransition == false) {
			
			GUI.Box(new Rect(10,Screen.height/2+40,140,100), "Build Units");
			
			// Button - Build Destroyer
			if(GUI.Button(new Rect(15,Screen.height/2+65,130,20), "Destroyer")) {
				
				//If fewer than 10 ships have been built, call ShipCreation() and increase shipCount by 1, else if 10 have been built display notification message
				if (PlanetAssigner.planetInstance[SelectorScript.planetNum].shipCount < 10) {
					ShipCreation();
					shipSound = true;
					PlanetAssigner.planetInstance[SelectorScript.planetNum].shipCount++;
				}
				else{
					//Max Ships Built
					//make messageBox3 true and save time that button was pressed
					GameController1.messageBox3 = true;
					GameController1.buttonDownTime = Time.time;
				}
				//make other messages false (look into lists)
				GameController1.messageBox1 = false;
				GameController1.messageBox2 = false;
				GameController1.messageBox4 = false;
				
			}
			
			// Button - Build Scavenger
			if(GUI.Button(new Rect(15,Screen.height/2+90,130,20), "Scavenger")) {
				//Functionality Unavailable
				//make messageBox1 true and save time that button was pressed
				GameController1.messageBox1 = true;
				GameController1.buttonDownTime = Time.time;
				//make other messages false (look into lists)
				GameController1.messageBox2 = false;
				GameController1.messageBox3 = false;
				GameController1.messageBox4 = false;
			}
			
			// Button - Build Freighter
			if(GUI.Button(new Rect(15,Screen.height/2+115,130,20), "Freighter")) {
				//Functionality Unavailable
				//make messageBox1 true and save time that button was pressed
				GameController1.messageBox1 = true;
				GameController1.buttonDownTime = Time.time;
				//make other messages false (look into lists)
				GameController1.messageBox2 = false;
				GameController1.messageBox3 = false;
				GameController1.messageBox4 = false;
			}
		}
	}

}
