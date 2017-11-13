using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class asteroidPath : MonoBehaviour {
	public Transform target;
	public float speed;
	public float rotSpeed;
	void Update() 
	{
		if (gameObject.GetComponent<PlayerGravityBody> ().inGravityField == false) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			transform.Rotate (Vector3.right * rotSpeed *Time.deltaTime);
			transform.Rotate (Vector3.up * rotSpeed *Time.deltaTime);
		}
	}

}