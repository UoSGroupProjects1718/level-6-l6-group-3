using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGravity : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "gravityField")
		{
			Debug.Log ("hit");
			gameObject.GetComponent<PlayerGravityBody> ().inGravityField = true;
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;

		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "rock")
		{
			Debug.Log ("left");
			gameObject.GetComponent<PlayerGravityBody> ().inGravityField = false;

		}
	}

}
