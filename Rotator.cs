using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {


	void FixedUpdate () {
		transform.Rotate (new Vector3(0, 0, 45) * Time.deltaTime);
	}
}
