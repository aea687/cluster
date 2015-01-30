using UnityEngine;
using System.Collections;

public class SolarGenerator : MonoBehaviour {

	public static bool levelBuilt = false;
	
	public static bool turnEnd = false;

	public Transform sun;

	// need to change these asteroid references to comets - asteriods will be separate mechanic
	public Transform asteroid1;
	public Transform asteroid2;
	public Transform asteroid3;	

	public float[] planetDegrees = {200f, 150f, 110f, 80f, 60f};

	public static int turnCounter = 1;

	private int orbitalMoves = 0;
	public int turnTransition = 100;


	void Awake () {

	}

	void Start () {

		// If levelBuilt = false, place all planets in random rotation around Sun
		if (levelBuilt == false)
		{
			for(int i = 0; i < PlanetAssigner.planetInstance.Length; i++)
			{
				PlanetAssigner.planetInstance[i].planet.transform.RotateAround(sun.position, Vector3.forward, Random.Range(0f, 360.0f));	
				PlanetAssigner.planetInstance[i].planetPosition = PlanetAssigner.planetInstance[i].planet.transform.position;
			}

			levelBuilt = true;
		}
		else
		{
			for(int i = 0; i < PlanetAssigner.planetInstance.Length; i++)
			{
				PlanetAssigner.planetInstance[i].planet.transform.position = PlanetAssigner.planetInstance[i].planetPosition;	
			}
		}

		asteroid1.transform.RotateAround(sun.position, Vector3.forward, Random.Range(0f, 360.0f));
		asteroid2.transform.RotateAround(sun.position, Vector3.forward, Random.Range(0f, 360.0f));
		asteroid3.transform.RotateAround(sun.position, Vector3.forward, Random.Range(0f, 360.0f));

	}

	void FixedUpdate () {

		// for Turn Transition, call OrbitPlanet() in FixedUpdate to allow smoothest orbit animation 
		OrbitPlanet();

		// constant orbit for comets
		asteroid1.transform.RotateAround(sun.position, Vector3.forward, Random.Range(0.05f, 0.2f));
		asteroid2.transform.RotateAround(sun.position, Vector3.forward, Random.Range(0.05f, 0.2f));
		asteroid3.transform.RotateAround(sun.position, Vector3.forward, Random.Range(0.05f, 0.2f));
	}

	void Update () {
	
	}

	// Planet orbit animations during Turn Transition
	void OrbitPlanet() {
		
		//when turn is ended, execute Orbital Moves 100 times (turnTransition value)
		if (turnEnd && orbitalMoves < turnTransition) 
		{
			
			for(int i = 0; i < PlanetAssigner.planetInstance.Length; i++)
			{
				// This variable saved the value of planets' orbital degrees divided by 100 since Turn End animation executes 100 rotations. 
				// New planet location will end up being designated planet degrees.
				float orbitValue = planetDegrees[i]/(float)turnTransition;

				PlanetAssigner.planetInstance[i].planet.transform.RotateAround(sun.position, Vector3.forward, orbitValue);
			}
	
			orbitalMoves++;
			
		} 
		
		//once number of Orbital Moves is equal to 100 (turnTransition value), increase Turn Count by 1
		if (orbitalMoves == turnTransition) 
		{
			turnEnd = false;
			turnCounter += 1;
			orbitalMoves = 0;

			for(int i = 0; i < PlanetAssigner.planetInstance.Length; i++)
			{
				PlanetAssigner.planetInstance[i].planetPosition = PlanetAssigner.planetInstance[i].planet.transform.position;
			}
		}
	}

}


