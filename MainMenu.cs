using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnGUI () {
		// GUI - Main Menu
		GUI.Box(new Rect(Screen.width/2-50,Screen.height/2-20,100,60), "Main Menu");
		
		// Button - Load Cluster Map for New Game
		if(GUI.Button(new Rect(Screen.width/2-45,Screen.height/2+10,90,20), "New Game")) {
			Application.LoadLevel(1);
		}

	}
}

