using UnityEngine;
using System.Collections;


// Cluster Map Menu
public class GameMenu2 : MonoBehaviour {

	public static bool alertMessage1 = true;
	public static bool alertMessage2 = false;
	public static bool alertMessage3 = false;
	public static bool loadingMessage = false;

	void Awake () {
		alertMessage2 = false;
		alertMessage3 = false;
	}

	void OnGUI () {

		// GUI - STAR CLUSTER title
		GUI.Box(new Rect(Screen.width/2-60,10,120,25), "STAR CLUSTER");

		// GUI - Game Menu
		GUI.Box(new Rect(10,10,100,75), "Game Menu");
		
		// GUI - Load Main Menu Button
		if(GUI.Button(new Rect(15,35,90,20), "Main Menu")) 
		{
			Application.LoadLevel(0);
		}

		// GUI - Help Button
		if(GUI.Button(new Rect(15,60,90,20), "Help")) 
		{
			alertMessage3 = true;
		}
			// GUI - Help Popup Window
			if(alertMessage3 == true)
			{
				alertMessage2 = false;
				alertMessage1 = false;
				GUI.Box(new Rect(Screen.width/2-180,65,360,55), "Help Guide\n" +
					"Click and drag to move around the Star Cluster.\n" +
					"Click on a star to enter its Solar System.");
				// If X is clicked, make helpOpen false so that popup windows disappears
				if(GUI.Button(new Rect(Screen.width/2+155,65,25,20), "X"))
				{
					alertMessage3 = false;
				}
			}

		if(alertMessage1 == true)
		{
			alertMessage3 = false;
			alertMessage2 = false;
			GUI.Box(new Rect(Screen.width/2-180,65,360,85), "Welcome to Cluster\n" +
			        "You must fight for control of this star cluster.\n" +
			        "To begin, click the help button in the top left.\n" +
			        "The help button will always provide assistance\nrelative to your current view and location.");
			// If X is clicked, make helpOpen false so that popup windows disappears
			if(GUI.Button(new Rect(Screen.width/2+155,65,25,20), "X"))
			{
				alertMessage1 = false;
			}
		}

		if(alertMessage2 == true)
		{
			alertMessage1 = false;
			alertMessage3 = false;
			GUI.Box(new Rect(Screen.width/2-180,65,360,65), "Functionality Unavailable\n" +
			        "This star's solar system cannot be accessed at this time.\n" +
			        "Please click on the yellow star to enter a solar system.\n");
			// If X is clicked, make helpOpen false so that popup windows disappears
			if(GUI.Button(new Rect(Screen.width/2+155,65,25,20), "X"))
			{
				alertMessage2 = false;
			}
		}

		if(loadingMessage == true)
		{
			alertMessage1 = false;
			alertMessage2 = false;
			alertMessage3 = false;
			GUI.Box(new Rect(Screen.width/2-50,65,100,25), "Loading...");
		
		}
	}
}