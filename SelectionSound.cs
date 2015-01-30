using UnityEngine;
using System.Collections;

public class SelectionSound : MonoBehaviour {

	bool planetSelect = SelectorScript.planetView;

	void Update () {
		if (planetSelect != SelectorScript.planetView) {
			audio.Play();
			planetSelect = SelectorScript.planetView;
		}
	}
}
