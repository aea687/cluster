using UnityEngine;
using System.Collections;


// Cluster Map Controls
public class CameraControl2 : MonoBehaviour {

	public float dragResistance = 8.0f;

	private bool dragging;
	private Vector3 mouseDownPos;
	

	void Start () {
		
	}

	void Update () 
	{
		if (Input.GetMouseButton(0))
		{
			float hitDist;
			//RaycastHit hit;
			
			Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 groundNormal = new Vector3(0.0f, 0.0f, 1.0f),
			groundPoint = new Vector3(0.0f, 0.0f, -dragResistance);
			Plane groundPlane = new Plane(groundNormal, groundPoint);                
			
			if (dragging)
			{
				groundPlane.Raycast(MouseRay, out hitDist);
				Vector3 currClickPos = MouseRay.GetPoint(hitDist);
				Camera.main.transform.position += mouseDownPos - currClickPos;
				if (Camera.main.transform.position.x < -8f)
				{
					Camera.main.transform.position = new Vector3(-8f, transform.position.y, transform.position.z);
				}
				if (Camera.main.transform.position.x > 8f)
				{
					Camera.main.transform.position = new Vector3(8f, transform.position.y, transform.position.z);
				}
				if (Camera.main.transform.position.y < -4f)
				{
					Camera.main.transform.position = new Vector3(transform.position.x, -4f, transform.position.z);
				}
				if (Camera.main.transform.position.y > 4f)
				{
					Camera.main.transform.position = new Vector3(transform.position.x, 4f, transform.position.z);
				}
			}
			else 
			{
				dragging = true;
				groundPlane.Raycast(MouseRay, out hitDist);
				mouseDownPos = MouseRay.GetPoint(hitDist);
			}
		}
		else
		{
			dragging = false;
		}
		

		
		
	}
}
