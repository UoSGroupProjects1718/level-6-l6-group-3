using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraClamp : MonoBehaviour {
	public float xPos;
	public float yPos;

	void Update () 
	{
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		pos.x = Mathf.Clamp01 (xPos);
		pos.y = Mathf.Clamp01 (yPos);

		transform.position = Camera.main.ViewportToWorldPoint (pos);

	}
}
