using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid_spawner : MonoBehaviour { 
	public GameObject astriod; 
	public float thrust; 
	public Transform spawner;  
	GameObject astoidclone;  


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			astoidclone = Instantiate (astriod, transform.position, Quaternion.identity) as GameObject; 
			Destroy (astoidclone, 3);
		}
	}
}
