using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlanet : MonoBehaviour   {

	int speed = 12;
	float friction = 0.5f;
	float lerpSpeed = 1.5f;
	float xDeg;
	float yDeg;
	Quaternion fromRotation;
	Quaternion toRotation;

	Ray ray;
	RaycastHit hit;


	void Start () 
	{

	}

	void Update () 
	{
		
	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	if (Physics.Raycast(ray, out hit))
		{
		if(Input.GetMouseButton(0)) {

			xDeg -= Input.GetAxis("Mouse X") * speed * friction;
			yDeg += Input.GetAxis("Mouse Y") * speed * friction;
			fromRotation = transform.rotation;
			toRotation = Quaternion.Euler(yDeg,xDeg,0);
			transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime  * lerpSpeed);
			Debug.Log ("== "+toRotation);
			}
			
		}
	}
}
