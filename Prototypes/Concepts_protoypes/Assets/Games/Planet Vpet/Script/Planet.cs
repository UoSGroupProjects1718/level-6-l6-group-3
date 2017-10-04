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
	public int name1; 
	public int name2; 
	public Text planetname1; 
	public Text planetname2;
	public Button reset; 
	public Text lifeform; 
	public int lifeformnum = 0;
	Vector3 temp;

	// Use this for initialization
	void Start () { 
		StartCoroutine (addage ()); 
		Button btn = reset.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
		planetcolor = Random.Range (1, 6);  
		scale = Random.Range (1, 6); 
		name1 = Random.Range (1, 6); 
		name2 = Random.Range (1, 3); 
		lifeformnum = Random.Range (2, 50);
		if (planetcolor == 1) {
			rend.material.color = Color.green; 
		} else if (planetcolor == 2) {
			rend.material.color = Color.blue; 

		} else if (planetcolor == 3) {
			rend.material.color = Color.yellow; 

		} else if (planetcolor == 4) {
			rend.material.color = Color.cyan; 

		} else if (planetcolor == 5) {
			rend.material.color = Color.magenta; 
			 
		} else if (planetcolor == 6) {
			rend.material.color = Color.red; 

		} 
		if (scale == 1) {
			temp = transform.localScale; 
			temp.x = 0.2f; 
			temp.y = 0.2f;  
			transform.localScale = temp;
		} else if (scale == 2) {
			temp = transform.localScale; 
			temp.x = 0.4f; 
			temp.y = 0.4f;  
			transform.localScale = temp;
		}else if (scale == 3) {
			temp = transform.localScale; 
			temp.x = 0.7f; 
			temp.y = 0.7f;  
			transform.localScale = temp;
		}else if (scale == 4) {
			temp = transform.localScale; 
			temp.x = 1f; 
			temp.y = 1f;  
			transform.localScale = temp;
		}else if (scale == 5) {
			temp = transform.localScale; 
			temp.x = 0.1f; 
			temp.y = 0.1f;  
			transform.localScale = temp;
		}else if (scale == 6) {
			temp = transform.localScale; 
			temp.x = 1.6f; 
			temp.y = 1.6f;  
			transform.localScale = temp;
		} 
		if (name1 == 1) {
			planetname1.text = "Akaali";
		} else if (name1 == 2) {
			planetname1.text = "Brunali";
		} else if (name1 == 3) {
			planetname1.text = "Cravic";
		}else if (name1 == 4) {
			planetname1.text = "Dosi";
		}else if (name1 == 5) {
			planetname1.text = "Elaysian";
		}else if (name1 == 6) {
			planetname1.text = "Founders'";
		} 
		if (name2 == 1) {
			planetname2.text = "homeworld";
		} else if (name2 == 2) {
			planetname2.text = "settlement";
		} else if (name2 == 3) {
			planetname2.text = "colony";
		}
	} 
	void TaskOnClick() {
		name1 = Random.Range (1, 6); 
		name2 = Random.Range (1, 3);
		planetagetext.text = planetage + " Years"; 
		planetcolor = Random.Range (1, 6); 
		scale = Random.Range (1, 6); 
		lifeformnum = Random.Range (2, 50);
		if (planetcolor == 1) {
			rend.material.color = Color.green; 
			  
			planetage = 0; 
		} else if (planetcolor == 2) {
			rend.material.color = Color.blue; 
		
			planetage = 0; 
		} else if (planetcolor == 3) {
			rend.material.color = Color.yellow; 
			 
			planetage = 0; 
		} else if (planetcolor == 4) {
			rend.material.color = Color.cyan; 

			planetage = 0; 
		} else if (planetcolor == 5) {
			rend.material.color = Color.magenta; 

			planetage = 0; 
		} else if (planetcolor == 6) {
			rend.material.color = Color.red; 

			planetage = 0; 
		} 
		if (scale == 1) {
			temp = transform.localScale; 
			temp.x = 0.2f; 
			temp.y = 0.2f;  
			transform.localScale = temp;
		} else if (scale == 2) {
			temp = transform.localScale; 
			temp.x = 0.4f;  

			temp.y = 0.4f;  
			transform.localScale = temp;
		}else if (scale == 3) {
			temp = transform.localScale; 
			temp.x = 0.7f; 
			temp.y = 0.7f;  
			transform.localScale = temp;
		}else if (scale == 4) {
			temp = transform.localScale; 
			temp.x = 1f; 
			temp.y = 1f;  
			transform.localScale = temp;
		}else if (scale == 5) {
			temp = transform.localScale; 
			temp.x = 0.1f; 
			temp.y = 0.1f;  
			transform.localScale = temp;
		}else if (scale == 6) {
			temp = transform.localScale; 
			temp.x = 1.6f; 
			temp.y = 1.6f;  
			transform.localScale = temp;
		} 
		if (name1 == 1) {
			planetname1.text = "Akaali";
		} else if (name1 == 2) {
			planetname1.text = "Brunali";
		} else if (name1 == 3) {
			planetname1.text = "Cravic";
		}else if (name1 == 4) {
			planetname1.text = "Dosi";
		}else if (name1 == 5) {
			planetname1.text = "Elaysian";
		}else if (name1 == 6) {
			planetname1.text = "Founders'";
		} 
		if (name2 == 1) {
			planetname2.text = "homeworld";
		} else if (name2 == 2) {
			planetname2.text = "settlement";
		} else if (name2 == 3) {
			planetname2.text = "colony";
		}
	}

	// Update is called once per frame
	void Update () { 
		planetagetext.text = planetage + " Years"; 
		lifeform.text = lifeformnum + " Species" ; 
	} 

	IEnumerator addage()
	{
		yield return new WaitForSeconds (2.5f); 
		planetage += 1;  
		lifeformnum += Random.Range (256, 65384);

		StartCoroutine (addage ());
	}


}
