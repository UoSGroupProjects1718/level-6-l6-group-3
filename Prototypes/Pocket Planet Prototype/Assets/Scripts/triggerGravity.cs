using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGravity : MonoBehaviour {


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "rock")
		{
			Debug.Log ("hit");
			GameObject.Find ("Asteriod").GetComponent<PlayerGravityBody> ().inGravityField = true;
			GameObject.Find ("Asteriod2").GetComponent<PlayerGravityBody> ().inGravityField = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "rock")
		{
			Debug.Log ("hit");
			GameObject.Find ("Asteriod").GetComponent<PlayerGravityBody> ().inGravityField = false;
			GameObject.Find ("Asteriod2").GetComponent<PlayerGravityBody> ().inGravityField = false;
		}
	}

}
