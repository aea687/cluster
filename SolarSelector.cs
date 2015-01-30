using UnityEngine;
using System.Collections;

public class SolarSelector : MonoBehaviour {

	//Highlight Color
	public Color highlightColor = new Color(1, 245, 255, 255);
	
	//Default Color
	private Color defaultMainColor;



	
	void Start () {

		GameMenu2.loadingMessage = false;

		// Make default star color equal to starting star color
		defaultMainColor = renderer.material.GetColor("_Color"); 



	}
	
	void Update () {
	
	}

	// Change star color to Highlight Color when hovering mouse over star
	void OnMouseEnter(){

		// Set star color to Highlight Color
		renderer.material.SetColor ("_Color", highlightColor);

	}

	// Change star color back to default when no longer hovering mouse over star
	void OnMouseExit(){

		// Reset star color to default
		renderer.material.SetColor ("_Color", defaultMainColor);

	}

	// When a star is clicked, load solar map for that star
	void OnMouseDown(){

		GameMenu2.alertMessage1 = false;
		GameMenu2.alertMessage2 = false;
		GameMenu2.alertMessage3 = false;

		if (gameObject.tag == "Sun") 
		{
			// If planetView still true from previous scene, set to false before loading new scene
			if (SelectorScript.planetView == true)
			{
				SelectorScript.planetView = false;
			}
			GameMenu2.loadingMessage = true;
			Application.LoadLevel(2);
		}
		if (gameObject.tag == "Sun2") 
		{
			// If planetView still true from previous scene, set to false before loading new scene
			if (SelectorScript.planetView == true)
			{
				SelectorScript.planetView = false;
			}
			//GameMenu2.alertMessage3 = false;
			//GameMenu2.alertMessage1 = false;
			GameMenu2.alertMessage2 = true;


			//Application.LoadLevel(3);
		}
			
	}

}
