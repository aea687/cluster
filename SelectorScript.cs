using UnityEngine;
using System.Collections;

public class SelectorScript : MonoBehaviour {

	public static bool planetView = false;
	public static bool planetHover = false;
	public static bool enteringPlanet = false;
	public static bool exitingPlanet = false;
	public static bool viewTransition = false;

	//Static game object to store Active Planet
	public static GameObject activePlanet;
	
	public static int planetNum;

		
	//Highlight Color
	public Color highlightColor = new Color(1, 245, 255, 255);

	//Default Color
	private Color defaultMainColor;
	

	void Start () {

		// Make default planet color equal to starting planet color
		defaultMainColor = renderer.material.GetColor("_Color"); 
	
	}

	void Update () {

		// If not in Planet View and there is an Active Planet set, disable PlanetScript and remove Active Planet
		if (planetView == false && viewTransition == false && activePlanet != null) {

			activePlanet.GetComponent<PlanetScript>().enabled = false;

			activePlanet = null;
		}
	}



	// Change planet color to Highlight Color when hovering mouse over planet
	void OnMouseEnter(){

		// If not in Planet View or Turn Transition, set planet color to Highlight Color
		if (planetView == false && SolarGenerator.turnEnd == false && viewTransition == false) { 
			renderer.material.SetColor ("_Color", highlightColor);

			PlanetNumber ();

			planetHover = true;
		}

	}

	// Change planet color back to default when no longer hovering mouse over planet
	void OnMouseExit(){

		// If not in Planet View or Turn Transition, reset planet color to default
		if (planetView == false && SolarGenerator.turnEnd == false && viewTransition == false) {
			renderer.material.SetColor ("_Color", defaultMainColor);

			planetHover = false;
		}

	}

	// Function to enter Planet View when planet is clicked
	void OnMouseDown(){

		// If not in Planet View and not in Turn Transition then enter Planet View
		if (planetView == false && SolarGenerator.turnEnd == false && viewTransition == false) {

			PlanetNumber ();

			// make Active Planet equal to selected planet
			activePlanet = gameObject;

			enteringPlanet = true;

			// set main camera at x,y position of planet, with z position proportional to planet scale (planet z position - 1.5 * planet x scale)
			//Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - (1.5f*transform.localScale.x));

			// set planet's color back to its default color
			renderer.material.SetColor ("_Color", defaultMainColor);

			// make planetView true
			planetView = true;
			// make planetHover true
			planetHover = false;

			// close Help Guide
			GameMenu1.helpOpen = false;

			// enable PlanetScript for Active Planet so that structures can be built
			activePlanet.GetComponent<PlanetScript>().enabled = true;

		}
	}

	void PlanetNumber()
	{
		for(int i = 0; i < PlanetAssigner.planetInstance.Length; i++)
		{
			if(PlanetAssigner.planetInstance[i].planet == gameObject)
			{
				planetNum = i;
			}
		}
	}

}
