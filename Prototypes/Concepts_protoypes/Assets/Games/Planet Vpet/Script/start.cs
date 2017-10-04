using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class start : MonoBehaviour {  
	//public GameObject starttext; 
	public GameObject planet;  
	public Button startbutton; 
	public GameObject startb; 
	public GameObject gameUI; 
	//void OnMouseDown (){
		//Debug.Log ("Mouse down");
	//}

	// Use this for initialization
	void Start () { 
		gameUI.SetActive (false);
		Button btn = startbutton.GetComponent<Button> (); 
		btn.onClick.AddListener (TaskOnClick);
	}
	void TaskOnClick() { 
		startb.SetActive (false);
		planet.SetActive (true);  
		gameUI.SetActive (true);
	}
	// Update is called once per frame
	void Update () { 
		//if (Input.GetKeyDown ("space")) {
			//Debug.Log ("mouse"); 
		//	starttext.SetActive (false); 
			//planet.SetActive (true);
		}
		
	}

