using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjects : MonoBehaviour  {

	private Camera theCamera;
	public float flingValue;

	private Vector3 screenPoint;
	private Vector3 offset;

	void Start ()
	{
		theCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
		
	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//GetComponent<Renderer>().material.color = Color.yellow;
		//GetComponent<asteroidStats> ().statsVisable = true;
	}

	void OnMouseDrag()
	{
		Vector3 cursorScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint (cursorScreenPoint) + offset;
		transform.position = cursorPosition;
	}

	void OnMouseUp()
	{
		GetComponent<Rigidbody>().AddForce(theCamera.transform.right * Input.GetAxis("Mouse X") * flingValue, ForceMode.Impulse);
		GetComponent<Rigidbody>().AddForce(theCamera.transform.up * Input.GetAxis("Mouse Y") * flingValue, ForceMode.Impulse);
		//GetComponent<Renderer>().material.color = Color.cyan;
		//GetComponent<asteroidStats> ().statsVisable = false;
		//gameObject.GetComponent<asteroidPath> ().onPath = false;
	}

}
