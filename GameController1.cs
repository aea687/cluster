using UnityEngine;
using System.Collections;

public class GameController1 : MonoBehaviour {

	GameObject[] ships;
	GameObject[] structures;

	//-----Alert Messages-----//
	//
	//Float to record time button is pressed
	public static float buttonDownTime;
	//Functionality Unavailable
	public static bool messageBox1 = false;
	//Structure Already Built
	public static bool messageBox2 = false;
	//Max Ships Built
	public static bool messageBox3 = false;
	//Max Fleets Created
	public static bool messageBox4 = false;
	//Must be in Planet View to add new fleets
	public static bool messageBox5 = false;
	//
	//------------------------//


	void Awake () {

		//re-initialize these as false so no menus display when re-entering solar system
		messageBox1 = false;
		messageBox2 = false;
		messageBox3 = false;
		messageBox4 = false;
		messageBox5 = false;
	}

	void Start () {

	}

	void FixedUpdate () {

	}

	void Update () {

		// Always call RemoveShips() so as to always check for removal requirements
		RemoveShips();
		// Always call RemoveStructures() so as to always check for removal requirements
		RemoveStructures();
	}


	// Function to remove "Ship" objects when not in Planet View
	void RemoveShips()
	{
		ships = GameObject.FindGameObjectsWithTag ("Ship");
	
		if (SelectorScript.planetView == false && ships != null) 
		{
			for(var i = 0 ; i < ships.Length ; i ++)
			{
				Destroy(ships[i]);
			}

			PlanetScript.shipsVisible = 0f;
		}
	}

	// Function to remove "Structure" objects when not in Planet View
	void RemoveStructures(){

		structures = GameObject.FindGameObjectsWithTag ("Structure");
		
		if (SelectorScript.planetView == false && structures != null) 
		{
			
			for(var i = 0 ; i < structures.Length ; i ++)
			{
				Destroy(structures[i]);
			}
		}
	}

	
	void OnGUI(){

		// GUI - Turn Counter/End Turn Menu - displays at all times inside Cluster Battle
		GUI.Box(new Rect(Screen.width-110,10,100,50),"Turn " + SolarGenerator.turnCounter);
		
			// Button - End Turn - make planetView false and change camera position to default Solar Map position
			if(GUI.Button(new Rect(Screen.width-105,35,90,20), "End Turn") && SolarGenerator.turnEnd == false && SelectorScript.viewTransition == false)
			{
				SolarGenerator.turnEnd = true;	
				SelectorScript.planetView = false;
			}

		//-----Alert Messages-----//
		//
		//
		//

		// Message - Functionality Unavailable
		// IF messageBox1 is true, display notification message
		if(messageBox1)
		{
			
			//display for 3 seconds
			if(Time.time < buttonDownTime + 3 && SelectorScript.viewTransition == false)
			{
				GUI.Box(new Rect(Screen.width/2-150,Screen.height/2-20,300,25), "This functionality is not available yet.");
			}
			//after 3 seconds, make messageBox1 false
			else
			{
				messageBox1 = false;
			}
		}
		
		// Message - Structure Already Built
		// IF messageBox2 is true, display notification message
		if(messageBox2)
		{
			
			//display for 3 seconds
			if(Time.time < buttonDownTime + 3  && SelectorScript.viewTransition == false)
			{
				GUI.Box(new Rect(Screen.width/2-150,Screen.height/2-20,300,25), "This structure has already been built.");
			}
			//after 3 seconds, make messageBox2 false
			else
			{
				messageBox2 = false;
			}
		}
		
		// Message - Max Ships Built
		// IF messageBox3 is true, display notification message
		if(messageBox3)
		{	
			//display for 3 seconds
			if(Time.time < buttonDownTime + 3 && SelectorScript.viewTransition == false)
			{
				GUI.Box(new Rect(Screen.width/2-165,Screen.height/2-20,330,25), "The maximum number of ships (10) has been reached.");
			}
			//after 3 seconds, make messageBox3 false
			else
			{
				messageBox3 = false;
			}
		}

		// Message - Max Fleets created
		// IF messageBox4 is true, display notification message
		if(messageBox4)
		{	
			//display for 3 seconds
			if(Time.time < buttonDownTime + 3 && SelectorScript.viewTransition == false)
			{
				GUI.Box(new Rect(Screen.width/2-175,Screen.height/2-20,350,25), "You must invest in the technology tree to build more fleets.");
			}
			//after 3 seconds, make messageBox4 false
			else
			{
				messageBox4 = false;
			}
		}

		// Message - Can only add new fleets in Planet View
		// IF messageBox5 is true, display notification message
		if(messageBox5)
		{	
			//display for 3 seconds
			if(Time.time < buttonDownTime + 3 && SelectorScript.viewTransition == false)
			{
				GUI.Box(new Rect(Screen.width/2-175,Screen.height/2-20,350,25), "You must be in Planet View to add new fleets.");
			}
			//after 3 seconds, make messageBox4 false
			else
			{
				messageBox5 = false;
			}
		}

		//
		//
		//------------------------//
	}
		
}
