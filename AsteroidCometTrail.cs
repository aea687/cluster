using UnityEngine;
using System.Collections;

public class AsteroidCometTrail : MonoBehaviour {

	public Transform star;

	
	void Start () {

	}
	

	void Update () {


		Vector3 relative = star.position - transform.position;

		float angle = Mathf.Atan2 (relative.x, relative.y);
		angle += 80 * Mathf.Deg2Rad;


		ParticleSystem[] particles = gameObject.GetComponentsInChildren<ParticleSystem>();



		for(int i = 0; i < particles.Length; i++)
		{
			particles[i].startRotation = angle;
		}
		
		
	}
}
