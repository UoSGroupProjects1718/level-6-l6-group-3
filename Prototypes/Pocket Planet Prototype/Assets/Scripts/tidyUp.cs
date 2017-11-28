using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tidyUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "rock") 
		{

			col.gameObject.transform.position = new Vector3 (1400, 450, -136);
			col.gameObject.GetComponent<PlayerGravityBody> ().inGravityField = false;
			col.gameObject.GetComponent<asteroidPath> ().onPath = true;



		}
	}

}
