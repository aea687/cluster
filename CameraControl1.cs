using UnityEngine;
using System.Collections;

public class CameraControl1 : MonoBehaviour {

	public float dragResistance = 8f;
	public float zoomSpeed = 20f;
	public static float zoomMin = -11.5f;
	public static float zoomMax = -17f;
	public static float cameraBoundary = 16f;
	public static float pViewBoundary = .5f;

	Vector3 cameraHome = new Vector3 (0f, 0f, zoomMax);


	private bool dragging;
	private Vector3 mouseDownPos;


	void Start () {

	}

	void Update(){

		// This code lerps camera to default position during turn transition
		if (SolarGenerator.turnEnd) {

			SelectorScript.viewTransition = true;

			float journeyLength = Vector3.Distance (Camera.main.transform.position, cameraHome);
			float distanceCompleted = journeyLength * Time.fixedDeltaTime *2;

			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, cameraHome, distanceCompleted);

			//below code is to complete camera transition to default position because Lerp does not finish on exact target position.
			Vector3 restingPosition = Camera.main.transform.position;
			if(restingPosition != cameraHome){
				Camera.main.transform.position = Vector3.MoveTowards (transform.position, cameraHome, Time.deltaTime *1);
			}
			else
			{
				SelectorScript.viewTransition = false;
			}
		}

		// This code lerps camera to position when entering Planet View
		if (SelectorScript.enteringPlanet && SelectorScript.exitingPlanet == false) 
		{
			SelectorScript.viewTransition = true;
			Vector3 target = new Vector3 (SelectorScript.activePlanet.transform.position.x, SelectorScript.activePlanet.transform.position.y, SelectorScript.activePlanet.transform.position.z - (1.5f*SelectorScript.activePlanet.transform.localScale.x));

			float journeyLength = Vector3.Distance (Camera.main.transform.position, target);
			float distanceCompleted = journeyLength * Time.fixedDeltaTime *2;
			
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, target, distanceCompleted);
			
			//below code is to complete camera transition to default position because Lerp does not finish on exact target position.
			Vector3 restingPosition = Camera.main.transform.position;
			if(restingPosition != target){
				Camera.main.transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime *1);
			}
			else
			{
				SelectorScript.enteringPlanet = false;
				SelectorScript.viewTransition = false;
			}

		}

		// This code lerps camera to position when exiting Planet View
		if (SelectorScript.exitingPlanet && SelectorScript.enteringPlanet == false)
		{
			SelectorScript.viewTransition = true;
			Vector3 target = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, CameraControl1.zoomMax);
			
			float journeyLength = Vector3.Distance (Camera.main.transform.position, target);
			float distanceCompleted = journeyLength * Time.fixedDeltaTime *2;
			
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, target, distanceCompleted);
			
			//below code is to complete camera transition to default position because Lerp does not finish on exact target position.
			Vector3 restingPosition = Camera.main.transform.position;
			if(restingPosition != target){
				Camera.main.transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime *1);
			}
			else
			{
				SelectorScript.exitingPlanet = false;
				SelectorScript.viewTransition = false;
			}

		}
	

		// If not in Planet View and left mouse button pressed, use raycasting to click and drag camera
		if (Input.GetMouseButton(0) && SolarGenerator.turnEnd == false && SelectorScript.viewTransition == false)
		{
			float hitDist;
			
			//Create ray at mouse position
			Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 groundNormal = new Vector3(0.0f, 0.0f, 1.0f),
					groundPoint = new Vector3(0.0f, 0.0f, -dragResistance);
			Plane groundPlane = new Plane(groundNormal, groundPoint);                

			// If dragging is true (true by default)
			if (dragging)
			{
				groundPlane.Raycast(MouseRay, out hitDist);
				Vector3 currClickPos = MouseRay.GetPoint(hitDist);
				Camera.main.transform.position += mouseDownPos - currClickPos;
			}
			// When clicking left mouse button to move camera and dragging is false, change dragging to true
			else
			{
				dragging = true;
				groundPlane.Raycast(MouseRay, out hitDist);
				mouseDownPos = MouseRay.GetPoint(hitDist);
			}
		}
		// Else (In Planet View and/or left mouse button not pressed), set dragging to false
		else
		{
			dragging = false;
		}

		// ------Camera Boundaries-------  //

		// Camera Boundary when not in Planet View
		if (SelectorScript.planetView == false && SelectorScript.viewTransition == false)
		{
			// left x boundary
			if (Camera.main.transform.position.x < -cameraBoundary)
			{
				Camera.main.transform.position = new Vector3(-cameraBoundary, transform.position.y, transform.position.z);
			}
			// right x boundary
			if (Camera.main.transform.position.x > cameraBoundary)
			{
				Camera.main.transform.position = new Vector3(cameraBoundary, transform.position.y, transform.position.z);
			}
			
			// bottom y boundary
			if (Camera.main.transform.position.y < -cameraBoundary)
			{
				Camera.main.transform.position = new Vector3(transform.position.x, -cameraBoundary, transform.position.z);
			}
			// top y boundary
			if (Camera.main.transform.position.y > cameraBoundary)
			{
				Camera.main.transform.position = new Vector3(transform.position.x, cameraBoundary, transform.position.z);
			}
		}

		// Camera Boundary when in Planet View
		if (SelectorScript.planetView && SelectorScript.viewTransition == false)
		{
			// left x boundary
			if (Camera.main.transform.position.x < SelectorScript.activePlanet.transform.position.x - pViewBoundary)
			{
				Camera.main.transform.position = new Vector3(SelectorScript.activePlanet.transform.position.x - pViewBoundary, transform.position.y, transform.position.z);
			}
			// right x boundary
			if (Camera.main.transform.position.x > SelectorScript.activePlanet.transform.position.x + pViewBoundary)
			{
				Camera.main.transform.position = new Vector3(SelectorScript.activePlanet.transform.position.x + pViewBoundary, transform.position.y, transform.position.z);
			}
			
			// bottom y boundary
			if (Camera.main.transform.position.y < SelectorScript.activePlanet.transform.position.y - pViewBoundary)
			{
				Camera.main.transform.position = new Vector3(transform.position.x, SelectorScript.activePlanet.transform.position.y - pViewBoundary, transform.position.z);
			}
			// top y boundary
			if (Camera.main.transform.position.y > SelectorScript.activePlanet.transform.position.y + pViewBoundary)
			{
				Camera.main.transform.position = new Vector3(transform.position.x, SelectorScript.activePlanet.transform.position.y + pViewBoundary, transform.position.z);
			}
		}


		// If not in Planet View or in Turn Transition, allowing zooming at speed zoomSpeed
		if (SelectorScript.planetView == false && SolarGenerator.turnEnd == false && SelectorScript.viewTransition == false) {

			//----Zooming w/ scroll wheel
			//Zoom Maximum
			if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Camera.main.transform.position.z > zoomMax) { // back
				Camera.main.transform.Translate (Vector3.back * zoomSpeed * Time.deltaTime);
			}

			// Zoom Minimum
			if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.transform.position.z < zoomMin) { // forward
				Camera.main.transform.Translate (Vector3.forward * zoomSpeed * Time.deltaTime);
			}

		}
	}
}
