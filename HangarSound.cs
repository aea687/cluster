using UnityEngine;
using System.Collections;

public class HangarSound : MonoBehaviour {
	
	void Update () {
		if (PlanetScript.hangarSound == true) {
			audio.Play();
			PlanetScript.hangarSound = false;
		}
	}
}
