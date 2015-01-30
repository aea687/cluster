using UnityEngine;
using System.Collections;

public class PlanetAssigner : MonoBehaviour {

	public static Planet[] planetInstance;

	public GameObject[] planetArray;

	public string[] planetNameArray;

	public class Planet
	{

		public GameObject planet;
		public string planetName;
		public bool hangarBuilt;
		public int shipCount;
		public int localFleetCount;

		public float orbitDegrees;

		public Vector3 planetPosition;

		// Constructor
		public Planet()
		{
			planet = null;
			planetName = null;
			hangarBuilt = false;
			shipCount = 0;
			localFleetCount = 0;

		}
	}

	void Awake() {

		planetArray = GameObject.FindGameObjectsWithTag("Planets");

		if (SolarGenerator.levelBuilt == false)
		{
			
			planetInstance = new Planet[planetArray.Length];
			
			planetNameArray [0] = "Octavion";
			planetNameArray [1] = "Ancheria";
			planetNameArray [2] = "Specton";
			planetNameArray [3] = "LV-426";
			planetNameArray [4] = "Digna";
			
			for (int i = 0; i < planetArray.Length; i++) 
			{
				planetInstance[i] = new Planet();
				planetInstance[i].planet = planetArray[i];
				planetInstance[i].planetName = (planetNameArray[i]);

				//Debug.Log (planetInstance [i].planet);
			}
		}
		else
		{
			for (int i = 0; i < planetArray.Length; i++) 
			{

				planetInstance[i].planet = planetArray[i];
								
				//Debug.Log (planetInstance[i].planetPosition);
			}
		}
	}

	void Start()
	{

	}
	
}
