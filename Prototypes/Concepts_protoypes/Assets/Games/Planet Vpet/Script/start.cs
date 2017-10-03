using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class start : MonoBehaviour {  
	public GameObject starttext; 
	public GameObject planet; 
	//void OnMouseDown (){
		//Debug.Log ("Mouse down");
	//}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		if (Input.GetKeyDown ("space")) {
			Debug.Log ("mouse"); 
			starttext.SetActive (false); 
			planet.SetActive (true);
		}
		
	}
}
