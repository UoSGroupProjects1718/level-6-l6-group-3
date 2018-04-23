using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGravity : MonoBehaviour {

	//public GameObject flames;


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "gravityField")
		{
			ParticleSystem ps = GetComponent<ParticleSystem> ();
			//Debug.Log ("hit");
			gameObject.GetComponent<PlayerGravityBody> ().inGravityField = true;
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Renderer>().material.color = Color.red;

			//ParticleSystem.EmissionModule em = flames.GetComponent<ParticleSystem> ().emission;
			//ParticleSystem.EmissionModule em = gameObject.GetComponentInChildren<ParticleSystem>().emission;
			//em.enabled = true;
		}

	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "rock")
		{
			Debug.Log ("left");
			gameObject.GetComponent<PlayerGravityBody> ().inGravityField = false;

			ParticleSystem.EmissionModule em = gameObject.GetComponentInChildren<ParticleSystem>().emission;
			em.enabled = false;

		}
	}

}
