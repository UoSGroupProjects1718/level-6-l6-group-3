using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanityItems : MonoBehaviour {

	public GameObject newParent;

	public bool hasHit;

	void Start()
	{
		newParent = GameObject.FindGameObjectWithTag("DevelopedPlanet");
	}


	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "DevelopedPlanet") 
		{
			hasHit = true;
			var parentPlanet = newParent.gameObject;
			gameObject.transform.parent = newParent.transform;
			gameObject.GetComponent<Rigidbody>().isKinematic = true;

			Debug.Log ("worked");
		}
			

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
