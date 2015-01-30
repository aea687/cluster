using UnityEngine;
using System.Collections;

public class ShipCreationSound : MonoBehaviour {
	
	void Update () {
		if (PlanetScript.shipSound == true) {
			audio.Play();
			PlanetScript.shipSound = false;
		}
	}
}
