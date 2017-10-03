using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class Planet : MonoBehaviour { 
	public GameObject planet; 
	public Vector3 planetscale; 
	public SpriteRenderer rend; 
	public int planetcolor; 
	public int planetage = 0 ; 
	public Text planetagetext; 
	public int scale = 0 ; 
	Vector3 temp;

	// Use this for initialization
	void Start () { 
		StartCoroutine (addage ());
		planetcolor = Random.Range (1, 6); 
		if (planetcolor == 1) {
			rend.material.color = Color.green; 
			Debug.Log ("Planet is green"); 
		} else if (planetcolor == 2) {
			rend.material.color = Color.blue; 
			Debug.Log ("Planet is blue");
		} else if (planetcolor == 3) {
			rend.material.color = Color.yellow; 
			Debug.Log ("Planet is yellow");
		} else if (planetcolor == 4) {
			rend.material.color = Color.cyan; 
			Debug.Log ("Planet is cyan");
		} else if (planetcolor == 5) {
			rend.material.color = Color.magenta; 
			Debug.Log ("Planet is magenta"); 
		} else if (planetcolor == 6) {
			rend.material.color = Color.red; 
			Debug.Log ("Planet is red");
		}
	}

	// Update is called once per frame
	void Update () { 
		//StartCoroutine (addage ()); 
		if (scale == 2) {
			scale = 0; 
			temp = transform.localScale; 
			temp.x += 0.0050f; 
			temp.y += 0.0050f;  
			transform.localScale = temp;
		}
		planetagetext.text = planetage + " Years";
		if (Input.GetKeyDown (KeyCode.A)) {
			planetcolor = Random.Range (1, 6); 
			if (planetcolor == 1) {
				rend.material.color = Color.green; 
				Debug.Log ("Planet is green");  
				planetage = 0; 
				temp = transform.localScale; 
				temp.x = 0.2f; 
				temp.y = 0.2f;  
				transform.localScale = temp;
			} else if (planetcolor == 2) {
				rend.material.color = Color.blue; 
				Debug.Log ("Planet is blue"); 
				planetage = 0; 
				temp = transform.localScale; 
				temp.x = 0.2f; 
				temp.y = 0.2f;  
				transform.localScale = temp;
			} else if (planetcolor == 3) {
				rend.material.color = Color.yellow; 
				Debug.Log ("Planet is yellow"); 
				planetage = 0; 
				temp = transform.localScale; 
				temp.x = 0.2f; 
				temp.y = 0.2f;  
				transform.localScale = temp;
			} else if (planetcolor == 4) {
				rend.material.color = Color.cyan; 
				Debug.Log ("Planet is cyan"); 
				planetage = 0; 
				temp = transform.localScale; 
				temp.x = 0.2f; 
				temp.y = 0.2f;  
				transform.localScale = temp;
			} else if (planetcolor == 5) {
				rend.material.color = Color.magenta; 
				Debug.Log ("Planet is magenta"); 
				planetage = 0; 
				temp = transform.localScale; 
				temp.x = 0.2f; 
				temp.y = 0.2f;  
				transform.localScale = temp;
			} else if (planetcolor == 6) {
				rend.material.color = Color.red; 
				Debug.Log ("Planet is red"); 
				planetage = 0; 
				temp = transform.localScale; 
				temp.x = 0.2f; 
				temp.y = 0.2f;  
				transform.localScale = temp;
			}
		} 
	}
	IEnumerator addage()
	{
		yield return new WaitForSeconds (2.5f); 
		planetage += 1;   
		scale += 1;

		StartCoroutine (addage ());
	}


}
